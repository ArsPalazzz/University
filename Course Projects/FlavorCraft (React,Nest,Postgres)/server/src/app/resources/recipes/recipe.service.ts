import { BadRequestException, Inject, Injectable, Scope } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { Prisma, recipes } from '@prisma/client';
import { RecipeStatus } from '@common/constants/recipe.const';
import { CreateRecipeDto } from './dto/create-recipe.dto';
import { UpdateRecipeDto } from './dto/update-recipe.dto';
import { BaseFilterService } from '@common/filters/base-filter.service';
import { FilterRecipesDto } from './dto/filter-recipes.dto';
import { UserAuthPayload } from '@common/types/user.types';
import { AuthRole } from '@common/constants/auth.const';
import { REQUEST } from '@nestjs/core';
import { Request } from 'express';
import { RecipeResponseWithUser } from './dto/recipe-response-with-user';
import { CommentStatus } from '@common/constants/comment';

type RecipeWithRelations = Prisma.recipesGetPayload<{
  include: {
    recipes_tags: {
      include: {
        tags: true; // Подключаем таблицу tags
      };
    };
    users: true; // Подключаем таблицу users
    ratings: true;
  };
}>;

@Injectable({ scope: Scope.REQUEST })
export class RecipeService {
  constructor(
    private prisma: PrismaService,
    private readonly baseFilterService: BaseFilterService,
    @Inject(REQUEST) private readonly request: Request,
  ) {}

  async findAll(): Promise<recipes[]> {
    return this.prisma.recipes.findMany({
      where: {
        status: { notIn: [RecipeStatus.BLOCKED, RecipeStatus.ARCHIEVED] },
      },
    });
  }

  async findMain(): Promise<RecipeWithRelations[]> {
    return this.prisma.recipes.findMany({
      where: {
        status: { notIn: [RecipeStatus.BLOCKED, RecipeStatus.ARCHIEVED] },
        recipes_tags: {
          some: {
            tags: {
              name: {
                in: ['Diet', 'Vegetarian'],
              },
            },
          },
        },
      },
      include: {
        recipes_tags: {
          include: {
            tags: true,
          },
        },
        users: {},
        ratings: {},
      },
    });
  }

  async findRecipesByUserId({
    userId,
    exceptId,
  }: {
    userId: string;
    exceptId: string;
  }): Promise<(recipes & { ratings: { rating: number }[] })[]> {
    return await this.prisma.recipes.findMany({
      where: {
        status: { notIn: [RecipeStatus.BLOCKED, RecipeStatus.ARCHIEVED] },
        user_id: userId,
        id: {
          not: exceptId,
        },
      },
      include: {
        ratings: {
          select: {
            rating: true,
          },
        },
      },
      take: 3,
    });
  }

  async findMyRecipes(): Promise<
    (recipes & { ratings: { rating: number }[] })[]
  > {
    const user = this.request.user as UserAuthPayload;

    return this.prisma.recipes.findMany({
      where: {
        status: { notIn: [RecipeStatus.BLOCKED, RecipeStatus.ARCHIEVED] },
        user_id: user.id,
      },
      include: {
        ratings: {
          select: {
            rating: true,
          },
        },
      },
    });
  }

  async filterAllRecipes(filterDto: FilterRecipesDto) {
    const {
      search,
      minCalories,
      maxCalories,
      categories,
      sortBy = 'created_at',
      order = 'desc',
      tags,
      limit = 10,
      page = 1,
      except_id,
    } = filterDto;

    const where: Record<string, any> = {
      status: { notIn: [RecipeStatus.ARCHIEVED, RecipeStatus.BLOCKED] },
    };

    if (except_id) {
      where.id = { not: except_id }; // Исключить рецепт с указанным ID
    }

    // Фильтр по калориям
    if (minCalories) {
      where.calories = { gte: Number(minCalories) };
    }
    if (maxCalories) {
      where.calories = { ...where.calories, lte: Number(maxCalories) };
    }

    // Фильтр по категориям
    if (categories) {
      where.category_id = { in: categories.map((id) => Number(id)) };
    }

    // Фильтр по тегам
    if (tags && tags.length > 0) {
      where.recipes_tags = {
        some: {
          tags: {
            query_key: { in: tags },
          },
        },
      };
    }

    // Полнотекстовый поиск
    if (search) {
      where.title = { contains: search, mode: 'insensitive' };
    }

    // Подсчёт общего количества записей
    const totalCount = await this.prisma.recipes.count({ where });

    // Вычисление количества страниц
    const totalPages = Math.ceil(totalCount / limit);

    // Получение данных с учётом пагинации
    const allResult = await this.prisma.recipes.findMany({
      where,
      orderBy: sortBy === 'rating' ? undefined : { [sortBy]: order },
      skip: (page - 1) * limit,
      take: Number(limit),
      include: {
        ratings: true,
        users: {
          select: {
            id: true,
            username: true,
          },
        },
      },
    });

    const formattedResult = allResult.map((recipe) => ({
      ...recipe,
      rating_count: recipe.ratings.length,
      ratings: undefined,
    }));

    const sortedResult =
      sortBy === 'rating'
        ? formattedResult.sort((a, b) =>
            order === 'desc'
              ? b.rating_count - a.rating_count
              : a.rating_count - b.rating_count,
          )
        : formattedResult;

    const paginatedResult =
      sortBy === 'rating'
        ? sortedResult.slice((page - 1) * limit, page * limit)
        : sortedResult;

    const validResult = paginatedResult.map((item) => {
      return {
        id: item.id,
        title: item.title,
        author_name: item.users.username,
        image_path: item.image_path,
        created_at: item.created_at,
        avg_rating: item.avg_rating,
        rating_count: item.rating_count,
      };
    });

    return {
      totalPages,
      currentPage: page,
      totalCount,
      pageSize: limit,
      data: validResult,
    };
  }

  async findOneById(id: string): Promise<recipes> {
    return this.prisma.recipes.findUnique({
      where: {
        id,
        status: { notIn: [RecipeStatus.BLOCKED, RecipeStatus.ARCHIEVED] },
      },
    });
  }

  async findOneFullById(id: string): Promise<RecipeResponseWithUser> {
    const recipe = await this.prisma.recipes.findUnique({
      where: { id },
      include: {
        cuisines: true,
        ratings: {
          select: {
            rating: true,
            id: true,
            user_id: true,
          },
        },
        categories: {
          select: {
            name: true,
          },
        },
        comments: {
          where: {
            status: CommentStatus.ACTIVE,
          },
          select: {
            id: true,
            content: true,
            created_at: true,
            users: {
              select: {
                username: true,
                id: true,
                avatar_url: true,
              },
            },
          },
          orderBy: { created_at: 'desc' },
        },
        users: {
          select: {
            id: true,
            username: true,
            avatar_url: true,
          },
        },
        recipes_ingredients: {
          include: {
            ingredients: {
              select: {
                id: true,
                name: true,
              },
            },
          },
        },
        recipes_tags: {
          include: {
            tags: {
              select: {
                id: true,
                name: true,
                query_key: true,
              },
            },
          },
        },
      },
    });

    if (recipe?.comments) {
      for (const comment of recipe.comments) {
        const userRating = await this.prisma.ratings.findFirst({
          where: {
            user_id: comment.users.id,
            recipe_id: id,
          },
          select: {
            rating: true,
          },
        });

        comment.users['rating'] = userRating?.rating ?? null;
      }
    }

    return recipe;
  }

  async createRecipe(recipe: { user_id: string } & CreateRecipeDto) {
    const { category_name, cuisine_name, tags, ingredients, ...recipeData } =
      recipe;

    const recipeId = await this.prisma.$transaction(async (prisma) => {
      const category = await prisma.categories.findFirst({
        where: {
          name: category_name,
        },
      });

      if (!category) {
        throw new BadRequestException('This category does not exist');
      }

      let cuisine;
      if (cuisine_name) {
        cuisine = await prisma.cuisines.findFirst({
          where: {
            name: cuisine_name,
          },
        });
      }

      const existingTags = await prisma.tags.findMany({
        where: {
          name: {
            in: tags,
          },
        },
      });

      if (existingTags.length !== tags.length) {
        throw new BadRequestException('One or more tags do not exist');
      }

      let created_ingredients;
      try {
        created_ingredients = await Promise.all(
          ingredients.map(async ({ name }) => {
            return prisma.ingredients.upsert({
              where: { name },
              update: {},
              create: { name },
            });
          }),
        );
      } catch (error) {
        console.log(error);
      }

      const created_recipe = await prisma.recipes.create({
        data: {
          ...recipeData,
          status: RecipeStatus.PUBLISHED,
          category_id: category.id,
          cuisine_id: cuisine?.id,
          recipes_tags: {
            create: existingTags.map((tag) => ({
              tag_id: tag.id,
            })),
          },
          recipes_ingredients: {
            create: ingredients.map((ingredient) => ({
              ingredient_id: created_ingredients.find(
                (i) => i.name === ingredient.name,
              ).id,
              quantity: ingredient.quantity,
            })),
          },
        },
      });

      return created_recipe.id;
    });

    if (recipeData.image_path) {
      await this.updateRecipe(recipeId, AuthRole.User, {
        image_path: `/uploads/recipe_${recipeId}.jpg`,
      });
    }

    return recipeId;
  }

  async updateRecipe(
    recipeId: string,
    role: AuthRole,
    payload: UpdateRecipeDto,
  ) {
    let recipe: recipes;
    const user = this.request.user as UserAuthPayload;

    const {
      category_name,
      cuisine_name,
      tags,
      ingredients,
      image_path,
      ...recipeData
    } = payload;

    try {
      recipe = await this.prisma.recipes.findUnique({
        where: { id: recipeId },
      });
    } catch {
      throw new BadRequestException("Recipe doesn't exist");
    }

    this._validateRecipeOwnership(user, recipe.user_id);
    const isRecipeActive = !(
      recipe.status === RecipeStatus.ARCHIEVED ||
      recipe.status === RecipeStatus.BLOCKED
    );

    if (!isRecipeActive && role !== AuthRole.Admin) {
      throw new BadRequestException('You cannot edit this recipe');
    }

    const recipeIdAfterUpdate = await this.prisma.$transaction(
      async (prisma) => {
        let category;
        if (category_name) {
          category = await prisma.categories.findFirst({
            where: {
              name: category_name,
            },
          });

          if (!category) {
            throw new BadRequestException('This category does not exist');
          }
        }

        let cuisine;
        if (cuisine_name) {
          cuisine = await prisma.cuisines.findFirst({
            where: {
              name: cuisine_name,
            },
          });
        }

        let existingTags;
        if (tags) {
          existingTags = await prisma.tags.findMany({
            where: {
              name: {
                in: tags,
              },
            },
          });

          if (existingTags.length !== tags.length) {
            throw new BadRequestException('One or more tags do not exist');
          }
        }

        const created_ingredients = await Promise.all(
          ingredients?.map(async ({ name }) => {
            return prisma.ingredients.upsert({
              where: { name },
              update: {},
              create: { name },
            });
          }),
        );

        const updated_recipe = await prisma.recipes.update({
          where: {
            id: recipeId,
          },
          data: {
            ...recipeData,
            image_path: `/uploads/recipe_${recipeId}.jpg`,
            category_id: category.id,
            cuisine_id: cuisine?.id || null,
            recipes_tags: {
              deleteMany: {},
              create: existingTags.map((tag) => ({
                tag_id: tag.id,
              })),
            },
            recipes_ingredients: {
              deleteMany: {},
              create: ingredients.map((ingredient) => ({
                ingredient_id: created_ingredients.find(
                  (i) => i.name === ingredient.name,
                ).id,
                quantity: ingredient.quantity,
              })),
            },
          },
        });

        return updated_recipe.id;
      },
    );

    return recipeIdAfterUpdate;
  }

  async deleteRecipe(recipe_id: string, role: AuthRole) {
    let recipe: recipes;
    const user = this.request.user as UserAuthPayload;

    try {
      recipe = await this.prisma.recipes.findUnique({
        where: { id: recipe_id },
      });
    } catch {
      throw new BadRequestException("Recipe doesn't exist");
    }

    this._validateRecipeOwnership(user, recipe.user_id);
    const isRecipeActive = !(
      recipe.status === RecipeStatus.ARCHIEVED ||
      recipe.status === RecipeStatus.BLOCKED
    );

    if (!isRecipeActive && role !== AuthRole.Admin) {
      throw new BadRequestException('You cannot delete this recipe');
    }

    return this.prisma.$transaction(async (prisma) => {
      await this._deleteFavouritesByRecipeId(prisma, recipe_id);

      if (role !== AuthRole.Admin) {
        return await this._archieveRecipeById(prisma, recipe_id);
      }

      await this._deleteRatingsByRecipeId(prisma, recipe_id);

      await this._deleteCommentsByRecipeId(prisma, recipe_id);

      return await this._deleteRecipeById(prisma, recipe_id);
    });
  }

  private async _validateRecipeOwnership(
    user: UserAuthPayload,
    owner_id: string,
  ) {
    if (user.role === AuthRole.User && owner_id !== user.id) {
      throw new BadRequestException('You do not own this recipe');
    }
  }

  private async _deleteFavouritesByRecipeId(
    prisma: Prisma.TransactionClient,
    recipe_id: string,
  ) {
    prisma.favorites.deleteMany({
      where: { recipe_id },
    });
  }

  private async _archieveRecipeById(
    prisma: Prisma.TransactionClient,
    id: string,
  ) {
    return prisma.recipes.update({
      where: { id },
      data: { status: RecipeStatus.ARCHIEVED },
    });
  }

  private async _deleteRatingsByRecipeId(
    prisma: Prisma.TransactionClient,
    recipe_id: string,
  ) {
    prisma.ratings.deleteMany({
      where: { recipe_id },
    });
  }

  private async _deleteCommentsByRecipeId(
    prisma: Prisma.TransactionClient,
    recipe_id: string,
  ) {
    prisma.comments.deleteMany({
      where: { recipe_id },
    });
  }

  private async _deleteRecipeById(
    prisma: Prisma.TransactionClient,
    id: string,
  ) {
    return prisma.recipes.delete({
      where: { id },
    });
  }
}
