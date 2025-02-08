import { IsString, IsNotEmpty } from 'class-validator';

export class EditCategoryDto {
  @IsString()
  @IsNotEmpty()
  name: string;
}
