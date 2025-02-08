import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { ingredients } from '@prisma/client';

@Injectable()
export class IngredientAdminService {
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
      throw new BadRequestException('This ingredient is already exitsts');
    }

    return await this.prisma.ingredients.create({
      data: {
        name: ingredientName,
      },
    });
  }

  async updateIngredient(id: number, ingredientName: string) {
    const ingredient = await this.prisma.ingredients.count({
      where: { id },
    });

    if (!ingredient) {
      throw new BadRequestException('This ingredient does not exists');
    }

    return await this.prisma.ingredients.update({
      where: { id },
      data: {
        name: ingredientName,
      },
    });
  }

  async deleteIngredient(ingredientId: number) {
    const ingredient = await this.prisma.ingredients.count({
      where: { id: ingredientId },
    });

    if (!ingredient) {
      throw new BadRequestException('This ingredient does not exists');
    }

    return await this.prisma.ingredients.delete({
      where: { id: ingredientId },
    });
  }
}
