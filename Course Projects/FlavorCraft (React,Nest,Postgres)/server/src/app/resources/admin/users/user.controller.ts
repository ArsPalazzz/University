import {
  Controller,
  Delete,
  Get,
  Param,
  Query,
  UseGuards,
} from '@nestjs/common';
import { users } from '@prisma/client';
import { FilterUsersDto } from './dto/filter-users.dto';
import { UserAdminService } from './user.service';
import { AuthGuard } from '@guards/auth.guard';
import { Roles } from 'app/decorators/roles';
import { AuthRole } from '@common/constants/auth.const';

@UseGuards(AuthGuard)
@Roles(AuthRole.Admin)
@Controller('admin/users')
export class UserAdminController {
  constructor(private readonly userAdminService: UserAdminService) {}

  @Get()
  async getAllUsers(@Query() filterDto: FilterUsersDto): Promise<users[]> {
    return this.userAdminService.filterAll(filterDto);
  }

  @Get(':id')
  async getUserById(@Param('id') id: string): Promise<users> {
    return this.userAdminService.findOneById(id);
  }

  @Delete(':id')
  async deleteUserById(@Param('id') id: string): Promise<users> {
    return this.userAdminService.deleteOneById(id);
  }
}
