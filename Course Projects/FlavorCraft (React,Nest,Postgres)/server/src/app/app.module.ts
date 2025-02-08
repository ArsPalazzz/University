import { Module } from '@nestjs/common';
import { UserService } from '@resources/users/user.service';
import { DatabaseModule } from '@database/database.module';
import { PrismaService } from '@database/prisma.service';
import { UserModule } from '@resources/users/user.module';
import { AuthModule } from '@auth/auth.module';
import { RecipeModule } from '@resources/recipes/recipe.module';
import { RatingModule } from '@resources/ratings/rating.module';
import { FollowModule } from '@resources/follows/follow.module';
import { FavouriteModule } from '@resources/favourites/favourite.module';
import { CommentModule } from '@resources/comments/comment.module';
import { BaseFilterService } from '@common/filters/base-filter.service';
import { UserModeratorModule } from '@resources/moderator/users/user.module';
import { CommentModeratorModule } from '@resources/moderator/comments/comments.module';
import { RecipeModeratorModule } from '@resources/moderator/recipes/recipe.module';
import { UserAdminModule } from '@resources/admin/users/user.module';
import { FollowAdminModule } from '@resources/admin/follows/follow.module';
import { CategoryModeratorModule } from '@resources/moderator/categories/category.module';
import { IngredientModeratorModule } from '@resources/moderator/ingredients/ingredient.module';
import { IngredientModule } from '@resources/ingredients/ingredient.module';
import { ConfigModule } from '@nestjs/config';
import { ServeStaticModule } from '@nestjs/serve-static';
import { join } from 'path';
import { UploadModule } from './files/upload.module';
import { CategoryModule } from '@resources/categories/category.module';
import { TagModule } from '@resources/tags/tag.module';
import { IngredientAdminModule } from '@resources/admin/ingredients/ingredient.module';
import { CuisineModule } from '@resources/cuisines/cuisine.module';
import { CategoryAdminModule } from '@resources/admin/categories/category.module';
import { RecipeAdminModule } from '@resources/admin/recipes/recipe.module';

@Module({
  imports: [
    ConfigModule.forRoot({
      isGlobal: true,
    }),
    ServeStaticModule.forRoot({
      rootPath: join(__dirname, '..', 'assets'), // Путь к папке с файлами
      serveRoot: '/assets', // URL, по которому доступны файлы
    }),
    AuthModule,
    DatabaseModule,
    UserModule,
    RecipeModule,
    RatingModule,
    FollowModule,
    IngredientModule,
    FavouriteModule,
    CategoryModule,
    TagModule,
    CuisineModule,
    CommentModule,
    UserModeratorModule,
    CommentModeratorModule,
    RecipeModeratorModule,
    CategoryModeratorModule,
    IngredientModeratorModule,
    UserAdminModule,
    IngredientAdminModule,
    FollowAdminModule,
    CategoryAdminModule,
    RecipeAdminModule,
    UploadModule,
  ],
  providers: [UserService, PrismaService, BaseFilterService],
})
export class AppModule {}
