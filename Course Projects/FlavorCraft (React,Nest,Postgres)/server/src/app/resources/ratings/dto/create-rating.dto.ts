import { IsString, IsNotEmpty, IsNumber, Min, Max } from 'class-validator';

export class CreateRatingDto {
  @IsString()
  @IsNotEmpty()
  recipe_id: string;

  @IsNumber()
  @IsNotEmpty()
  @Min(1)
  @Max(5)
  rating: number;
}
