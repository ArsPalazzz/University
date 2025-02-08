import { AuthService } from '@auth/auth.service';
import {
  Injectable,
  CanActivate,
  ExecutionContext,
  UnauthorizedException,
  ForbiddenException,
} from '@nestjs/common';
import { Reflector } from '@nestjs/core';
import { JwtService } from '@nestjs/jwt';
import { Response } from 'express';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(
    private readonly jwtService: JwtService,
    private readonly reflector: Reflector,
    private readonly authService: AuthService,
  ) {}

  async canActivate(context: ExecutionContext): Promise<boolean> {
    const request = context.switchToHttp().getRequest();
    const response = context.switchToHttp().getResponse<Response>();

    const accessToken = request.cookies['accessToken'];
    const refreshToken = request.cookies['refreshToken'];

    if (!accessToken && !refreshToken) {
      throw new UnauthorizedException('User not authenticated');
    }

    try {
      if (accessToken) {
        const payload = this.jwtService.verify(accessToken);
        request.user = payload;

        const roles = this.getRoles(context);
        if (roles.length && !roles.includes(payload.role)) {
          throw new ForbiddenException('Insufficient role');
        }

        return true;
      }
    } catch (error) {
      if (error.name !== 'TokenExpiredError') {
        throw new UnauthorizedException('Invalid token');
      }
    }

    if (refreshToken) {
      try {
        const newTokens =
          await this.authService.refreshAccessToken(refreshToken);

        // Устанавливаем новый accessToken в куки
        response.cookie('accessToken', newTokens.accessToken, {
          httpOnly: true,
          maxAge: 15 * 60 * 1000, // 15 минут
        });

        request.user = this.jwtService.verify(newTokens.accessToken);

        // Проверяем роли для нового токена
        const roles = this.getRoles(context);
        if (roles.length && !roles.includes(request.user.role)) {
          throw new ForbiddenException('Insufficient role');
        }

        return true;
      } catch {
        throw new UnauthorizedException('Unable to refresh token');
      }
    }

    throw new UnauthorizedException('User not authenticated');
  }

  private getRoles(context: ExecutionContext): string[] {
    const handlerRoles =
      this.reflector.get<string[]>('roles', context.getHandler()) || [];
    const classRoles =
      this.reflector.get<string[]>('roles', context.getClass()) || [];
    return [...classRoles, ...handlerRoles];
  }
}
