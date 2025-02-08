import { Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { categories } from '@prisma/client';

@Injectable()
export class CategoryService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<categories[]> {
    return this.prisma.categories.findMany();
  }
}
