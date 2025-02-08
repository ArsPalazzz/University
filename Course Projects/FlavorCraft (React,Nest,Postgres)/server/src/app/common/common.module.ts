import { Module } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { BaseFilterService } from './filters/base-filter.service';

@Module({
  providers: [PrismaService, BaseFilterService],
  exports: [PrismaService, BaseFilterService],
})
export class CommonModule {}
