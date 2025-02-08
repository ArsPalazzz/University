import { IsString, IsNotEmpty } from 'class-validator';

export class DeleteFollowDto {
  @IsString()
  @IsNotEmpty()
  followed_id: string;
}
