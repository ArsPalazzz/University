import { IsString, IsNotEmpty } from 'class-validator';

export class EditIngredientDto {
  @IsString()
  @IsNotEmpty()
  name: string;
}
