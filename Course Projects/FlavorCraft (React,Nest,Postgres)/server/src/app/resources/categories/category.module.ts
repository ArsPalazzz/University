import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { CategoryController } from './category.controller';
import { AuthService } from '@auth/auth.service';
import { RatingService } from '@resources/ratings/rating.service';
import { CategoryService } from './category.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [CategoryController],
  providers: [CategoryService, RatingService, AuthService],
})
export class CategoryModule {}
