import axiosInstance from "config/axios";
import {
  CREATE_FOLLOW_ADMIN_URL,
  DELETE_FOLLOW_ADMIN_URL,
  FETCH_ALL_FOLLOWS_ADMIN_URL,
  UPDATE_FOLLOW_ADMIN_URL,
} from "consts/queries/follow";
import {
  CREATE_INGREDIENT_ADMIN_URL,
  DELETE_INGREDIENT_ADMIN_URL,
  FETCH_ALL_INGREDIENTS_ADMIN_URL,
  UPDATE_INGREDIENT_ADMIN_URL,
} from "consts/queries/ingredient";
import { FETCH_ALL_USERS_ADMIN_URL } from "consts/queries/user.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { Follow } from "types/entities/follow";
import { Ingredient } from "types/entities/ingredient";
import { User } from "types/entities/user";

export const getAllFollowsAdminQuery = async () => {
  const response: CustomAxiosResponse<Follow[]> = await axiosInstance.get(
    FETCH_ALL_FOLLOWS_ADMIN_URL,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const createFollowAdminQuery = async (payload: {
  follower_id: string;
  followed_id: string;
}) => {
  const response: CustomAxiosResponse<Follow> = await axiosInstance.post(
    CREATE_FOLLOW_ADMIN_URL,
    payload,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const updateFollowAdminQuery = async (
  payload: { follower_id: string; followed_id: string },
  followId: number
) => {
  const response: CustomAxiosResponse<Follow> = await axiosInstance.patch(
    UPDATE_FOLLOW_ADMIN_URL + `/${followId}`,
    payload,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};

export const deleteFollowAdminQuery = async (followId: number) => {
  const response: CustomAxiosResponse<Follow> = await axiosInstance.delete(
    DELETE_FOLLOW_ADMIN_URL + `/${followId}`,
    { withCredentials: true, skipGlobalErrorHandler: true }
  );
  return response.data;
};
