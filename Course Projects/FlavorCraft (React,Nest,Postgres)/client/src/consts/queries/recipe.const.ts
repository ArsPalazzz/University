export const FETCH_MAIN_RECIPES_URL = "/recipes/mainRecipes";
export const FETCH_VEGETERIAN_RECIPES_URL =
  "/recipes?tags[]=vegetarian&limit=3";
export const FETCH_DIET_RECIPES_URL = "/recipes?tags[]=diet&limit=3";
export const FETCH_RECIPES_WITH_THE_SAME_CATEGORY_URL =
  "/recipes?categories[]={categoryId}&orderby=avg_rating&except_id={exceptId}&limit=3";
export const FETCH_MY_RECIPES_URL = "/recipes/myRecipes";
export const FETCH_RECIPES_BY_USER_ID_URL =
  "/recipes/author?user_id={userId}&except_id={exceptId}";
export const FETCH_RECIPE_BY_ID_URL = "/recipes/{recipeId}/full";

export const CREATE_RECIPE_URL = "/recipes";
export const UPDATE_RECIPE_URL = "/recipes/";
export const DELETE_RECIPE_URL = "/recipes";

export const BLOCK_RECIPE_URL = "/moderator/recipes";

export const FETCH_ALL_RECIPES_ADMIN_URL = "admin/recipes";
export const FETCH_RECIPE_BY_ID_ADMIN_URL = "admin/recipes";

export const CREATE_RECIPE_ADMIN_URL = "admin/recipes";
export const UPDATE_RECIPE_ADMIN_URL = "admin/recipes";
export const DELETE_RECIPE_ADMIN_URL = "admin/recipes";
