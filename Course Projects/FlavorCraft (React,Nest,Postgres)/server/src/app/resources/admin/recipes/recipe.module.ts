import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { SpoonacularService } from 'app/spoonacular/spoonacular.service';
import { AuthService } from '@auth/auth.service';
import { RecipeAdminController } from './recipe.controller';
import { RecipeAdminService } from './recipe.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [RecipeAdminController],
  providers: [RecipeAdminService, SpoonacularService, AuthService],
  exports: [SpoonacularService],
})
export class RecipeAdminModule {}
