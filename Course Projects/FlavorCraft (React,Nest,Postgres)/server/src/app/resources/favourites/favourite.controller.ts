import { AuthGuard } from '@guards/auth.guard';
import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  ParseIntPipe,
  Post,
  Query,
  Req,
  UseGuards,
} from '@nestjs/common';
import { FavouriteService } from './favourite.service';
import { ToggleFavouriteDto } from './dto/create-favourite.dto';
import { UserAuthPayload } from '@common/types/user.types';

@Controller('favourites')
export class FavouriteController {
  constructor(private readonly favouriteService: FavouriteService) {}

  @UseGuards(AuthGuard)
  @Get()
  async getAllFavouritesByUserId(@Req() req) {
    const userId = req.user.id as string;
    const a = this.favouriteService.findAllByUserId(userId);
    return a;
  }

  @UseGuards(AuthGuard)
  @Get('recipeId/:recipeId')
  async isRecipeInFavouritesByRecipeId(
    @Param('recipeId') recipeId: string,
    @Req() req,
  ) {
    const isAuthorised = req.user as UserAuthPayload;
    if (!isAuthorised) return false;

    const user_id = req.user?.id as string;
    return this.favouriteService.isExistRecipeByRecipeId(recipeId, user_id);
  }

  @UseGuards(AuthGuard)
  @Get('favRecipes')
  async getFavouritesByUserId(@Req() req) {
    const userId = req.user.id as string;
    const allInfo = await this.favouriteService.findAllByUserId(userId);

    return allInfo.map((item) => {
      return {
        id: item.recipe_id,
        title: item.recipes.title,
        image_path: item.recipes.image_path,
        avg_rating: Number(item.recipes.avg_rating),
        rating_count: item.recipes.ratings.length,
        created_at: item.recipes.created_at,
      };
    });
  }

  @UseGuards(AuthGuard)
  @Post()
  async toggleFavourite(
    @Body() toggleFavouriteDto: ToggleFavouriteDto,
    @Req() req,
  ) {
    const user_id = req.user.id as string;

    return this.favouriteService.toggleFavourite({
      ...toggleFavouriteDto,
      user_id,
    });
  }

  // @UseGuards(AuthGuard)
  // @Delete(':id')
  // async deleteFavourite(@Param('id', ParseIntPipe) id: number, @Req() req) {
  //   const user_id = req.user.id as string;

  //   return this.favouriteService.deleteFavourite({
  //     user_id,
  //     favourite_id: id as number,
  //   });
  // }
}
