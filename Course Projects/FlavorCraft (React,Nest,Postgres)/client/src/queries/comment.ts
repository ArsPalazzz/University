import axiosInstance from "config/axios";
import {
  BLOCK_COMMENT_URL,
  CREATE_COMMENT_URL,
} from "consts/queries/comment.const";
import { DELETE_RECIPE_URL } from "consts/queries/recipe.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";

interface CreateReviewQueryParams {
  recipe_id: string;
  content: string;
  rating?: number;
}

export const createReviewQuery = async ({
  recipe_id,
  content,
  rating,
}: CreateReviewQueryParams) => {
  debugger;
  return axiosInstance.post(
    CREATE_COMMENT_URL,
    {
      recipe_id,
      content,
      rating,
    },
    { withCredentials: true }
  );
};

export const blockCommentByIdQuery = async (commentId: number) => {
  debugger;
  const response: CustomAxiosResponse<string> = await axiosInstance.patch(
    BLOCK_COMMENT_URL + `/${commentId}`,
    {},
    { withCredentials: true }
  );
  return response.data;
};
