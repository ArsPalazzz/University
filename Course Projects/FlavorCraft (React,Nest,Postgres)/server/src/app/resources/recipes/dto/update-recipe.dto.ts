import { DifficultyLevel } from '@common/constants/difficulty_level.const';
import {
  IsString,
  IsNotEmpty,
  IsNumber,
  IsPositive,
  IsArray,
  MinLength,
  MaxLength,
  IsEmpty,
  IsOptional,
  ArrayNotEmpty,
  ArrayMinSize,
  IsEnum,
  Validate,
  ValidatorConstraint,
  ValidatorConstraintInterface,
  ValidationArguments,
} from 'class-validator';

@ValidatorConstraint({ name: 'PortionsMinMax', async: false })
class PortionsMinMaxConstraint implements ValidatorConstraintInterface {
  validate(portions_max: number, args: ValidationArguments): boolean {
    const object = args.object as any;
    return portions_max >= object.portions_min;
  }

  defaultMessage(args: ValidationArguments): string {
    return 'portions_max must be greater than or equal to portions_min';
  }
}

export class UpdateRecipeDto {
  @IsOptional()
  @IsString()
  @IsNotEmpty()
  title?: string;

  @IsOptional()
  @MaxLength(100)
  @IsNotEmpty()
  description?: string;

  @IsOptional()
  @MinLength(10)
  @IsNotEmpty()
  image_path?: string;

  @IsOptional()
  @IsArray()
  @ArrayNotEmpty()
  @ArrayMinSize(1)
  @IsString({ each: true })
  @MinLength(6, { each: true })
  @IsNotEmpty({ each: true })
  instructions?: string[];

  @IsOptional()
  @IsString()
  @IsNotEmpty()
  category_name?: string;

  @IsString()
  @IsNotEmpty()
  @IsOptional()
  cuisine_name?: string;

  @IsOptional()
  @IsArray()
  @ArrayNotEmpty()
  @ArrayMinSize(1)
  @IsString({ each: true })
  @IsNotEmpty()
  tags?: string[];

  @IsOptional()
  @IsArray()
  @IsNotEmpty()
  ingredients?: { name: string; quantity: string }[];

  @IsOptional()
  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  prep_time?: number;

  @IsOptional()
  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  portions_min?: number;

  @IsOptional()
  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  @Validate(PortionsMinMaxConstraint)
  portions_max?: number;

  @IsOptional()
  @IsEnum(DifficultyLevel, {
    message: 'Difficulty level must be Easy, Medium, or Hard',
  })
  @IsNotEmpty()
  difficulty_level?: DifficultyLevel;

  @IsOptional()
  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  protein?: number;

  @IsOptional()
  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  fat?: number;

  @IsOptional()
  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  carbs?: number;
}
