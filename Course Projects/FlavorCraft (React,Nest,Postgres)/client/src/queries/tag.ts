import axiosInstance from "config/axios";
import { FETCH_ALL_CATEGORIES_URL } from "consts/queries/category.const";
import { FETCH_ALL_TAGS_URL } from "consts/queries/tag.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { Category } from "types/entities/category";
import { Tag } from "types/entities/tag";

export const fetchAllTagsQuery = async () => {
  const response: CustomAxiosResponse<Tag[]> = await axiosInstance.get(
    FETCH_ALL_TAGS_URL
  );
  return response.data;
};
