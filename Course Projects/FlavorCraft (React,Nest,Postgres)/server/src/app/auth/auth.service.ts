import {
  BadRequestException,
  Injectable,
  UnauthorizedException,
} from '@nestjs/common';
import { JwtService } from '@nestjs/jwt';
import * as bcrypt from 'bcrypt';
import { PrismaService } from '@database/prisma.service';
import { AuthRole } from '@common/constants/auth.const';
import { UserAuthPayload } from '@common/types/user.types';

@Injectable()
export class AuthService {
  constructor(
    private jwtService: JwtService,
    private prisma: PrismaService,
  ) {}

  async register(username: string, email: string, password: string) {
    const hashedPassword = await bcrypt.hash(password, 10);

    const user = await this.prisma.users.create({
      data: {
        username,
        email,
        password_hash: hashedPassword,
        role: AuthRole.User,
      },
    });

    return user;
  }

  async findUserByEmail(email: string) {
    return await this.prisma.users.findUnique({ where: { email } });
  }

  async validateUser(email: string, password: string) {
    const user = await this.findUserByEmail(email);

    if (!user) {
      throw new BadRequestException("User with this email doesn't exist");
    }

    const isPasswordValid = await this.isPasswordValid(
      password,
      user.password_hash,
    );

    if (!user || !isPasswordValid) {
      throw new UnauthorizedException('Invalid credentials');
    }

    return user;
  }

  async refreshAccessToken(refreshToken: string) {
    try {
      // Проверяем валидность refreshToken
      const payload = this.verifyToken(refreshToken) as UserAuthPayload;

      // Генерация нового accessToken
      const { accessToken } = this.generateTokens(payload);
      return { accessToken };
    } catch {
      throw new UnauthorizedException('Invalid refresh token');
    }
  }

  generateTokens(user: UserAuthPayload) {
    const payload = { id: user.id, role: user.role } as UserAuthPayload;
    const accessToken = this.jwtService.sign(payload, { expiresIn: '15m' });
    const refreshToken = this.jwtService.sign(payload, { expiresIn: '7d' });
    return { accessToken, refreshToken };
  }

  private async isPasswordValid(
    plainPassword: string,
    hashedPassword: string,
  ): Promise<boolean> {
    return await bcrypt.compare(plainPassword, hashedPassword);
  }

  verifyToken(token: string) {
    return this.jwtService.verify(token);
  }
}
