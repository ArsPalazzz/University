import { IsNotEmpty, IsString } from 'class-validator';

export class DeclineRecipeDto {
  @IsString()
  @IsNotEmpty()
  recipe_id: string;
}
