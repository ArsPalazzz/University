import { IsString, IsNotEmpty } from 'class-validator';

export class CreateFollowDto {
  @IsString()
  @IsNotEmpty()
  follower_id: string;

  @IsString()
  @IsNotEmpty()
  followed_id: string;
}
