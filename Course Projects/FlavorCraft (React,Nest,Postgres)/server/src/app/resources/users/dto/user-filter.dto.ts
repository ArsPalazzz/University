import { IsOptional, IsString, IsEmail } from 'class-validator';

export class UserFilterDto {
  @IsOptional()
  @IsString()
  username?: string;

  @IsOptional()
  @IsEmail()
  email?: number;
}
