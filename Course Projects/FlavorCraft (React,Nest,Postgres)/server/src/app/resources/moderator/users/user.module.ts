import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { UserModeratorService } from './user.service';
import { UserModeratorController } from './user.controller';
import { AuthService } from '@auth/auth.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [UserModeratorController],
  providers: [UserModeratorService, AuthService],
})
export class UserModeratorModule {}
