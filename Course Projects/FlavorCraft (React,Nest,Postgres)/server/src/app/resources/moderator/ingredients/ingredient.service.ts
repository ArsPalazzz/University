import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { ingredients, Prisma } from '@prisma/client';
import { CreateIngredientDto } from './dto/create_ingredient.dto';

@Injectable()
export class IngredientModeratorService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<ingredients[]> {
    return this.prisma.ingredients.findMany();
  }

  async findOneById(id: number): Promise<ingredients> {
    return this.prisma.ingredients.findUnique({
      where: { id },
    });
  }

  async createIngredient(
    createIngredientDto: CreateIngredientDto,
  ): Promise<ingredients> {
    const isIngredientExist = !!(await this._getIngredientByName(
      createIngredientDto.name,
    ));

    if (isIngredientExist) {
      throw new BadRequestException(
        'Ingredient with this name is already exist',
      );
    }

    return this.prisma.ingredients.create({
      data: createIngredientDto,
    });
  }

  async deleteIngredient(id: number): Promise<ingredients> {
    const isIngredientExist = !!(await this._getIngredientById(id));

    if (!isIngredientExist) {
      throw new BadRequestException("This ingredient doesn't exist");
    }

    return this.prisma.$transaction(async (prisma) => {
      await this._deleteFromIngredientsRecipesByIngredientId(prisma, id);

      return await this.prisma.ingredients.delete({
        where: { id },
      });
    });
  }

  private async _getIngredientById(id: number) {
    try {
      return await this.prisma.ingredients.findFirst({
        where: { id },
      });
    } catch {
      throw new BadRequestException("You haven't added this ingredient");
    }
  }

  private async _getIngredientByName(name: string) {
    return this.prisma.ingredients.count({
      where: { name },
    });
  }

  private async _deleteFromIngredientsRecipesByIngredientId(
    prisma: Prisma.TransactionClient,
    id: number,
  ) {
    return prisma.recipes_ingredients.deleteMany({
      where: { ingredient_id: id },
    });
  }
}
