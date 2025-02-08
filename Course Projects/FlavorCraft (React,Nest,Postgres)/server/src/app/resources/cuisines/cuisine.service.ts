import { Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { categories, cuisines } from '@prisma/client';

@Injectable()
export class CuisineService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<cuisines[]> {
    return this.prisma.cuisines.findMany();
  }
}
