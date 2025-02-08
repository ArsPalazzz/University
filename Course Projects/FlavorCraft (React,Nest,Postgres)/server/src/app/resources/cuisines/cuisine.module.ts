import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { CuisineController } from './cuisine.controller';
import { AuthService } from '@auth/auth.service';
import { RatingService } from '@resources/ratings/rating.service';
import { CuisineService } from './cuisine.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [CuisineController],
  providers: [CuisineService, RatingService, AuthService],
})
export class CuisineModule {}
