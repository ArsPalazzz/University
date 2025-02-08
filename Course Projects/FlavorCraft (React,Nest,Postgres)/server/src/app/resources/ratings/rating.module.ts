import { AuthModule } from '@auth/auth.module';
import { AuthService } from '@auth/auth.service';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { RatingController } from '@resources/ratings/rating.controller';
import { RatingService } from '@resources/ratings/rating.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [RatingController],
  providers: [RatingService, AuthService],
})
export class RatingModule {}
