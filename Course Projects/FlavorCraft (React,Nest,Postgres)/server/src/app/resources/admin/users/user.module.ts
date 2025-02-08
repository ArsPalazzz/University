import { Module } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { AuthModule } from '@auth/auth.module';
import { BaseFilterService } from '@common/filters/base-filter.service';
import { CommonModule } from '@common/common.module';
import { UserAdminController } from './user.controller';
import { UserAdminService } from './user.service';
import { AuthService } from '@auth/auth.service';

@Module({
  imports: [AuthModule, CommonModule],
  controllers: [UserAdminController],
  providers: [UserAdminService, PrismaService, BaseFilterService, AuthService],
})
export class UserAdminModule {}
