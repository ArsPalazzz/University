import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { comments } from '@prisma/client';
import { CommentStatus } from '@common/constants/comment';

@Injectable()
export class CommentModeratorService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<comments[]> {
    return this.prisma.comments.findMany();
  }

  async findAllByUserId(user_id: string): Promise<comments[]> {
    return this.prisma.comments.findMany({
      where: { user_id },
    });
  }

  async findOneById(id: number): Promise<comments> {
    return this.prisma.comments.findUnique({
      where: { id },
    });
  }

  async findAllById(id: number): Promise<comments[]> {
    return this.prisma.comments.findMany({
      where: { id },
    });
  }

  async blockComment(comment_id: number) {
    await this._getCommentById(comment_id);

    return await this.prisma.comments.update({
      where: {
        id: comment_id,
      },
      data: {
        status: CommentStatus.BLOCKED,
      },
    });
  }

  private async _getCommentById(id: number) {
    try {
      return await this.prisma.comments.findFirst({
        where: { id },
      });
    } catch {
      throw new BadRequestException("You haven't written this comment");
    }
  }
}
