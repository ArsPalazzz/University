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
  Put,
  Query,
  Req,
  Res,
  UseGuards,
  UsePipes,
} from '@nestjs/common';
import { RecipeService } from '@resources/recipes/recipe.service';
import { CreateRecipeDto } from './dto/create-recipe.dto';
import { UpdateRecipeDto } from './dto/update-recipe.dto';
import { FilterRecipesDto } from './dto/filter-recipes.dto';
import { UserAuthPayload } from '@common/types/user.types';
import { ValidateIngredientPipe } from 'app/pipes/validate_ingredient.pipe';

@Controller('recipes')
export class RecipeController {
  constructor(private readonly recipeService: RecipeService) {}

  @Get()
  async getAllRecipes(@Query() filterDto: FilterRecipesDto) {
    return this.recipeService.filterAllRecipes(filterDto);
  }

  @UseGuards(AuthGuard)
  @Get('myRecipes')
  async getMyRecipes() {
    const myRecipesExtra = await this.recipeService.findMyRecipes();

    const myRecipes = myRecipesExtra.map((item) => {
      const newItem = {
        ...item,
        rating_count: item.ratings.length,
      };

      delete newItem.ratings;

      return newItem;
    });

    return myRecipes;
  }

  @Get('author')
  async getRecipesByAuthorId(
    @Query('user_id') authorId: string,
    @Query('except_id') exceptId: string,
  ) {
    const recipesWithExtra = await this.recipeService.findRecipesByUserId({
      userId: authorId,
      exceptId,
    });

    return recipesWithExtra.map((item) => {
      return {
        id: item.id,
        user_id: item.user_id,
        title: item.title,
        image_path: item.image_path,
        avg_rating: item.avg_rating,
        rating_count: item.ratings.length,
      };
    });
  }

  @Get(':id')
  async getRecipeById(@Param('id') id: string) {
    return this.recipeService.findOneById(id);
  }

  @Get(':id/full')
  async getRecipeFullById(@Param('id') id: string, @Req() req: Request) {
    const userInfo = req['user'] as UserAuthPayload;

    const recipe = await this.recipeService.findOneFullById(id);
    if (!recipe) {
      throw new NotFoundException('Recipe not found');
    }

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
      ratingId: recipe.ratings?.find((item) => item.user_id === userInfo.id)
        ?.id,
      status: recipe.status,
      cuisine: {
        id: recipe.cuisines?.id,
        name: recipe.cuisines?.name,
      },
      user: {
        id: recipe.users.id,
        name: recipe.users.username,
        avatar_url: recipe.users.avatar_url,
      },
      ingredients: recipe.recipes_ingredients.map((item) => {
        return {
          id: item.ingredients.id,
          name: item.ingredients.name,
          quantity: item.quantity,
        };
      }),
      has_rated: !!recipe.comments.find((comment) => {
        if (userInfo?.id === comment.users.id) return comment;
      }),
      comments: recipe.comments.map((comment) => {
        return {
          id: comment.id,
          created_at: comment.created_at,
          content: comment.content,
          authorName: comment.users.username,
          avatarUrl: comment.users.avatar_url,
          authorId: comment.users.id,
          rating: (comment.users as any).rating,
        };
      }),
      tags: recipe.recipes_tags.map((item) => {
        return {
          id: item.tags.id,
          name: item.tags.name,
          query_key: item.tags.query_key,
        };
      }),
    };

    return aaa;
  }

  @UseGuards(AuthGuard)
  @UsePipes(ValidateIngredientPipe)
  @Post()
  async createRecipe(@Body() createRecipeDto: CreateRecipeDto, @Req() req) {
    const user_id = req.user.id as string;
    return this.recipeService.createRecipe({ ...createRecipeDto, user_id });
  }

  @UseGuards(AuthGuard)
  @Patch(':id')
  async updateRecipe(
    @Param('id') id: string,
    @Body() updateRecipeDto: UpdateRecipeDto,
    @Req() req,
  ) {
    const role = (req.user as UserAuthPayload).role;
    return this.recipeService.updateRecipe(id, role, updateRecipeDto);
  }

  @UseGuards(AuthGuard)
  @Delete(':id')
  async deleteRecipe(@Param('id') id: string, @Req() req) {
    const role = (req.user as UserAuthPayload).role;
    return this.recipeService.deleteRecipe(id, role);
  }
}
