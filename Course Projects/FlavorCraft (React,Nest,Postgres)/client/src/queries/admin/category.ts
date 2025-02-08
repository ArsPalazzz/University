import axiosInstance from "config/axios";
import {
  CREATE_CATEGORY_ADMIN_URL,
  DELETE_CATEGORY_ADMIN_URL,
  FETCH_ALL_CATEGORIES_URL,
  UPDATE_CATEGORY_ADMIN_URL,
} from "consts/queries/category.const";
import {
  CREATE_INGREDIENT_ADMIN_URL,
  DELETE_INGREDIENT_ADMIN_URL,
  FETCH_ALL_INGREDIENTS_ADMIN_URL,
  UPDATE_INGREDIENT_ADMIN_URL,
} from "consts/queries/ingredient";
import { FETCH_ALL_USERS_ADMIN_URL } from "consts/queries/user.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { Category } from "types/entities/category";
import { Ingredient } from "types/entities/ingredient";
import { User } from "types/entities/user";

export const getAllCategoriesAdminQuery = async () => {
  const response: CustomAxiosResponse<Category[]> = await axiosInstance.get(
    FETCH_ALL_CATEGORIES_URL,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const createCategoryAdminQuery = async (payload: { name: string }) => {
  const response: CustomAxiosResponse<Category> = await axiosInstance.post(
    CREATE_CATEGORY_ADMIN_URL,
    payload,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const updateCategoryAdminQuery = async (
  payload: { name: string },
  categoryId: number
) => {
  const response: CustomAxiosResponse<Category> = await axiosInstance.patch(
    UPDATE_CATEGORY_ADMIN_URL + `/${categoryId}`,
    payload,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const deleteCategoryAdminQuery = async (categoryId: number) => {
  const response: CustomAxiosResponse<Category> = await axiosInstance.delete(
    DELETE_CATEGORY_ADMIN_URL + `/${categoryId}`,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};
