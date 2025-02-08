import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { categories } from '@prisma/client';

@Injectable()
export class CategoryAdminService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<categories[]> {
    return this.prisma.categories.findMany();
  }

  async findOneByName(name: string): Promise<categories> {
    return this.prisma.categories.findFirst({
      where: { name },
    });
  }

  async createCategory(categoryName: string) {
    const category = await this.prisma.categories.count({
      where: { name: categoryName },
    });

    if (category) {
      throw new BadRequestException('This category is already exists');
    }

    return await this.prisma.categories.create({
      data: {
        name: categoryName,
      },
    });
  }

  async updateCategory(id: number, categoryName: string) {
    const category = await this.prisma.categories.count({
      where: { id },
    });

    if (!category) {
      throw new BadRequestException('This category does not exists');
    }

    return await this.prisma.categories.update({
      where: { id },
      data: {
        name: categoryName,
      },
    });
  }

  async deleteCategory(categoryId: number) {
    const category = await this.prisma.categories.count({
      where: { id: categoryId },
    });

    if (!category) {
      throw new BadRequestException('This category does not exists');
    }

    return await this.prisma.categories.delete({
      where: { id: categoryId },
    });
  }
}
