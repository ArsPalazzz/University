import { AuthModule } from '@auth/auth.module';
import { AuthService } from '@auth/auth.service';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { FollowController } from '@resources/follows/follow.controller';
import { FollowService } from '@resources/follows/follow.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [FollowController],
  providers: [FollowService, AuthService],
})
export class FollowModule {}
