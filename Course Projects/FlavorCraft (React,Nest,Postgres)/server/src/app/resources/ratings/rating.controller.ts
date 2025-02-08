import { AuthGuard } from '@guards/auth.guard';
import {
  Body,
  Controller,
  Get,
  Param,
  ParseIntPipe,
  Patch,
  Post,
  Put,
  Req,
  UseGuards,
} from '@nestjs/common';
import { CreateRatingDto } from './dto/create-rating.dto';
import { RatingService } from './rating.service';
import { UpdateRatingDto } from './dto/update-rating.dto';

@Controller('ratings')
export class RatingController {
  constructor(private readonly ratingService: RatingService) {}

  @Get()
  async getAllRatings() {
    return this.ratingService.findAll();
  }

  @Get(':id')
  async getRatingById(@Param('id') id: number) {
    return this.ratingService.findOneById(id);
  }

  @UseGuards(AuthGuard)
  @Post()
  async createRating(@Body() createRatingDto: CreateRatingDto, @Req() req) {
    const user_id = req.user.id as string;
    return this.ratingService.createRating({ ...createRatingDto, user_id });
  }

  @UseGuards(AuthGuard)
  @Patch(':id')
  async updateRating(
    @Param('id', ParseIntPipe) id: number,
    @Body() updateRatingDto: UpdateRatingDto,
  ) {
    return this.ratingService.updateRating(id, updateRatingDto);
  }
}
