import { AuthModule } from '@auth/auth.module';
import { AuthService } from '@auth/auth.service';
import { CommonModule } from '@common/common.module';
import { BaseFilterService } from '@common/filters/base-filter.service';
import { DatabaseModule } from '@database/database.module';
import { MiddlewareConsumer, Module } from '@nestjs/common';
import { RecipeController } from '@resources/recipes/recipe.controller';
import { RecipeService } from '@resources/recipes/recipe.service';
import { UserMiddleware } from 'app/middlewares/UserMiddleware';
import { SpoonacularService } from 'app/spoonacular/spoonacular.service';

@Module({
  imports: [DatabaseModule, AuthModule, CommonModule],
  controllers: [RecipeController],
  providers: [
    RecipeService,
    BaseFilterService,
    SpoonacularService,
    AuthService,
  ],
})
export class RecipeModule {
  configure(consumer: MiddlewareConsumer) {
    consumer.apply(UserMiddleware).forRoutes('*'); // Применить для всех маршрутов
  }
}
