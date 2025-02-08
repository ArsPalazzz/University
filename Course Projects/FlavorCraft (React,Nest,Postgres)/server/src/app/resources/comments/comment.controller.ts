import { AuthGuard } from '@guards/auth.guard';
import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  ParseIntPipe,
  Patch,
  Post,
  Req,
  UseGuards,
} from '@nestjs/common';
import { CommentService } from './comment.service';
import { CreateCommentDto } from './dto/create-comment.dto';
import { UpdateCommentDto } from './dto/update-comment.dto';
import { RatingService } from '@resources/ratings/rating.service';

@Controller('comments')
export class CommentController {
  constructor(
    private readonly commentService: CommentService,
    private readonly ratingService: RatingService,
  ) {}

  @Get()
  async getAllComments() {
    return this.commentService.findAll();
  }

  @Get(':id')
  async getCommentsByRecipeId(@Param('id') id: number) {
    return this.commentService.findAllById(id);
  }

  @UseGuards(AuthGuard)
  @Post()
  async createComment(@Body() createCommentDto: CreateCommentDto, @Req() req) {
    const user_id = req.user.id as string;

    const hasRated = await this.ratingService.findOneByUserIdAndRecipeId({
      userId: user_id,
      recipeId: createCommentDto.recipe_id,
    });

    if (!hasRated) {
      await this.ratingService.createRating({
        user_id,
        recipe_id: createCommentDto.recipe_id,
        rating: createCommentDto.rating,
      });
    }

    return this.commentService.createComment({
      ...createCommentDto,
      user_id,
    });
  }

  @UseGuards(AuthGuard)
  @Patch()
  async updateComment(@Body() updateCommentDto: UpdateCommentDto, @Req() req) {
    const user_id = req.user.id as string;

    return this.commentService.updateComment({
      ...updateCommentDto,
      user_id,
    });
  }

  @UseGuards(AuthGuard)
  @Delete(':id')
  async deleteComment(@Param('id', ParseIntPipe) id: number, @Req() req) {
    const user_id = req.user.id as string;

    return this.commentService.archieveComment({
      user_id,
      comment_id: id as number,
    });
  }
}
