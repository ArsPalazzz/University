import { DifficultyLevel } from '@common/constants/difficulty_level.const';
import { ApiProperty } from '@nestjs/swagger';
import {
  IsString,
  IsNotEmpty,
  MinLength,
  MaxLength,
  IsNumber,
  IsPositive,
  IsArray,
  ArrayNotEmpty,
  ArrayMinSize,
  Validate,
  ValidatorConstraint,
  ValidatorConstraintInterface,
  ValidationArguments,
  IsEnum,
  IsOptional,
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

export class CreateRecipeDto {
  @IsString()
  @IsNotEmpty()
  title: string;

  @IsString()
  @IsNotEmpty()
  @MaxLength(100)
  description: string;

  @MinLength(10)
  @IsNotEmpty()
  @IsOptional()
  image_path: string;

  @IsArray()
  @ArrayNotEmpty()
  @ArrayMinSize(1)
  @IsString({ each: true })
  @MinLength(6, { each: true })
  @IsNotEmpty({ each: true })
  instructions: string[];

  @IsString()
  @IsNotEmpty()
  category_name: string;

  @IsString()
  @IsNotEmpty()
  @IsOptional()
  cuisine_name?: string;

  @IsArray()
  @ArrayNotEmpty()
  @ArrayMinSize(1)
  @IsString({ each: true })
  @IsNotEmpty()
  tags: string[];

  @IsArray()
  @IsNotEmpty()
  ingredients: { name: string; quantity: string }[];

  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  prep_time: number;

  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  portions_min: number;

  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  @Validate(PortionsMinMaxConstraint)
  portions_max: number;

  @IsEnum(DifficultyLevel, {
    message: 'Difficulty level must be Easy, Medium, or Hard',
  })
  @IsNotEmpty()
  difficulty_level: DifficultyLevel;

  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  protein: number;

  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  fat: number;

  @IsNumber()
  @IsNotEmpty()
  @IsPositive()
  carbs: number;
}
