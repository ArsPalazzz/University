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
} from '@nestjs/common';
import { CategoryAdminService } from './category.service';
import { Roles } from 'app/decorators/roles';
import { AuthRole } from '@common/constants/auth.const';
import { CreateCategoryDto } from './dto/create-category.dto';
import { EditCategoryDto } from './dto/edit-category.dto';

@UseGuards(AuthGuard)
@Roles(AuthRole.Admin)
@Controller('admin/categories')
export class CategoryAdminController {
  constructor(private readonly categoryAdminService: CategoryAdminService) {}

  @Post()
  async createCategory(@Body() createCategoryDto: CreateCategoryDto) {
    return await this.categoryAdminService.createCategory(
      createCategoryDto.name,
    );
  }

  @Patch(':id')
  async updateCategory(
    @Param('id', ParseIntPipe) id,
    @Body() editCategoryDto: EditCategoryDto,
  ) {
    return this.categoryAdminService.updateCategory(id, editCategoryDto.name);
  }

  @Delete(':id')
  async deleteCategory(@Param('id', ParseIntPipe) id) {
    return await this.categoryAdminService.deleteCategory(id);
  }
}
