import { BadRequestException, Injectable } from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { followings } from '@prisma/client';
import { CreateFollowDto } from './dto/create-follow.dto';
import { DeleteFollowDto } from './dto/delete-follow.dto';

@Injectable()
export class FollowAdminService {
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

  async createFollow(follow: CreateFollowDto) {
    const { follower_id, followed_id } = follow;

    if (follower_id === followed_id) {
      throw new BadRequestException(
        'You cannot follow a user to their own account',
      );
    }

    const existsV1 = !!(await this.prisma.followings.count({
      where: { follower_id, followed_id },
    }));

    const existsV2 = !!(await this.prisma.followings.count({
      where: { follower_id: followed_id, followed_id: follower_id },
    }));

    if (existsV1 || existsV2) {
      throw new BadRequestException(
        'These users have already followed to each other',
      );
    }

    return await this.prisma.followings.create({
      data: {
        followed_id,
        follower_id,
      },
    });
  }

  async updateFollow(follow: CreateFollowDto, followId: number) {
    const { follower_id, followed_id } = follow;

    const following = this.prisma.followings.findUnique({
      where: {
        id: followId,
      },
    });

    if (!following) {
      throw new BadRequestException('This follow does not exist');
    }

    if (follower_id === followed_id) {
      throw new BadRequestException(
        'You cannot follow a user to their own account',
      );
    }

    // const existsV1 = !!(await this.prisma.followings.count({
    //   where: { follower_id, followed_id },
    // }));

    // const existsV2 = !!(await this.prisma.followings.count({
    //   where: { follower_id: followed_id, followed_id: follower_id },
    // }));

    // if (existsV1 || existsV2) {
    //   throw new BadRequestException(
    //     'These users have already followed to each other',
    //   );
    // }

    return await this.prisma.followings.update({
      where: {
        id: followId,
      },
      data: {
        followed_id,
        follower_id,
      },
    });
  }

  async deleteFollow(follow_id: number) {
    try {
      await this.prisma.followings.findUnique({
        where: {
          id: follow_id,
        },
      });
    } catch {
      throw new BadRequestException('This follow does not exist');
    }

    return await this.prisma.followings.delete({
      where: {
        id: follow_id,
      },
    });
  }
}
