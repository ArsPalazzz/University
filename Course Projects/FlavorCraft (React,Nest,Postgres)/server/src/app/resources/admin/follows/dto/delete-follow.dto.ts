import { IsNotEmpty, IsString } from 'class-validator';

export class DeleteFollowDto {
  @IsString()
  @IsNotEmpty()
  follower_id: string;

  @IsString()
  @IsNotEmpty()
  followed_id: string;
}
