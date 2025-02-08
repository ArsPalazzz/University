import { AuthGuard } from '@guards/auth.guard';
import { Body, Controller, Param, Patch, UseGuards } from '@nestjs/common';
import { UserModeratorService } from './user.service';
import { Roles } from 'app/decorators/roles';
import { AuthRole } from '@common/constants/auth.const';
import { BlockUserDto } from './dto/block-user.dto';

@UseGuards(AuthGuard)
@Roles(AuthRole.Moderator)
@Controller('moderator/users')
export class UserModeratorController {
  constructor(private readonly userModeratorService: UserModeratorService) {}

  @Patch(':id')
  async blockUser(
    @Param('id') user_id: string,
    @Body() blockUserDto: BlockUserDto,
  ) {
    return this.userModeratorService.blockUser({
      ...blockUserDto,
      user_id,
    });
  }
}
