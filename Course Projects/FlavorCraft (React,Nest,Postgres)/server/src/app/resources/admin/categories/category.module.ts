import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { SpoonacularService } from 'app/spoonacular/spoonacular.service';
import { AuthService } from '@auth/auth.service';
import { CategoryAdminController } from './category.controller';
import { CategoryAdminService } from './category.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [CategoryAdminController],
  providers: [CategoryAdminService, SpoonacularService, AuthService],
  exports: [SpoonacularService],
})
export class CategoryAdminModule {}
