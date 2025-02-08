import { AuthGuard } from '@guards/auth.guard';
import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  ParseIntPipe,
  Post,
  UseGuards,
} from '@nestjs/common';
import { Roles } from 'app/decorators/roles';
import { AuthRole } from '@common/constants/auth.const';
import { IngredientModeratorService } from './ingredient.service';
import { CreateIngredientDto } from '@resources/ingredients/dto/create-ingredient.dto';

@UseGuards(AuthGuard)
@Roles(AuthRole.Moderator, AuthRole.Admin)
@Controller('moderator/ingredients')
export class IngredientModeratorController {
  constructor(
    private readonly ingredientModeratorService: IngredientModeratorService,
  ) {}

  @Get()
  async getAllIngredients() {
    return this.ingredientModeratorService.findAll();
  }

  @Post()
  async createIngredient(@Body() createIngredientDto: CreateIngredientDto) {
    return this.ingredientModeratorService.createIngredient(
      createIngredientDto,
    );
  }

  @Delete(':id')
  async deleteIngredient(@Param('id', ParseIntPipe) id: number) {
    return this.ingredientModeratorService.deleteIngredient(id);
  }
}
