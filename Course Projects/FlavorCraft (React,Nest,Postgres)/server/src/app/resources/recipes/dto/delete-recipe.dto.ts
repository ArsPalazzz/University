import { IsString, IsNotEmpty } from 'class-validator';

export class DeleteRecipeDto {
  @IsString()
  @IsNotEmpty()
  recipe_id: string;
}
