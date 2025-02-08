import { PrismaService } from '@database/prisma.service';
import { FilterOptions } from './filter-options.interface';
import { Injectable } from '@nestjs/common';

@Injectable()
export class BaseFilterService {
  constructor(private readonly prisma: PrismaService) {}

  async filter(
    modelName: string, // Название модели в Prisma
    options: FilterOptions,
  ) {
    const {
      search,
      searchColumn,
      sortBy = 'created_at',
      order = 'desc',
      filters = {},
      limit,
      tags,
    } = options;

    const where: any = { ...filters };

    // Полнотекстовый поиск
    if (search) {
      where[searchColumn] = { contains: search, mode: 'insensitive' };
    }

    if (tags && tags.length > 0) {
      where.recipes_tags = {
        some: {
          tags: {
            query_key: { in: tags },
          },
        },
      };
    }

    return this.prisma[modelName].findMany({
      where,
      orderBy: { [sortBy]: order },
      take: limit ? limit : undefined,
    });
  }
}
