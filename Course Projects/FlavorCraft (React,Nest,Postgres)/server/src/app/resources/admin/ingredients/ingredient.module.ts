import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { SpoonacularService } from 'app/spoonacular/spoonacular.service';
import { IngredientAdminService } from './ingredient.service';
import { IngredientAdminController } from './ingredient.controller';
import { AuthService } from '@auth/auth.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [IngredientAdminController],
  providers: [IngredientAdminService, SpoonacularService, AuthService],
  exports: [SpoonacularService],
})
export class IngredientAdminModule {}
