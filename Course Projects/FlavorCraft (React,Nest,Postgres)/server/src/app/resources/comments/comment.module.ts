import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { CommentService } from './comment.service';
import { CommentController } from './comment.controller';
import { AuthService } from '@auth/auth.service';
import { RatingService } from '@resources/ratings/rating.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [CommentController],
  providers: [CommentService, RatingService, AuthService],
})
export class CommentModule {}
