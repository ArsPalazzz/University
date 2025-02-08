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
  UseGuards,
} from '@nestjs/common';
import { FollowAdminService } from './follow.service';
import { CreateFollowDto } from './dto/create-follow.dto';
import { DeleteFollowDto } from './dto/delete-follow.dto';
import { AuthRole } from '@common/constants/auth.const';
import { Roles } from 'app/decorators/roles';

@UseGuards(AuthGuard)
@Roles(AuthRole.Admin)
@Controller('admin/follows')
export class FollowAdminController {
  constructor(private readonly followingAdminService: FollowAdminService) {}

  @Get()
  async getAllFollows() {
    return this.followingAdminService.findAll();
  }

  @UseGuards(AuthGuard)
  @Post()
  async createFollow(@Body() { follower_id, followed_id }: CreateFollowDto) {
    return this.followingAdminService.createFollow({
      follower_id,
      followed_id,
    });
  }

  @UseGuards(AuthGuard)
  @Patch(':id')
  async updateFollow(
    @Param('id', ParseIntPipe) followId: number,
    @Body() { follower_id, followed_id }: CreateFollowDto,
  ) {
    return this.followingAdminService.updateFollow(
      {
        follower_id,
        followed_id,
      },
      followId,
    );
  }

  @UseGuards(AuthGuard)
  @Delete(':id')
  async deleteFollow(@Param('id', ParseIntPipe) follow_id: number) {
    return this.followingAdminService.deleteFollow(follow_id);
  }
}
