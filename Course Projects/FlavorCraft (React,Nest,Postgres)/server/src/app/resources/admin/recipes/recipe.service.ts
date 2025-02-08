import { BadRequestException, Inject, Injectable, Scope } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { categories, Prisma, recipes } from '@prisma/client';
import { RecipeResponseWithUser } from '@resources/recipes/dto/recipe-response-with-user';
import { CreateRecipeDto } from '@resources/recipes/dto/create-recipe.dto';
import { RecipeStatus } from '@common/constants/recipe.const';
import { AuthRole } from '@common/constants/auth.const';
import { UpdateRecipeDto } from '@resources/recipes/dto/update-recipe.dto';
import { UserAuthPayload } from '@common/types/user.types';
import { REQUEST } from '@nestjs/core';
import { Request } from 'express';

@Injectable({ scope: Scope.REQUEST })
export class RecipeAdminService {
  constructor(
    private prisma: PrismaService,
    @Inject(REQUEST) private readonly request: Request,
  ) {}

  async findAll(): Promise<recipes[]> {
    return this.prisma.recipes.findMany();
  }

  async findOneById(id: string): Promise<recipes> {
    return this.prisma.recipes.findUnique({
      where: {
        id,
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

      const created_ingredients = await Promise.all(
        ingredients.map(async ({ name }) => {
          return prisma.ingredients.upsert({
            where: { name },
            update: {},
            create: { name },
          });
        }),
      );

      try {
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
      } catch (err) {
        console.log(err);
      }

      //return created_recipe.id;
    });

    // if (recipeData.image_path) {
    //   await this.updateRecipe(recipeId, {
    //     image_path: `/uploads/recipe_${recipeId}.jpg`,
    //   });
    // }

    // return recipeId;
  }

  async updateRecipe(recipeId: string, payload: UpdateRecipeDto) {
    let recipe: recipes;

    const { category_name, cuisine_name, tags, ingredients, ...recipeData } =
      payload;

    try {
      recipe = await this.prisma.recipes.findUnique({
        where: { id: recipeId },
      });
    } catch {
      throw new BadRequestException("Recipe doesn't exist");
    }

    if (!recipe) {
      throw new BadRequestException("Recipe doesn't exist");
    }

    const recipeIdAfterUpdate = await this.prisma.$transaction(
      async (prisma) => {
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

        const created_ingredients = await Promise.all(
          ingredients.map(async ({ name }) => {
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

  async deleteRecipe(recipe_id: string) {
    try {
      await this.prisma.recipes.findUnique({
        where: { id: recipe_id },
      });
    } catch {
      throw new BadRequestException("Recipe doesn't exist");
    }

    return this.prisma.$transaction(async (prisma) => {
      await this._deleteFavouritesByRecipeId(prisma, recipe_id);

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
