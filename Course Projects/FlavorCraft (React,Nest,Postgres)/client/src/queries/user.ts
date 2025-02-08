import axiosInstance from "config/axios";
import { BLOCK_COMMENT_URL } from "consts/queries/comment.const";
import { FETCH_RECIPE_BY_ID_URL } from "consts/queries/recipe.const";
import {
  BLOCK_USER_URL,
  FETCH_CURRENT_PROFILE_URL,
  FETCH_OTHER_PROFILE_URL,
  UPDATE_CURRENT_PROFILE_URL,
} from "consts/queries/user.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { UserProfile } from "types/entities/user";

export const getCurrentProfileQuery = async () => {
  const response: CustomAxiosResponse<UserProfile> = await axiosInstance.get(
    FETCH_CURRENT_PROFILE_URL,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const getAuthorProfileQuery = async (authorId: string) => {
  const response: CustomAxiosResponse<UserProfile> = await axiosInstance.get(
    FETCH_OTHER_PROFILE_URL + "/" + authorId,
    { skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const updateCurrentProfileQuery = async (
  data: { username: string },
  userId: string
) => {
  const response: CustomAxiosResponse<UserProfile> = await axiosInstance.patch(
    UPDATE_CURRENT_PROFILE_URL.replace("{userId}", userId),
    data,
    { withCredentials: true }
  );
  return response.data;
};

export const blockUserByIdQuery = async (userId: string, reason: string) => {
  debugger;
  const response: CustomAxiosResponse<string> = await axiosInstance.patch(
    BLOCK_USER_URL + `/${userId}`,
    { reason },
    { withCredentials: true }
  );
  return response.data;
};
