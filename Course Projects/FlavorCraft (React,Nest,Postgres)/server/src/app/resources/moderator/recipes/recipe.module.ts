import { Module } from '@nestjs/common';
import { RecipeModeratorController } from './recipe.controller';
import { RecipeModeratorService } from './recipe.service';
import { DatabaseModule } from '@database/database.module';
import { AuthModule } from '@auth/auth.module';
import { AuthService } from '@auth/auth.service';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [RecipeModeratorController],
  providers: [RecipeModeratorService, AuthService],
})
export class RecipeModeratorModule {}
