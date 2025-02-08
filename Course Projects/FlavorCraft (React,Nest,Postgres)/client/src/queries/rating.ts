import axiosInstance from "config/axios";
import { UPDATE_RATING_URL } from "consts/queries/rating";
import { CustomAxiosResponse } from "types/common/ApiResponse";

export const updateRatingQuery = async (
  data: { rating: string },
  ratingId: number
) => {
  debugger;
  const response: CustomAxiosResponse<boolean> = await axiosInstance.patch(
    UPDATE_RATING_URL + `/${ratingId}`,
    data,
    { withCredentials: true }
  );
  return response.data as boolean;
};
