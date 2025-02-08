import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { TagController } from './tag.controller';
import { AuthService } from '@auth/auth.service';
import { RatingService } from '@resources/ratings/rating.service';
import { TagService } from './tag.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [TagController],
  providers: [TagService, RatingService, AuthService],
})
export class TagModule {}
