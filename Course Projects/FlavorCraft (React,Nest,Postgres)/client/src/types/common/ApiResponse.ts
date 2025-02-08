import { AxiosResponse } from "axios";

export interface CustomAxiosResponse<T> extends AxiosResponse {
  data: T;
  message: string;
  status: number;
}
