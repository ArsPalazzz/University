import {
  IsString,
  IsNotEmpty,
  Max,
  Min,
  IsNumber,
  IsOptional,
} from 'class-validator';

export class CreateCommentDto {
  @IsString()
  @IsNotEmpty()
  recipe_id: string;

  @IsNumber()
  @IsOptional()
  @Min(1)
  @Max(5)
  rating: number;

  @IsString()
  @IsNotEmpty()
  content: string;
}
