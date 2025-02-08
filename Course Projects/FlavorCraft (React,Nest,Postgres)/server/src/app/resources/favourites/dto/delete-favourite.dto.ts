import { IsNotEmpty, IsString } from 'class-validator';

export class DeleteFollowDto {
  @IsString()
  @IsNotEmpty()
  followed_id: string;
}
