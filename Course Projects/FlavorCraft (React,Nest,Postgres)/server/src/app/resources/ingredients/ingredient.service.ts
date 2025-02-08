import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { ingredients } from '@prisma/client';

@Injectable()
export class IngredientService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<ingredients[]> {
    return this.prisma.ingredients.findMany();
  }

  async findOneByName(name: string): Promise<ingredients> {
    return this.prisma.ingredients.findUnique({
      where: { name },
    });
  }

  async createIngredient(ingredientName: string) {
    const ingredient = await this.prisma.ingredients.count({
      where: { name: ingredientName },
    });

    if (ingredient) {
      throw new BadRequestException(
        'Ingredient with this name is already exists',
      );
    }

    return await this.prisma.ingredients.create({
      data: {
        name: ingredientName,
      },
    });
  }
}
