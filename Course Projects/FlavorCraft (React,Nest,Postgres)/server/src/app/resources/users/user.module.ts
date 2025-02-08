import { Module } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { UserController } from '@resources/users/user.controller';
import { UserService } from '@resources/users/user.service';
import { AuthModule } from '@auth/auth.module';
import { BaseFilterService } from '@common/filters/base-filter.service';
import { CommonModule } from '@common/common.module';
import { AuthService } from '@auth/auth.service';

@Module({
  imports: [AuthModule, CommonModule],
  controllers: [UserController],
  providers: [UserService, PrismaService, BaseFilterService, AuthService],
})
export class UserModule {}
