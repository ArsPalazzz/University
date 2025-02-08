import { Injectable, HttpException, HttpStatus } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';
import axios from 'axios';

@Injectable()
export class SpoonacularService {
  private readonly apiKey: string;
  private readonly baseUrl: string;

  constructor(private readonly configService: ConfigService) {
    this.apiKey = this.configService.get<string>('SPOONACULAR_API_KEY');
    this.baseUrl = this.configService.get<string>('SPOONACULAR_BASE_URL');

    if (!this.apiKey || !this.baseUrl) {
      throw new Error('Error connecting Spoonacular API!');
    }
  }

  async validateIngredient(ingredient: string): Promise<boolean> {
    try {
      const response = await axios.get(`${this.baseUrl}/search`, {
        params: {
          query: ingredient,
          apiKey: this.apiKey,
        },
      });

      return response.data.results && response.data.results.length > 0;
    } catch (error) {
      throw new HttpException(
        `Error connection to Spoonacular API: ${error}`,
        HttpStatus.BAD_REQUEST,
      );
    }
  }
}
