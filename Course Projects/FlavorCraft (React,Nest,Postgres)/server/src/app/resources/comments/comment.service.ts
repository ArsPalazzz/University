import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { comments } from '@prisma/client';
import { CreateCommentDto } from './dto/create-comment.dto';
import { DeleteCommentInput } from '@common/types/comment.types';
import { RecipeStatus } from '@common/constants/recipe.const';
import { CommentStatus } from '@common/constants/comment';
import { UpdateCommentDto } from './dto/update-comment.dto';

@Injectable()
export class CommentService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<comments[]> {
    return this.prisma.comments.findMany({
      where: {
        status: CommentStatus.ACTIVE,
      },
    });
  }

  async findAllByUserId(user_id: string): Promise<comments[]> {
    return this.prisma.comments.findMany({
      where: { user_id, status: CommentStatus.ACTIVE },
    });
  }

  async findOneById(id: number): Promise<comments> {
    return this.prisma.comments.findUnique({
      where: { id, status: CommentStatus.ACTIVE },
    });
  }

  async findAllById(id: number): Promise<comments[]> {
    const a = await this.prisma.comments.findMany({
      where: { id, status: CommentStatus.ACTIVE },
      orderBy: { created_at: 'desc' },
    });

    return a;
  }

  async createComment(comment: { user_id: string } & CreateCommentDto) {
    const { user_id, recipe_id, content } = comment;

    const recipe = await this.getRecipeById(recipe_id);

    // if (recipe.status !== RecipeStatus.PUBLISHED) {
    //   throw new BadRequestException('You cannot comment on this recipe');
    // }

    return await this.prisma.comments.create({
      data: {
        user_id,
        recipe_id,
        content,
      },
    });
  }

  async updateComment(commentDto: { user_id: string } & UpdateCommentDto) {
    const comment = await this.getCommentById(commentDto.id);
    if (!comment) {
      throw new BadRequestException("Comment doesn't exit");
    }

    const isCommentActive = comment.status == CommentStatus.ACTIVE;
    const recipe = await this.getRecipeById(comment.recipe_id);

    if (!recipe) {
      throw new BadRequestException("Recipe doesn't exit");
    }

    if (comment.user_id !== commentDto.user_id || !isCommentActive) {
      throw new BadRequestException('You cannot edit this comment');
    }

    return await this.prisma.comments.update({
      where: { id: commentDto.id },
      data: { content: commentDto.content },
    });
  }

  async archieveComment({ user_id, comment_id }: DeleteCommentInput) {
    const comment = await this.getCommentById(comment_id);
    if (!comment) {
      throw new BadRequestException("Comment doesn't exit");
    }

    const recipe = await this.getRecipeById(comment.recipe_id);
    if (!recipe) {
      throw new BadRequestException("Recipe doesn't exit");
    }

    if (comment.user_id !== user_id && recipe.user_id !== user_id) {
      throw new BadRequestException('You cannot remove this comment');
    }

    return await this.prisma.comments.update({
      where: { id: comment_id },
      data: { status: CommentStatus.ARCHIEVED },
    });
  }

  private async getRecipeById(id: string) {
    try {
      return await this.prisma.recipes.findUnique({
        where: { id },
      });
    } catch {
      throw new BadRequestException("This recipe doesn't exists");
    }
  }

  private async getCommentById(id: number) {
    try {
      return await this.prisma.comments.findFirst({
        where: {
          id,
          status: CommentStatus.ACTIVE,
        },
      });
    } catch {
      throw new BadRequestException("You haven't written this comment");
    }
  }
}
