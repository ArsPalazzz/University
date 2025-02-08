import {
  Body,
  Controller,
  Get,
  Param,
  Patch,
  Put,
  Query,
  Req,
  UseGuards,
} from '@nestjs/common';
import { UserService } from '@resources/users/user.service';
import { users } from '@prisma/client';
import { FilterUsersDto } from './dto/filter-users.dto';
import { AuthGuard } from '@guards/auth.guard';
import { UpdateUserDto } from './dto/update-user.dto';
import { Request } from 'express';
import { UserAuthPayload } from '@common/types/user.types';
import { AuthRole } from '@common/constants/auth.const';

@Controller('users')
export class UserController {
  constructor(private readonly usersService: UserService) {}

  @Get()
  async getAllUsers(@Query() filterDto: FilterUsersDto): Promise<users[]> {
    return this.usersService.filterAll(filterDto);
  }

  @UseGuards(AuthGuard)
  @Get('/my_profile')
  async getCurrentProfileByUserId(@Req() req): Promise<
    Omit<users, 'is_blocked' | 'password_hash'> & {
      following_count: number;
      followers_count: number;
    }
  > {
    const user = req.user.id;
    const aa = await this.usersService.findProfileById(user);

    return {
      avatar_url: aa.avatar_url,
      created_at: aa.created_at,
      id: aa.id,
      is_blocked: aa.is_blocked,
      username: aa.username,
      role: aa.role,
      email: aa.email,
      following_count: aa.followings_followings_followed_idTousers?.length || 0,
      followers_count: aa.followings_followings_follower_idTousers?.length || 0,
    } as Omit<users, 'is_blocked' | 'password_hash'> & {
      following_count: number;
      followers_count: number;
    };
  }

  @Get('/user_info/:id')
  async getUserById(@Param('id') id: string): Promise<users> {
    console.log('aa');
    return this.usersService.findOneById(id);
  }

  @Get('/author/:user_id')
  async getOtherProfileByUserId(@Param('user_id') userId: string): Promise<
    Partial<users> & {
      followers_count: number;
      following_count: number;
      isFollowingAuthor: boolean;
    }
  > {
    const profileExtra = await this.usersService.findProfileById(userId);

    const isFollowingAuthor =
      profileExtra.followings_followings_followed_idTousers.some(
        (item) => item.followed_id === profileExtra.id,
      );

    return {
      avatar_url: profileExtra.avatar_url,
      created_at: profileExtra.created_at,
      is_blocked: profileExtra.is_blocked,
      followers_count:
        profileExtra.followings_followings_followed_idTousers.length,
      following_count:
        profileExtra.followings_followings_follower_idTousers.length,
      id: profileExtra.id,
      username: profileExtra.username,
      isFollowingAuthor,
    };
  }

  @UseGuards(AuthGuard)
  @Patch(':id')
  async updateUserById(
    @Param('id') id: string,
    @Body() updateRecipeDto: UpdateUserDto,
    @Req() req,
  ): Promise<users> {
    return this.usersService.updateOneById({
      id,
      user: req.user as UserAuthPayload,
      payload: updateRecipeDto,
      ok: false,
    });
  }
}
