import { AuthModule } from '@auth/auth.module';
import { DatabaseModule } from '@database/database.module';
import { MiddlewareConsumer, Module } from '@nestjs/common';
import { FavouriteService } from './favourite.service';
import { FavouriteController } from './favourite.controller';
import { AuthService } from '@auth/auth.service';
import { UserMiddleware } from 'app/middlewares/UserMiddleware';

@Module({
  imports: [DatabaseModule, AuthModule],
  controllers: [FavouriteController],
  providers: [FavouriteService, AuthService],
})
export class FavouriteModule {
  configure(consumer: MiddlewareConsumer) {
    consumer.apply(UserMiddleware).forRoutes('*'); // Применить для всех маршрутов
  }
}
