import axiosInstance from "config/axios";
import { BLOCK_COMMENT_URL } from "consts/queries/comment.const";
import { FETCH_RECIPE_BY_ID_URL } from "consts/queries/recipe.const";
import {
  BLOCK_USER_URL,
  CREATE_USER_ADMIN_URL,
  DELETE_USER_ADMIN_URL,
  FETCH_ALL_USERS_ADMIN_URL,
  FETCH_CURRENT_PROFILE_URL,
  FETCH_OTHER_PROFILE_URL,
  UPDATE_CURRENT_PROFILE_URL,
  UPDATE_USER_ADMIN_URL,
} from "consts/queries/user.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { User } from "types/entities/user";

export const getAllUsersAdminQuery = async () => {
  const response: CustomAxiosResponse<User[]> = await axiosInstance.get(
    FETCH_ALL_USERS_ADMIN_URL,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const createUserAdminQuery = async (payload: any) => {
  const response: CustomAxiosResponse<User> = await axiosInstance.post(
    CREATE_USER_ADMIN_URL,
    payload,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const updateUserAdminQuery = async (payload: any, userId: string) => {
  const response: CustomAxiosResponse<User> = await axiosInstance.patch(
    UPDATE_USER_ADMIN_URL + `/${userId}`,
    payload,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const deleteUserAdminQuery = async (userId: string) => {
  const response: CustomAxiosResponse<User> = await axiosInstance.delete(
    DELETE_USER_ADMIN_URL + `/${userId}`,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};
