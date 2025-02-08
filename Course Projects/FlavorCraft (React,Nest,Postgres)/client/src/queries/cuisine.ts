import axiosInstance from "config/axios";
import { FETCH_ALL_CUISINES_URL } from "consts/queries/cuisine.const";
import { CustomAxiosResponse } from "types/common/ApiResponse";
import { Cuisine } from "types/entities/cuisine";

export const fetchAllCuisinesQuery = async () => {
  const response: CustomAxiosResponse<Cuisine[]> = await axiosInstance.get(
    FETCH_ALL_CUISINES_URL
  );
  return response.data;
};
