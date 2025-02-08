import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { categories } from '@prisma/client';
import { CreateCategoryDto } from './dto/create_category.dto';

@Injectable()
export class CategoryModeratorService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<categories[]> {
    return this.prisma.categories.findMany();
  }

  async findOneById(id: number): Promise<categories> {
    return this.prisma.categories.findUnique({
      where: { id },
    });
  }

  async createCategory(
    createCategoryDto: CreateCategoryDto,
  ): Promise<categories> {
    const isCategoryExist = !!(await this._getCategoryByName(
      createCategoryDto.name,
    ));

    if (isCategoryExist) {
      throw new BadRequestException('Category with this name is already exist');
    }

    return this.prisma.categories.create({
      data: createCategoryDto,
    });
  }

  async deleteCategory(id: number): Promise<categories> {
    const isCategoryExist = !!(await this._getCategoryById(id));

    if (!isCategoryExist) {
      throw new BadRequestException("This category doesn't exist");
    }

    return this.prisma.categories.delete({
      where: { id },
    });
  }

  private async _getCategoryById(id: number) {
    try {
      return await this.prisma.categories.findFirst({
        where: { id },
      });
    } catch {
      throw new BadRequestException("You haven't added this category");
    }
  }

  private async _getCategoryByName(name: string) {
    return this.prisma.categories.count({
      where: { name },
    });
  }
}
