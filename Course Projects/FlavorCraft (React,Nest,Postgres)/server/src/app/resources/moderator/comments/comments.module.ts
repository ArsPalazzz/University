import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { CommentModeratorService } from './comments.service';
import { CommentModeratorController } from './comments.controller';
import { AuthService } from '@auth/auth.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [CommentModeratorController],
  providers: [CommentModeratorService, AuthService],
})
export class CommentModeratorModule {}
