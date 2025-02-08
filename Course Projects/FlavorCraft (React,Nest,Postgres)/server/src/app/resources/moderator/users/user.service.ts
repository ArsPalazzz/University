import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { Prisma, users } from '@prisma/client';
import { BlockUserDto } from './dto/block-user.dto';
import { RecipeStatus } from '@common/constants/recipe.const';

@Injectable()
export class UserModeratorService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<users[]> {
    return this.prisma.users.findMany();
  }

  async findAllByUserId(user_id: string): Promise<users[]> {
    return this.prisma.users.findMany({
      where: { id: user_id },
    });
  }

  async findOneById(id: string): Promise<users> {
    return this.prisma.users.findUnique({
      where: { id },
    });
  }

  async findAllById(id: string): Promise<users[]> {
    return this.prisma.users.findMany({
      where: { id },
    });
  }

  async blockUser(blockInfo: { user_id: string } & BlockUserDto) {
    const { user_id, reason } = blockInfo;

    if (!user_id) {
      throw new BadRequestException('You have to pass user id');
    }

    return await this.prisma.$transaction(async (prisma) => {
      const user = await this.findOneById(user_id);

      if (!user) {
        throw new BadRequestException("User doesn't exists");
      }

      const usersRecipes = await this._getAllRecipesByUserId(user_id);
      await this._blockAllRecipesByUserId(user_id, prisma);

      const arhievedIds = usersRecipes.map((recipe) => recipe.id);
      await this._deleteFavouritesByRecipeIds(arhievedIds, prisma);

      await this._addUserToBanned({ user_id, reason }, prisma);

      return await prisma.users.update({
        where: { id: user_id },
        data: { is_blocked: true },
      });
    });
  }

  private async _getAllRecipesByUserId(user_id: string) {
    try {
      return await this.prisma.recipes.findMany({
        where: { user_id },
      });
    } catch {
      throw new BadRequestException("Any of these recipes doesn't exists");
    }
  }

  private async _blockAllRecipesByUserId(
    user_id: string,
    prisma: Prisma.TransactionClient,
  ) {
    try {
      return await prisma.recipes.updateMany({
        where: { user_id },
        data: { status: RecipeStatus.BLOCKED },
      });
    } catch {
      throw new BadRequestException('Something went wrong');
    }
  }

  private async _deleteFavouritesByRecipeIds(
    recipeIds: string[],
    prisma: Prisma.TransactionClient,
  ) {
    try {
      return await prisma.favorites.deleteMany({
        where: {
          recipe_id: {
            in: recipeIds,
          },
        },
      });
    } catch {
      throw new BadRequestException('Something went wrong');
    }
  }

  private async _addUserToBanned(
    blockInfo: { user_id: string; reason: string },
    prisma: Prisma.TransactionClient,
  ) {
    try {
      return await prisma.banned_users.create({
        data: blockInfo,
      });
    } catch {
      throw new BadRequestException('Something went wrong');
    }
  }
}
