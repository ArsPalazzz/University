import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  Patch,
  UseGuards,
} from '@nestjs/common';
import { RecipeModeratorService } from './recipe.service';
import { AcceptRecipeDto } from './dto/accept-recipe.dto';
import { AuthGuard } from '@guards/auth.guard';
import { Roles } from 'app/decorators/roles';
import { AuthRole } from '@common/constants/auth.const';
import { DeclineRecipeDto } from './dto/decline-recipe.dto';

@Roles(AuthRole.Moderator)
@UseGuards(AuthGuard)
@Controller('moderator/recipes')
export class RecipeModeratorController {
  constructor(
    private readonly recipeModeratorService: RecipeModeratorService,
  ) {}

  @Get()
  async getAllPendingRecipes() {
    return this.recipeModeratorService.findAllPending();
  }

  @Patch('accept')
  async acceptRecipe(@Body() recipe: AcceptRecipeDto) {
    return this.recipeModeratorService.acceptRecipe(recipe.recipe_id);
  }

  @Patch('decline')
  async declineRecipe(@Body() recipe: DeclineRecipeDto) {
    return this.recipeModeratorService.declineRecipe(recipe.recipe_id);
  }

  @Delete(':id')
  async blockRecipe(@Param('id') id: string) {
    const a = await this.recipeModeratorService.blockRecipe(id);
    return a;
  }
}
