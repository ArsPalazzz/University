import { IsString, IsNotEmpty } from 'class-validator';

export class CreateFollowDto {
  @IsString()
  @IsNotEmpty()
  followed_id: string;
}
