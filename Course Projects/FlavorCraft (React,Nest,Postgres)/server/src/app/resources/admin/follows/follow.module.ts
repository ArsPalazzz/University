import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { FollowAdminController } from './follow.controller';
import { FollowAdminService } from './follow.service';
import { AuthService } from '@auth/auth.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [FollowAdminController],
  providers: [FollowAdminService, AuthService],
})
export class FollowAdminModule {}
