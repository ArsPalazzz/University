import { Module } from '@nestjs/common';
import { UploadController } from './upload.controller';
import { UserService } from '@resources/users/user.service';
import { RecipeService } from '@resources/recipes/recipe.service';
import { PrismaService } from '@database/prisma.service';
import { BaseFilterService } from '@common/filters/base-filter.service';

@Module({
  controllers: [UploadController], // Контроллеры указываются здесь
  providers: [UserService, RecipeService, PrismaService, BaseFilterService], // Сервисы, если есть, указываются здесь
  exports: [UserService], // Экспортируемые провайдеры, если есть
})
export class UploadModule {}
