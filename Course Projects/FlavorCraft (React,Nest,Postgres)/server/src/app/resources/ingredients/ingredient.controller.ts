import { AuthGuard } from '@guards/auth.guard';
import {
  Body,
  Controller,
  Get,
  Param,
  Post,
  UseGuards,
  UsePipes,
} from '@nestjs/common';
import { CreateIngredientDto } from './dto/create-ingredient.dto';
import { IngredientService } from './ingredient.service';
import { ValidateIngredientPipe } from 'app/pipes/validate_ingredient.pipe';

@Controller('ingredients')
export class IngredientController {
  constructor(private readonly ingredientService: IngredientService) {}

  @Get()
  async getAllIngredients() {
    return this.ingredientService.findAll();
  }

  @Get(':name')
  async getIngredientByName(@Param('name') name: string) {
    return this.ingredientService.findOneByName(name);
  }

  @UseGuards(AuthGuard)
  @UsePipes(ValidateIngredientPipe)
  @Post()
  async createIngredient(@Body() createIngredientDto: CreateIngredientDto) {
    return this.ingredientService.createIngredient(createIngredientDto.name);
  }
}
