import { Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { tags } from '@prisma/client';

@Injectable()
export class TagService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<tags[]> {
    return this.prisma.tags.findMany();
  }
}
