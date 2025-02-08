import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { CategoryModeratorService } from './category.service';
import { CategoryModeratorController } from './category.controller';
import { AuthService } from '@auth/auth.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [CategoryModeratorController],
  providers: [CategoryModeratorService, AuthService],
})
export class CategoryModeratorModule {}
