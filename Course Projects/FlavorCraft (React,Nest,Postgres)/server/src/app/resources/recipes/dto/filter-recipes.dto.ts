import { Type } from 'class-transformer';
import {
  IsOptional,
  IsString,
  IsNumber,
  IsArray,
  IsPositive,
} from 'class-validator';

export class FilterRecipesDto {
  @IsOptional()
  @IsString()
  search?: string;

  @IsOptional()
  @Type(() => Number)
  @IsNumber()
  minCalories?: number;

  @IsOptional()
  @Type(() => Number)
  @IsNumber()
  maxCalories?: number;

  @IsOptional()
  @IsArray()
  @Type(() => String)
  @IsString({ each: true })
  categories?: string[];

  @IsOptional()
  @IsArray()
  @Type(() => String)
  @IsString({ each: true })
  tags?: string[];

  @IsOptional()
  @IsString()
  sortBy?: string;

  @IsOptional()
  @IsString()
  order?: 'asc' | 'desc';

  @IsOptional()
  @Type(() => Number)
  @IsNumber()
  @IsPositive()
  limit?: number;

  @IsOptional()
  @Type(() => Number)
  @IsNumber()
  @IsPositive()
  page?: number;

  @IsOptional()
  @Type(() => String)
  @IsString()
  except_id?: string;
}
