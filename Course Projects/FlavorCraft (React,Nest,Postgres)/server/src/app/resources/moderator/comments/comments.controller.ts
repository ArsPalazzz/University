import { AuthGuard } from '@guards/auth.guard';
import {
  Controller,
  Get,
  Param,
  ParseIntPipe,
  Patch,
  UseGuards,
} from '@nestjs/common';
import { Roles } from 'app/decorators/roles';
import { AuthRole } from '@common/constants/auth.const';
import { CommentModeratorService } from './comments.service';

@UseGuards(AuthGuard)
@Roles(AuthRole.Moderator)
@Controller('moderator/comments')
export class CommentModeratorController {
  constructor(
    private readonly commentModeratorService: CommentModeratorService,
  ) {}

  @Get()
  async getAllComments() {
    return this.commentModeratorService.findAll();
  }

  @Patch(':id')
  async blockComment(@Param('id', ParseIntPipe) id: number) {
    return this.commentModeratorService.blockComment(id);
  }
}
