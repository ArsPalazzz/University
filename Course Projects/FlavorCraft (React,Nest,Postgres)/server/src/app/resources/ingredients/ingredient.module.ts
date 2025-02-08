import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { SpoonacularService } from 'app/spoonacular/spoonacular.service';
import { IngredientService } from './ingredient.service';
import { IngredientController } from './ingredient.controller';
import { AuthService } from '@auth/auth.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [IngredientController],
  providers: [IngredientService, SpoonacularService, AuthService],
  exports: [SpoonacularService],
})
export class IngredientModule {}
