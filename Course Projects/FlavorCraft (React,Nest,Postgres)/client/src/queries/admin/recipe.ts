import axiosInstance from "config/axios";
import {
  CREATE_RECIPE_ADMIN_URL,
  DELETE_RECIPE_ADMIN_URL,
  FETCH_ALL_RECIPES_ADMIN_URL,
  FETCH_RECIPE_BY_ID_ADMIN_URL,
  UPDATE_RECIPE_ADMIN_URL,
} from "consts/queries/recipe.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { Recipe, RecipeFull } from "types/entities/recipe";

export const getAllRecipesAdminQuery = async () => {
  const response: CustomAxiosResponse<Recipe[]> = await axiosInstance.get(
    FETCH_ALL_RECIPES_ADMIN_URL,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const getFullRecipeByIdAdminQuery = async (recipeId: string) => {
  const response: CustomAxiosResponse<RecipeFull> = await axiosInstance.get(
    FETCH_RECIPE_BY_ID_ADMIN_URL + `/${recipeId}/full`,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const createRecipeAdminQuery = async (payload: any) => {
  const response: CustomAxiosResponse<string> = await axiosInstance.post(
    CREATE_RECIPE_ADMIN_URL,
    payload,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const updateRecipeAdminQuery = async (
  payload: any,
  recipeId: string
) => {
  const response: CustomAxiosResponse<RecipeFull> = await axiosInstance.patch(
    UPDATE_RECIPE_ADMIN_URL + `/${recipeId}`,
    payload,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const deleteRecipeAdminQuery = async (recipeId: string) => {
  const response: CustomAxiosResponse<Recipe> = await axiosInstance.delete(
    DELETE_RECIPE_ADMIN_URL + `/${recipeId}`,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};
