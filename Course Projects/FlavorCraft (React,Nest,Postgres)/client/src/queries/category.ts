import axiosInstance from "config/axios";
import { FETCH_ALL_CATEGORIES_URL } from "consts/queries/category.const";
import { FETCH_FAV_RECIPES_URL } from "consts/queries/favourite.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { Category } from "types/entities/category";
import { RecipeMain } from "types/entities/recipe";

export const fetchAllCategoriesQuery = async () => {
  const response: CustomAxiosResponse<Category[]> = await axiosInstance.get(
    FETCH_ALL_CATEGORIES_URL
  );
  return response.data;
};
