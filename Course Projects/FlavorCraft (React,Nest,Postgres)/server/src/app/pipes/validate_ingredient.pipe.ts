import {
  ArgumentMetadata,
  Injectable,
  PipeTransform,
  BadRequestException,
} from '@nestjs/common';
import { SpoonacularService } from '../spoonacular/spoonacular.service';

@Injectable()
export class ValidateIngredientPipe implements PipeTransform {
  constructor(private readonly spoonacularService: SpoonacularService) {}

  async transform(value: any, metadata: ArgumentMetadata) {
    const ingredients = value.ingredients;
    const ingredient = value.name;

    if (ingredient) {
      if (typeof ingredient !== 'string') {
        throw new BadRequestException('Ingredient should be a string');
      }

      const isValid =
        await this.spoonacularService.validateIngredient(ingredient);

      if (!isValid) {
        throw new BadRequestException(`Name of the ingredient is not correct`);
      }

      return value;
    } else {
      if (!Array.isArray(ingredients)) {
        throw new BadRequestException('Ingredients should be an array');
      }

      for (const item of ingredients) {
        if (!item.name || typeof item.name !== 'string') {
          throw new BadRequestException('Field "name" should be a string');
        }

        if (!item.quantity || typeof item.quantity !== 'string') {
          throw new BadRequestException('Field "quantity" should be a string');
        }

        const isValid = await this.spoonacularService.validateIngredient(
          item.name,
        );
        if (!isValid) {
          throw new BadRequestException(
            `Name of the ingredient is not correct`,
          );
        }
      }

      return value;
    }
  }
}
