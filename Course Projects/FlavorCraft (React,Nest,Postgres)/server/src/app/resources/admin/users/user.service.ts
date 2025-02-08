import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { Prisma, users } from '@prisma/client';
import { FilterUsersDto } from './dto/filter-users.dto';
import { BaseFilterService } from '@common/filters/base-filter.service';

@Injectable()
export class UserAdminService {
  constructor(
    private prisma: PrismaService,
    private readonly baseFilterService: BaseFilterService,
  ) {}

  async filterAll(filterDto: FilterUsersDto) {
    const { search, role, sortBy, order } = filterDto;
    const searchColumn = 'username';

    const filters: Record<string, any> = {};

    if (role) filters.role = role;

    return this.baseFilterService.filter('users', {
      search,
      searchColumn,
      sortBy,
      order,
      filters,
    });
  }

  async findOneById(id: string): Promise<users> {
    return this.prisma.users.findUnique({
      where: { id },
    });
  }

  async deleteOneById(id: string): Promise<users> {
    if (!id) {
      throw new BadRequestException('Id is undefined');
    }

    const user = this.prisma.users.findUnique({
      where: { id },
    });

    if (!user) {
      throw new BadRequestException("User doesn't exist");
    }

    return this.prisma.$transaction(async (prisma) => {
      await this._deleteFavouritesByRecipeIds(prisma, id);

      await this._deleteFavouritesByUserId(prisma, id);

      await this._deleteRecipesByUserId(prisma, id);

      await this._deleteBannedUsersByUserId(prisma, id);

      await this._deleteRatingsByUserId(prisma, id);

      await this._deleteCommentsByUserId(prisma, id);

      const deletedUser = await this._deleteUserById(prisma, id);

      return deletedUser;
    });
  }

  private async _deleteUserById(prisma: Prisma.TransactionClient, id: string) {
    return prisma.users.delete({
      where: { id },
    });
  }

  private async _deleteFavouritesByRecipeIds(
    prisma: Prisma.TransactionClient,
    user_id: string,
  ) {
    return prisma.favorites.deleteMany({
      where: { user_id },
    });
  }

  private async _deleteFavouritesByUserId(
    prisma: Prisma.TransactionClient,
    user_id: string,
  ) {
    const userRecipeIds = await prisma.recipes.findMany({
      where: { user_id },
      select: { id: true },
    });

    const recipeIds = userRecipeIds.map((recipe) => recipe.id);

    await prisma.favorites.deleteMany({
      where: {
        recipe_id: { in: recipeIds },
      },
    });
  }

  private async _deleteRecipesByUserId(
    prisma: Prisma.TransactionClient,
    user_id: string,
  ) {
    return prisma.recipes.deleteMany({
      where: {
        user_id,
      },
    });
  }

  private async _deleteBannedUsersByUserId(
    prisma: Prisma.TransactionClient,
    user_id: string,
  ) {
    return prisma.banned_users.deleteMany({
      where: {
        user_id,
      },
    });
  }

  private async _deleteRatingsByUserId(
    prisma: Prisma.TransactionClient,
    user_id: string,
  ) {
    return prisma.ratings.deleteMany({
      where: { user_id },
    });
  }

  private async _deleteCommentsByUserId(
    prisma: Prisma.TransactionClient,
    user_id: string,
  ) {
    return prisma.comments.deleteMany({
      where: { user_id },
    });
  }
}
