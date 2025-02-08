import { IsNotEmpty, IsString } from 'class-validator';

export class AcceptRecipeDto {
  @IsString()
  @IsNotEmpty()
  recipe_id: string;
}
