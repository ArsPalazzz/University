import { AuthGuard } from '@guards/auth.guard';
import {
  Body,
  Controller,
  Delete,
  Get,
  NotFoundException,
  Param,
  Patch,
  Post,
  Query,
  Req,
  UseGuards,
} from '@nestjs/common';
import { RecipeAdminService } from './recipe.service';
import { Roles } from 'app/decorators/roles';
import { AuthRole } from '@common/constants/auth.const';
import { UpdateRecipeDto } from '@resources/recipes/dto/update-recipe.dto';
import { CreateRecipeDto } from '@resources/recipes/dto/create-recipe.dto';
import { UserAuthPayload } from '@common/types/user.types';

@UseGuards(AuthGuard)
@Roles(AuthRole.Admin)
@Controller('admin/recipes')
export class RecipeAdminController {
  constructor(private readonly recipeAdminService: RecipeAdminService) {}

  @Get()
  async getAllRecipes() {
    return this.recipeAdminService.findAll();
  }

  @Get(':id')
  async getRecipeById(@Param('id') id: string) {
    return this.recipeAdminService.findOneById(id);
  }

  @Get(':id/full')
  async getRecipeFullById(@Param('id') id: string, @Req() req: Request) {
    const userInfo = req['user'] as UserAuthPayload;

    const recipe = await this.recipeAdminService.findOneFullById(id);
    if (!recipe) {
      throw new NotFoundException('Recipe not found');
    }

    try {
      const aaa = {
        id: recipe.id,
        title: recipe.title,
        image_path: recipe.image_path,
        description: recipe.description,
        difficulty_level: recipe.difficulty_level,
        instructions: recipe.instructions,
        category_id: recipe.category_id,
        category_name: recipe.categories.name,
        prep_time: recipe.prep_time,
        calories: recipe.calories,
        protein: recipe.protein,
        fats: recipe.fat,
        carbs: recipe.carbs,
        avg_rating: recipe.avg_rating,
        portions_min: recipe.portions_min,
        portions_max: recipe.portions_max,
        rating_count: recipe.ratings.length,
        ratingId: recipe.ratings?.find((item) => item.user_id === userInfo?.id)
          ?.id,
        status: recipe.status,
        cuisine: {
          id: recipe.cuisines?.id,
          name: recipe.cuisines?.name,
        },
        user: {
          id: recipe.users?.id,
          name: recipe.users.username,
          avatar_url: recipe.users.avatar_url,
        },
        ingredients: recipe.recipes_ingredients.map((item) => {
          return {
            id: item.ingredients?.id,
            name: item.ingredients.name,
            quantity: item.quantity,
          };
        }),
        has_rated: !!recipe.comments.find((comment) => {
          if (userInfo?.id === comment.users?.id) return comment;
        }),
        comments: recipe.comments.map((comment) => {
          return {
            id: comment?.id,
            created_at: comment.created_at,
            content: comment.content,
            authorName: comment.users.username,
            avatarUrl: comment.users.avatar_url,
            authorId: comment.users?.id,
            rating: (comment.users as any).rating,
          };
        }),
        tags: recipe.recipes_tags.map((item) => {
          return {
            id: item.tags?.id,
            name: item.tags.name,
            query_key: item.tags.query_key,
          };
        }),
      };

      return aaa;
    } catch (err) {
      console.log(err);
    }
  }

  @UseGuards(AuthGuard)
  @Post()
  async createRecipe(@Body() createRecipeDto: CreateRecipeDto, @Req() req) {
    const user_id = req.user.id as string;
    return this.recipeAdminService.createRecipe({
      ...createRecipeDto,
      user_id,
    });
  }

  @UseGuards(AuthGuard)
  @Patch(':id')
  async updateRecipe(
    @Param('id') id: string,
    @Body() updateRecipeDto: UpdateRecipeDto,
  ) {
    return this.recipeAdminService.updateRecipe(id, updateRecipeDto);
  }

  @UseGuards(AuthGuard)
  @Delete(':id')
  async deleteRecipe(@Param('id') id: string) {
    return this.recipeAdminService.deleteRecipe(id);
  }
}
