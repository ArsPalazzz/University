import {
  BadRequestException,
  ForbiddenException,
  Injectable,
} from '@nestjs/common';
import { PrismaService } from '@database/prisma.service';
import { users } from '@prisma/client';
import { FilterUsersDto } from './dto/filter-users.dto';
import { BaseFilterService } from '@common/filters/base-filter.service';
import { AuthRole } from '@common/constants/auth.const';
import { UserAuthPayload } from '@common/types/user.types';
import { UpdateUserDto } from './dto/update-user.dto';

@Injectable()
export class UserService {
  constructor(
    private prisma: PrismaService,
    private readonly baseFilterService: BaseFilterService,
  ) {}

  async filterAll(filterDto: FilterUsersDto) {
    const { search, role, sortBy, order } = filterDto;
    const searchColumn = 'username';

    const filters: Record<string, any> = {};

    if (role) filters.role = role;

    return this.baseFilterService.filter('users', {
      search,
      searchColumn,
      sortBy,
      order,
      filters,
    });
  }

  async findProfileById(id: string): Promise<
    users & {
      followings_followings_follower_idTousers: any[];
      followings_followings_followed_idTousers: any[];
    }
  > {
    return this.prisma.users.findUnique({
      where: { id },
      include: {
        followings_followings_follower_idTousers: true,
        followings_followings_followed_idTousers: true,
      },
    });
  }

  async findOneById(id: string): Promise<users> {
    console.log(id);
    return this.prisma.users.findUnique({
      where: { id },
    });
  }

  async updateOneById({
    id,
    user,
    payload,
    ok = false,
  }: {
    id: string;
    user?: UserAuthPayload;
    payload: UpdateUserDto;
    ok: boolean;
  }): Promise<users> {
    if (!id) {
      throw new BadRequestException('Id is undefined');
    }

    let foundUser;
    try {
      foundUser = await this.prisma.users.findUnique({
        where: { id },
      });
    } catch {
      throw new BadRequestException("User doesn't exist");
    }

    if (!ok) {
      if (foundUser.id !== user.id && user.role !== AuthRole.Admin) {
        throw new ForbiddenException('You cannot change this user');
      }
    }

    return this.prisma.users.update({
      where: { id },
      data: payload,
    });
  }
}
