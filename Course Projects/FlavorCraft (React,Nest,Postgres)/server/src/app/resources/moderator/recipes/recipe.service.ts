import { RecipeStatus } from '@common/constants/recipe.const';
import { PrismaService } from '@database/prisma.service';
import { BadRequestException, Injectable } from '@nestjs/common';
import { Prisma, recipes } from '@prisma/client';

@Injectable()
export class RecipeModeratorService {
  constructor(private prisma: PrismaService) {}

  async findAllPending(): Promise<recipes[]> {
    return this.prisma.recipes.findMany({
      where: { status: RecipeStatus.PENDING },
    });
  }

  async acceptRecipe(recipeId: string): Promise<recipes> {
    return this.prisma.recipes.update({
      where: { id: recipeId },
      data: { status: RecipeStatus.PUBLISHED },
    });
  }

  async declineRecipe(recipeId: string): Promise<recipes> {
    return this.prisma.recipes.update({
      where: { id: recipeId },
      data: { status: RecipeStatus.DECLINED },
    });
  }

  async blockRecipe(recipe_id: string): Promise<recipes> {
    if (!recipe_id) {
      throw new BadRequestException('Recipe id is undefined');
    }

    const recipe = await this._getRecipeById(recipe_id);
    if (!recipe) {
      throw new BadRequestException("Recipe doesn't exist");
    }

    return this.prisma.$transaction(async (prisma) => {
      await this._deleteCommentsByRecipeId(prisma, recipe_id);

      await this._deleteFavouritesByRecipeId(prisma, recipe_id);

      const blockedRecipe = await this._blockRecipeById(prisma, recipe_id);

      return blockedRecipe;
    });
  }

  private _getRecipeById(id: string) {
    return this.prisma.recipes.findUnique({
      where: { id },
    });
  }

  private async _deleteCommentsByRecipeId(
    prisma: Prisma.TransactionClient,
    id: string,
  ) {
    await prisma.comments.deleteMany({
      where: { recipe_id: id },
    });
  }

  private async _deleteFavouritesByRecipeId(
    prisma: Prisma.TransactionClient,
    id: string,
  ) {
    await prisma.favorites.deleteMany({
      where: { recipe_id: id },
    });
  }

  private async _blockRecipeById(
    prisma: Prisma.TransactionClient,
    id: string,
  ): Promise<recipes> {
    return await prisma.recipes.update({
      where: { id },
      data: { status: RecipeStatus.BLOCKED },
    });
  }
}
