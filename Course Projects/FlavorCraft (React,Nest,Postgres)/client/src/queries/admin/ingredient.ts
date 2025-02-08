import axiosInstance from "config/axios";
import {
  CREATE_INGREDIENT_ADMIN_URL,
  DELETE_INGREDIENT_ADMIN_URL,
  FETCH_ALL_INGREDIENTS_ADMIN_URL,
  UPDATE_INGREDIENT_ADMIN_URL,
} from "consts/queries/ingredient";
import { FETCH_ALL_USERS_ADMIN_URL } from "consts/queries/user.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { Ingredient } from "types/entities/ingredient";
import { User } from "types/entities/user";

export const getAllIngredientsAdminQuery = async () => {
  const response: CustomAxiosResponse<Ingredient[]> = await axiosInstance.get(
    FETCH_ALL_INGREDIENTS_ADMIN_URL,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const createIngredientAdminQuery = async (payload: { name: string }) => {
  const response: CustomAxiosResponse<Ingredient> = await axiosInstance.post(
    CREATE_INGREDIENT_ADMIN_URL,
    payload,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const updateIngredientAdminQuery = async (
  payload: { name: string },
  ingredientId: number
) => {
  const response: CustomAxiosResponse<Ingredient> = await axiosInstance.patch(
    UPDATE_INGREDIENT_ADMIN_URL + `/${ingredientId}`,
    payload,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const deleteIngredientAdminQuery = async (ingredientId: number) => {
  const response: CustomAxiosResponse<Ingredient> = await axiosInstance.delete(
    DELETE_INGREDIENT_ADMIN_URL + `/${ingredientId}`,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};
