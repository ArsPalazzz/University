import axiosInstance from "config/axios";
import { TOGGLE_FAVOURITES_URL } from "consts/queries/favourite.const";
import { CREATE_FOLLOW_URL, DELETE_FOLLOW_URL } from "consts/queries/follow";
import { CustomAxiosResponse } from "types/common/ApiResponse";

export const createFollowQuery = async (data: { followed_id: string }) => {
  debugger;
  const response: CustomAxiosResponse<boolean> = await axiosInstance.post(
    CREATE_FOLLOW_URL,
    data,
    { withCredentials: true }
  );
  return response.data as boolean;
};

export const deleteFollowQuery = async (data: { followed_id: string }) => {
  debugger;
  const response: CustomAxiosResponse<boolean> = await axiosInstance.delete(
    DELETE_FOLLOW_URL + `/${data.followed_id}`,
    { withCredentials: true }
  );
  return response.data as boolean;
};
