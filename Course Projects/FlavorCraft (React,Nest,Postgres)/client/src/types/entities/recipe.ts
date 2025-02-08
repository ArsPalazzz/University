export interface Recipe {
  id: string;
  user_id: string;
  cuisine_id: number;
  title: string;
  description: string;
  image_path: string;
  instructions: string[];
  created_at: string;
  prep_time: number;
  calories: number;
  protein: number;
  fats: number;
  carbs: number;
  avg_rating: string;
  status: RecipeStatus;
  category_id: number;
}

export interface RecipeMain {
  id: string;
  author_name: string;
  cuisine_name: string;
  title: string;
  image_path: string;
  created_at: string;
  avg_rating: string;
  rating_count: number;
}

export interface RecipeFilter {
  id: string;
  author_name: string;
  title: string;
  image_path: string;
  created_at: string;
  avg_rating: string;
  rating_count: number;
}

export interface RecipeFull extends Recipe {
  rating_count: number;
  ratingId: number;
  difficulty_level: string;
  portions_min: number;
  portions_max: number;
  cuisine: {
    id: number;
    name: string;
  };
  comments: {
    id: number;
    content: string;
    created_at: Date;
    authorName: string;
    authorId: string;
    avatarUrl: string;
    rating: string;
  }[];
  has_rated: boolean;
  category_name: string;
  user: {
    id: string;
    name: string;
    avatar_url: string;
  };
  ingredients: {
    id: string;
    name: string;
    quantity: string;
  }[];
  tags: {
    id: string;
    name: string;
    query_key: string;
  }[];
}

export enum RecipeStatus {
  PENDING = "pending",
  PUBLISHES = "published",
  ARCHIEVED = "archieved",
  BLOCKED = "blocked",
}
