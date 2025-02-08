import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { favorites, followings, recipes } from '@prisma/client';
import { ToggleFavouriteDto } from './dto/create-favourite.dto';
import { RecipeStatus } from '@common/constants/recipe.const';
import { Decimal } from '@prisma/client/runtime/library';

@Injectable()
export class FavouriteService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<favorites[]> {
    return this.prisma.favorites.findMany();
  }

  async isExistRecipeByRecipeId(
    recipe_id: string,
    user_id: string,
  ): Promise<boolean> {
    const count = await this.prisma.favorites.count({
      where: {
        user_id,
        recipe_id,
      },
    });
    return count > 0 ? true : false;
  }

  async findAllByUserId(user_id: string): Promise<
    (favorites & {
      recipes: {
        id: string;
        user_id: string;
        avg_rating: Decimal;
        title: string;
        image_path: string;
        created_at: Date;
        ratings: { rating: number }[]; // Здесь ratings обязательно
      };
    })[]
  > {
    return this.prisma.favorites.findMany({
      where: {
        user_id,
      },
      include: {
        recipes: {
          select: {
            id: true,
            user_id: true,
            avg_rating: true,
            title: true,
            image_path: true,
            created_at: true,
            ratings: {
              select: {
                rating: true,
              },
            },
          },
        },
      },
    });
  }

  async findOneById(id: number): Promise<followings> {
    return this.prisma.followings.findUnique({
      where: { id },
    });
  }

  async toggleFavourite(favourite: { user_id: string } & ToggleFavouriteDto) {
    const { user_id, recipe_id } = favourite;

    let recipe: recipes;

    try {
      recipe = await this.prisma.recipes.findUnique({
        where: {
          id: recipe_id,
        },
      });
    } catch {
      throw new BadRequestException("This recipe doesn't exists");
    }

    // if (recipe.user_id === user_id) {
    //   throw new BadRequestException(
    //     'You cannot add your own recipes to favorites',
    //   );
    // }

    // if (recipe.status !== RecipeStatus.PUBLISHED) {
    //   throw new BadRequestException('You cannot add this recipe to favorites');
    // }

    const favouriteFromDB = await this.prisma.favorites.findFirst({
      where: {
        user_id,
        recipe_id,
      },
    });

    if (favouriteFromDB) {
      await this.prisma.favorites.delete({
        where: {
          id: favouriteFromDB.id,
        },
      });
    } else {
      await this.prisma.favorites.create({
        data: {
          user_id,
          recipe_id,
        },
      });
    }

    return true;
  }

  // async deleteFavourite({ user_id, favourite_id }: DeleteFavouriteInput) {
  //   let favourite: favorites;

  //   try {
  //     favourite = await this.prisma.favorites.findFirst({
  //       where: {
  //         id: favourite_id,
  //       },
  //     });
  //   } catch {
  //     throw new BadRequestException(
  //       "You haven't add this recipe to your favourites",
  //     );
  //   }

  //   if (favourite.user_id === user_id) {
  //     throw new BadRequestException(
  //       'You cannot remove your own recipes to favorites',
  //     );
  //   }

  //   return await this.prisma.favorites.delete({
  //     where: {
  //       id: favourite_id,
  //     },
  //   });
  // }
}
