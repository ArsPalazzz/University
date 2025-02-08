import axiosInstance from "config/axios";
import { BLOCK_COMMENT_URL } from "consts/queries/comment.const";
import { FETCH_FAV_RECIPES_URL } from "consts/queries/favourite.const";
import {
  BLOCK_RECIPE_URL,
  CREATE_RECIPE_URL,
  DELETE_RECIPE_URL,
  FETCH_DIET_RECIPES_URL,
  FETCH_MAIN_RECIPES_URL,
  FETCH_MY_RECIPES_URL,
  FETCH_RECIPE_BY_ID_URL,
  FETCH_RECIPES_BY_USER_ID_URL,
  FETCH_RECIPES_WITH_THE_SAME_CATEGORY_URL,
  FETCH_VEGETERIAN_RECIPES_URL,
  UPDATE_RECIPE_URL,
} from "consts/queries/recipe.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { Recipe, RecipeFull, RecipeMain } from "types/entities/recipe";

export const fetchMainVegetarianRecipesQuery = async () => {
  const response: CustomAxiosResponse<RecipeMain[]> = await axiosInstance.get(
    FETCH_VEGETERIAN_RECIPES_URL
  );
  return response.data;
};

export const fetchMainDietRecipesQuery = async () => {
  const response: CustomAxiosResponse<RecipeMain[]> = await axiosInstance.get(
    FETCH_DIET_RECIPES_URL
  );
  return response.data;
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

export const fetchFavRecipesQuery = async () => {
  const response: CustomAxiosResponse<RecipeMain[]> = await axiosInstance.get(
    FETCH_FAV_RECIPES_URL,
    { withCredentials: true }
  );
  return response.data;
};

export const fetchRecipesByAuthorIdQuery = async (
  authorId: string,
  except_id: string | undefined
) => {
  const aa = FETCH_RECIPES_BY_USER_ID_URL.replace("{userId}", authorId).replace(
    except_id ? "{exceptId}" : "&except_id={exceptId}",
    except_id || ""
  );

  const response: CustomAxiosResponse<RecipeMain[]> = await axiosInstance.get(
    aa
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

export const createRecipeQuery = async (data: any) => {
  const response: CustomAxiosResponse<string> = await axiosInstance.post(
    CREATE_RECIPE_URL,
    data,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const updateRecipeQuery = async (data: any, id: string) => {
  const response: CustomAxiosResponse<string> = await axiosInstance.patch(
    UPDATE_RECIPE_URL + id,
    data,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const deleteRecipeByIdQuery = async (recipeId: string) => {
  const response: CustomAxiosResponse<string> = await axiosInstance.delete(
    DELETE_RECIPE_URL + `/${recipeId}`,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const blockRecipeByIdQuery = async (recipeId: string) => {
  debugger;
  const response: CustomAxiosResponse<Recipe> = await axiosInstance.delete(
    BLOCK_RECIPE_URL + `/${recipeId}`,
    { withCredentials: true }
  );
  debugger;
  return response.data;
};
