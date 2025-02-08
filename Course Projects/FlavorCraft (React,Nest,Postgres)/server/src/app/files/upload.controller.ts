import {
  BadRequestException,
  Controller,
  Post,
  UploadedFile,
  UseGuards,
  UseInterceptors,
} from '@nestjs/common';
import { AuthGuard } from '@nestjs/passport';
import { FileInterceptor } from '@nestjs/platform-express';
import { RecipeService } from '@resources/recipes/recipe.service';
import { UserService } from '@resources/users/user.service';
import { diskStorage } from 'multer';
import { extname } from 'path';

@Controller('upload')
export class UploadController {
  constructor(
    private readonly userService: UserService,
    private readonly recipeService: RecipeService,
  ) {}

  @Post('file')
  @UseInterceptors(
    FileInterceptor('file', {
      storage: diskStorage({
        destination: './uploads', // Путь для сохранения файлов
        filename: (req, file, callback) => {
          const { type, id } = req.query;
          if (!type || !id) {
            return callback(
              new BadRequestException('Type and ID are required'),
              '',
            );
          }
          const ext = extname(file.originalname); // Расширение файла
          callback(null, `${type}_${id}${ext}`);
        },
      }),
    }),
  )
  uploadFile(@UploadedFile() file: Express.Multer.File) {
    if (file.filename.includes('user')) {
      const userId1 = file.filename.split('user_')[1];
      const userId2 = userId1.split('.jpg')[0];
      this.userService.updateOneById({
        id: userId2,
        payload: { avatar_url: `/uploads/${file.filename}` },
        ok: true,
      });
      console.log(userId2);
    }

    return {
      message: 'File uploaded successfully',
      filePath: `/uploads/${file.filename}`, // Возвращаем путь к файлу
    };
  }
}
