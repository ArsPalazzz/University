import axiosInstance from "config/axios";
import { CustomAxiosResponse } from "types/common/ApiResponse";

interface IUploadImageQuery {
  type: string;
  id: string;
  formData: FormData;
}

export const uploadImageQuery = async ({
  type,
  id,
  formData,
}: IUploadImageQuery) => {
  const response: CustomAxiosResponse<any> = await axiosInstance.post(
    `/upload/file?type=${type}&id=${id}`,
    formData,
    {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    }
  );
  return response.data;
};
