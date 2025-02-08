import { IsString, IsNotEmpty, IsNumber, IsPositive } from 'class-validator';

export class UpdateCommentDto {
  @IsNumber()
  @IsPositive()
  id: number;

  @IsString()
  @IsNotEmpty()
  content: string;
}
