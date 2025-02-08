import { recipes } from '@prisma/client';

export interface RecipeResponseWithUser extends recipes {
  ratings: {
    id: number;
    rating: number;
    user_id: string;
  }[];
  cuisines: {
    id: number;
    name: string;
  };
  categories: {
    name: string;
  };
  users: {
    id: string;
    username: string;
    avatar_url: string;
  };
  comments: {
    id: number;
    content: string;
    created_at: Date;
    users: {
      username: string;
      id: string;
      avatar_url: string;
    };
  }[];
  recipes_ingredients: {
    ingredients: {
      id: number;
      name: string;
    };
    recipe_id: string;
    ingredient_id: number;
    quantity: string;
  }[];
  recipes_tags: {
    tags: {
      id: number;
      name: string;
      query_key: string;
    };
  }[];
}
