import axiosInstance from "config/axios";
import {
  CHECK_AUTH_URL,
  LOGIN_URL,
  LOGOUT_URL,
  REGISTER_URL,
} from "consts/queries/auth.const";

export interface LoginQueryParams {
  email: string;
  password: string;
}

export interface RegisterQueryParams extends LoginQueryParams {
  username: string;
}

export const checkAuthQuery = async () => {
  return axiosInstance.get(CHECK_AUTH_URL, { withCredentials: true });
};

export const loginQuery = async ({ email, password }: LoginQueryParams) => {
  return axiosInstance.post(
    LOGIN_URL,
    {
      email,
      password,
    },
    { withCredentials: true }
  );
};

export const registerQuery = async ({
  email,
  username,
  password,
}: RegisterQueryParams) => {
  return axiosInstance.post(REGISTER_URL, {
    email,
    username,
    password,
  });
};

export const logoutQuery = async () => {
  return axiosInstance.post(LOGOUT_URL, {}, { withCredentials: true });
};
