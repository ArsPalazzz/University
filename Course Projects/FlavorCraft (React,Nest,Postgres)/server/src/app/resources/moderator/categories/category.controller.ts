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
import { CategoryModeratorService } from './category.service';
import { CreateCategoryDto } from './dto/create_category.dto';

@UseGuards(AuthGuard)
@Roles(AuthRole.Moderator, AuthRole.Admin)
@Controller('moderator/categories')
export class CategoryModeratorController {
  constructor(
    private readonly categoryModeratorService: CategoryModeratorService,
  ) {}

  @Get()
  async getAllCategories() {
    return this.categoryModeratorService.findAll();
  }

  @Post()
  async createCategory(@Body() createCategoryDto: CreateCategoryDto) {
    return this.categoryModeratorService.createCategory(createCategoryDto);
  }

  @Delete(':id')
  async deleteCategory(@Param('id', ParseIntPipe) id: number) {
    return this.categoryModeratorService.deleteCategory(id);
  }
}
