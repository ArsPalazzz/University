import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { followings } from '@prisma/client';
import { CreateFollowDto } from './dto/create-follow.dto';
import { DeleteFollowDto } from './dto/delete-follow.dto';

@Injectable()
export class FollowService {
  constructor(private prisma: PrismaService) {}

  async findAll(): Promise<followings[]> {
    return this.prisma.followings.findMany();
  }

  async findAllFollowers(follower_id: string): Promise<followings[]> {
    return this.prisma.followings.findMany({
      where: {
        follower_id,
      },
    });
  }

  async findAllFollowings(following_id: string): Promise<followings[]> {
    return this.prisma.followings.findMany({
      where: {
        followed_id: following_id,
      },
    });
  }

  async findOneById(id: number): Promise<followings> {
    return this.prisma.followings.findUnique({
      where: { id },
    });
  }

  async createFollow(follow: { user_id: string } & CreateFollowDto) {
    const { user_id, followed_id } = follow;

    if (user_id === followed_id) {
      throw new BadRequestException('You cannot follow yourself');
    }

    const exists = !!(await this.prisma.followings.count({
      where: { follower_id: user_id, followed_id },
    }));

    if (exists) {
      throw new BadRequestException('You have already followed this user');
    }

    return await this.prisma.followings.create({
      data: {
        followed_id,
        follower_id: user_id,
      },
    });
  }

  async deleteFollow({
    followed_id,
    follower_id,
  }: DeleteFollowDto & { follower_id: string }) {
    let follow: followings;

    if (followed_id === follower_id) {
      throw new BadRequestException('You cannot unfollow yourself');
    }

    try {
      follow = await this.prisma.followings.findFirst({
        where: { followed_id, follower_id },
      });
    } catch {
      throw new BadRequestException("You haven't followed this user");
    }

    if (!follow) {
      throw new BadRequestException("You haven't followed this user");
    }

    return await this.prisma.followings.delete({
      where: {
        id: follow.id,
      },
    });
  }
}
