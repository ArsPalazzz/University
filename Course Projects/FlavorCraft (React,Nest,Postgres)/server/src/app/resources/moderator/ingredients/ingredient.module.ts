import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { Module } from '@nestjs/common';
import { IngredientModeratorService } from './ingredient.service';
import { IngredientModeratorController } from './ingredient.controller';
import { AuthService } from '@auth/auth.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [IngredientModeratorController],
  providers: [IngredientModeratorService, AuthService],
})
export class IngredientModeratorModule {}
