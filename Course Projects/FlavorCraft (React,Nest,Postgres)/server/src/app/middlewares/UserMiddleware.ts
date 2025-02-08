import { UserAuthPayload } from '@common/types/user.types';
import { Injectable, NestMiddleware } from '@nestjs/common';
import { JwtService } from '@nestjs/jwt';
import { Request, Response, NextFunction } from 'express';

@Injectable()
export class UserMiddleware implements NestMiddleware {
  constructor(private readonly jwtService: JwtService) {}

  async use(req: Request, res: Response, next: NextFunction) {
    const accessToken = req.cookies['accessToken'];
    if (accessToken) {
      try {
        // Расшифровка токена (замените `your-secret-key` на ваш секретный ключ)
        const decoded = this.jwtService.verify(accessToken);
        req['user'] = decoded as UserAuthPayload; // Добавляем данные пользователя в request
      } catch (err) {
        console.error('Invalid token:', err.message);
      }
    }
    next();
  }
}
