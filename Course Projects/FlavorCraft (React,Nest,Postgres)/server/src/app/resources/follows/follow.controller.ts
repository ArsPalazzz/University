import { AuthGuard } from '@guards/auth.guard';
import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  Post,
  Req,
  UseGuards,
} from '@nestjs/common';
import { FollowService } from './follow.service';
import { CreateFollowDto } from './dto/create-follow.dto';
import { DeleteFollowDto } from './dto/delete-follow.dto';

@Controller('follows')
export class FollowController {
  constructor(private readonly followingService: FollowService) {}

  @Get()
  async getAllFollows() {
    return this.followingService.findAll();
  }

  @Get(':id')
  async getFollowById(@Param('id') id: number) {
    return this.followingService.findOneById(id);
  }

  @UseGuards(AuthGuard)
  @Post()
  async createFollow(@Body() createFollowDto: CreateFollowDto, @Req() req) {
    const user_id = req.user.id as string;
    return this.followingService.createFollow({ ...createFollowDto, user_id });
  }

  @UseGuards(AuthGuard)
  @Delete(':id')
  async deleteFollow(@Param('id') followedId, @Req() req) {
    const user_id = req.user.id as string;
    return this.followingService.deleteFollow({
      follower_id: user_id,
      followed_id: followedId,
    });
  }
}
