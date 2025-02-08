import {
  Controller,
  Post,
  Body,
  Res,
  Get,
  Req,
  HttpStatus,
  UnauthorizedException,
} from '@nestjs/common';
import { AuthService } from '@auth/auth.service';
import { LoginDto } from '@auth/dto/login.dto';
import { RegisterDto } from '@auth/dto/register.dto';
import { Request, Response } from 'express';
import { UserAuthPayload } from '@common/types/user.types';
import { UserService } from '@resources/users/user.service';
import { PrismaService } from '@database/prisma.service';

@Controller('auth')
export class AuthController {
  constructor(
    private authService: AuthService,
    private prismaService: PrismaService,
    private readonly userService: UserService,
  ) {}

  @Post('register')
  async register(@Body() body: RegisterDto, @Res() res: Response) {
    const isUserExists = await this.authService.findUserByEmail(body.email);
    if (isUserExists) {
      return res
        .status(HttpStatus.BAD_REQUEST)
        .send({ message: 'User with this email is already exists' });
    }

    await this.authService.register(body.username, body.email, body.password);

    return res.send({ message: 'User registered successfully' });
  }

  @Post('login')
  async login(
    @Body() body: LoginDto,
    @Req() req: Request,
    @Res() res: Response,
  ) {
    const isTokenExist = !!req.cookies['accessToken'];
    if (isTokenExist) {
      return res.status(HttpStatus.BAD_REQUEST).json({
        message: 'You are already logged in.',
      });
    }

    const user = await this.authService.validateUser(body.email, body.password);

    if (user.is_blocked) {
      const bannedUser = await this.prismaService.banned_users.findUnique({
        where: { user_id: user.id },
      });

      throw new UnauthorizedException(
        `You has been banned. Reason: ${bannedUser.reason}`,
      );
    }

    const { accessToken, refreshToken } = this.authService.generateTokens(
      user as UserAuthPayload,
    );

    res.cookie('accessToken', accessToken, {
      httpOnly: true,
      secure: process.env.NODE_ENV === 'production',
      maxAge: 15 * 60 * 1000,
      sameSite: 'strict',
      path: '/',
    });

    res.cookie('refreshToken', refreshToken, {
      httpOnly: true,
      secure: process.env.NODE_ENV === 'production',
      maxAge: 7 * 24 * 60 * 60 * 1000,
      sameSite: 'strict',
      path: '/',
    });

    return res.status(HttpStatus.OK).send({
      message: 'Login successful',
      user: {
        id: user.id,
        username: user.username,
        email: user.email,
        avatar_url: user.avatar_url,
      },
    });
  }

  @Post('refresh')
  async refresh(@Req() req: Request, @Res() res: Response) {
    const refreshToken = req.cookies['refreshToken'];
    if (!refreshToken) {
      throw new UnauthorizedException('Refresh token not found');
    }

    try {
      const payload = this.authService.verifyToken(
        refreshToken,
      ) as UserAuthPayload;

      // Генерация нового Access токена
      const { accessToken } = this.authService.generateTokens(payload);

      // Обновляем Access token
      res.cookie('accessToken', accessToken, {
        httpOnly: true,
        maxAge: 15 * 60 * 1000,
      });
      return res.send({ message: 'Token refreshed successfully' });
    } catch {
      throw new UnauthorizedException('Invalid refresh token');
    }
  }

  @Post('logout')
  async logout(@Res() res: Response) {
    res.clearCookie('accessToken');
    res.clearCookie('refreshToken');

    return res.status(200).send({
      message: 'Successfully logged out',
    });
  }

  @Get('check-auth')
  async checkAuth(@Req() req: Request, @Res() res: Response) {
    const jwt = req.cookies['accessToken'];
    if (!jwt) return res.status(200).json({ authenticated: false });

    try {
      const payload = this.authService.verifyToken(jwt);

      const user = await this.userService.findOneById(payload.id);

      if (!user) {
        throw new UnauthorizedException('User not found');
      }

      return res.status(200).json({
        authenticated: true,
        user: {
          id: user.id,
          username: user.username,
          email: user.email,
          avatar_url: user.avatar_url,
        },
      });
    } catch {
      return res
        .status(401)
        .json({ authenticated: false, message: 'Invalid token' });
    }
  }
}
