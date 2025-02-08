import { IsString, IsNotEmpty } from 'class-validator';

export class ToggleFavouriteDto {
  @IsString()
  @IsNotEmpty()
  recipe_id: string;
}
