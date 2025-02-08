import { AuthGuard } from '@guards/auth.guard';
import {
  Body,
  Controller,
  Delete,
  Param,
  ParseIntPipe,
  Patch,
  Post,
  UseGuards,
  UsePipes,
} from '@nestjs/common';
import { EditIngredientDto } from './dto/edit-ingredient.dto';
import { IngredientAdminService } from './ingredient.service';
import { ValidateIngredientPipe } from 'app/pipes/validate_ingredient.pipe';
import { Roles } from 'app/decorators/roles';
import { AuthRole } from '@common/constants/auth.const';
import { CreateIngredientDto } from './dto/create-ingredient.dto';

@UseGuards(AuthGuard)
@Roles(AuthRole.Admin)
@Controller('admin/ingredients')
export class IngredientAdminController {
  constructor(
    private readonly ingredientAdminService: IngredientAdminService,
  ) {}

  @UsePipes(ValidateIngredientPipe)
  @Post()
  async createIngredient(@Body() createIngredientDto: CreateIngredientDto) {
    return await this.ingredientAdminService.createIngredient(
      createIngredientDto.name,
    );
  }

  @Patch(':id')
  async updateIngredient(
    @Param('id', ParseIntPipe) id,
    @Body(ValidateIngredientPipe) editIngredientDto: EditIngredientDto,
  ) {
    return this.ingredientAdminService.updateIngredient(
      id,
      editIngredientDto.name,
    );
  }

  @Delete(':id')
  async deleteIngredient(@Param('id', ParseIntPipe) id) {
    return await this.ingredientAdminService.deleteIngredient(id);
  }
}
