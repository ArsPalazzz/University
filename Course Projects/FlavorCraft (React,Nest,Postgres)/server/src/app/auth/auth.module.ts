import { Module } from '@nestjs/common';
import { JwtModule } from '@nestjs/jwt';
import { AuthService } from '@auth/auth.service';
import { AuthController } from '@auth/auth.controller';
import { DatabaseModule } from '@database/database.module';
import { JwtStrategy } from '@auth/jwt.strategy';
import { ConfigModule, ConfigService } from '@nestjs/config';
import { UserService } from '@resources/users/user.service';
import { BaseFilterService } from '@common/filters/base-filter.service';
import { PrismaService } from '@database/prisma.service';

@Module({
  imports: [
    ConfigModule,
    JwtModule.registerAsync({
      imports: [ConfigModule],
      inject: [ConfigService],
      useFactory: async (configService: ConfigService) => ({
        secret: configService.get<string>('JWT_SECRET', 'secretKey'),
        signOptions: { expiresIn: '15m' },
      }),
    }),
    DatabaseModule,
  ],
  providers: [
    AuthService,
    JwtStrategy,
    UserService,
    BaseFilterService,
    PrismaService,
  ],
  controllers: [AuthController],
  exports: [JwtModule],
})
export class AuthModule {}
