import axiosInstance from "config/axios";
import {
  IS_RECIPE_IN_FAVOURITES_URL,
  TOGGLE_FAVOURITES_URL,
} from "consts/queries/favourite.const";
import {
  FETCH_DIET_RECIPES_URL,
  FETCH_MAIN_RECIPES_URL,
  FETCH_MY_RECIPES_URL,
  FETCH_RECIPE_BY_ID_URL,
  FETCH_RECIPES_WITH_THE_SAME_CATEGORY_URL,
  FETCH_VEGETERIAN_RECIPES_URL,
} from "consts/queries/recipe.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { RecipeFull, RecipeMain } from "types/entities/recipe";

export const isRecipeInFavouritesQuery = async (recipeId: string) => {
  const response: CustomAxiosResponse<boolean> = await axiosInstance.get(
    IS_RECIPE_IN_FAVOURITES_URL.replace("{recipeId}", recipeId),
    { withCredentials: true }
  );
  return response.data;
};

export const toggleToFavouritesQuery = async (data: { recipeId: string }) => {
  debugger;
  const response: CustomAxiosResponse<boolean> = await axiosInstance.post(
    TOGGLE_FAVOURITES_URL,
    { recipe_id: data.recipeId },
    { withCredentials: true }
  );
  return response.data as boolean;
};

export const fetchRecipesWithTheSameCategoryQuery = async (
  exceptId: string,
  categoryId: number | null
) => {
  const response: CustomAxiosResponse<RecipeMain[]> = await axiosInstance.get(
    FETCH_RECIPES_WITH_THE_SAME_CATEGORY_URL.replace(
      "{exceptId}",
      exceptId
    ).replace("{categoryId}", (categoryId || -1).toString())
  );
  return response.data;
};

export const fetchMyRecipesQuery = async () => {
  const response: CustomAxiosResponse<RecipeMain[]> = await axiosInstance.get(
    FETCH_MY_RECIPES_URL,
    { withCredentials: true }
  );
  return response.data;
};

export const fetchFullRecipeByIdQuery = async (id: string) => {
  const response: CustomAxiosResponse<RecipeFull> = await axiosInstance.get(
    FETCH_RECIPE_BY_ID_URL.replace("{recipeId}", id),
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};
