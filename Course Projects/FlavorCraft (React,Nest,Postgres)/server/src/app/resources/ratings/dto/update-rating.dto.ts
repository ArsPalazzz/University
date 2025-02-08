import { Type } from 'class-transformer';
import { IsNotEmpty, IsNumber, Min, Max } from 'class-validator';

export class UpdateRatingDto {
  @Type(() => Number)
  @IsNumber(
    { allowNaN: false, maxDecimalPlaces: 0 },
    { message: 'Rating must be a valid number' },
  )
  @IsNotEmpty({ message: 'Rating is required' })
  @Min(1, { message: 'Rating must be at least 1' })
  @Max(5, { message: 'Rating must not exceed 5' })
  rating: number;
}
