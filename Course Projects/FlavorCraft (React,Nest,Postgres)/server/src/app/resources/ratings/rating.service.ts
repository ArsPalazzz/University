import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { ratings, recipes } from '@prisma/client';
import { RecipeStatus } from '@common/constants/recipe.const';
import { CreateRatingDto } from './dto/create-rating.dto';
import { UpdateRatingDto } from './dto/update-rating.dto';

@Injectable()
export class RatingService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<ratings[]> {
    return this.prisma.ratings.findMany();
  }

  async findOneById(id: number): Promise<ratings> {
    return this.prisma.ratings.findUnique({
      where: { id },
    });
  }

  async findOneByUserIdAndRecipeId({
    userId,
    recipeId,
  }: {
    userId: string;
    recipeId: string;
  }): Promise<boolean> {
    const count = await this.prisma.ratings.count({
      where: { user_id: userId, recipe_id: recipeId },
    });

    return !!count;
  }

  async createRating(rating: CreateRatingDto & { user_id: string }) {
    const { user_id, recipe_id, rating: ratingNumber } = rating;

    let recipe: recipes;

    try {
      recipe = await this.prisma.recipes.findUnique({
        where: { id: rating.recipe_id },
      });
    } catch {
      throw new BadRequestException("This recipe doesn't exist");
    }

    // if (recipe.user_id === user_id) {
    //   throw new BadRequestException('You cannot rate your recipes');
    // }

    // if (recipe.status !== RecipeStatus.PUBLISHED) {
    //   throw new BadRequestException('You cannot rate this recipe');
    // }

    const exists = !!(await this.prisma.ratings.count({
      where: { user_id, recipe_id },
    }));

    if (exists) {
      throw new BadRequestException('You have already rated this recipe');
    }

    return await this.prisma.ratings.create({
      data: {
        user_id,
        rating: ratingNumber,
        recipe_id: recipe_id as never,
      },
    });
  }

  async updateRating(ratingId: number, payload: UpdateRatingDto) {
    let rating: ratings;
    let recipe: recipes;

    try {
      rating = await this.prisma.ratings.findUnique({
        where: { id: ratingId },
      });
    } catch {
      throw new BadRequestException("You haven't rated this recipe");
    }

    try {
      recipe = await this.prisma.recipes.findUnique({
        where: { id: rating.recipe_id },
      });
    } catch {
      throw new BadRequestException("This recipe doesn't exist");
    }

    if (recipe.status !== RecipeStatus.PUBLISHED) {
      throw new BadRequestException('You cannot rate this recipe');
    }

    return await this.prisma.ratings.update({
      where: { id: ratingId },
      data: payload,
    });
  }
}
