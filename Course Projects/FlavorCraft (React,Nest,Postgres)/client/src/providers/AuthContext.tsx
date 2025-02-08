// AuthContext.tsx
import React, {
  createContext,
  useState,
  useContext,
  ReactNode,
  useEffect,
} from "react";
import axios from "axios";
import axiosInstance from "config/axios";
import {
  checkAuthQuery,
  loginQuery,
  LoginQueryParams,
  logoutQuery,
  registerQuery,
  RegisterQueryParams,
} from "queries/auth";
import { useQuery, useQueryClient } from "@tanstack/react-query";
import { getCurrentProfileQuery } from "queries/user";
import { UserProfile } from "types/entities/user";
import { AuthRole } from "consts/entities/user.const";
import { useNavigate } from "react-router-dom";

interface AuthContextType {
  user: UserProfile | null;
  isUserLoading: boolean;
  login: ({ email, password }: LoginQueryParams) => Promise<boolean>;
  register: ({
    email,
    username,
    password,
  }: RegisterQueryParams) => Promise<boolean>;
  logout: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider");
  }
  return context;
};

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const queryClient = useQueryClient();

  const {
    data: user = null,
    isLoading,
    error,
    refetch,
  } = useQuery({
    queryKey: ["current-profile"],
    queryFn: async (): Promise<UserProfile | null> => {
      return (await getCurrentProfileQuery()) || null;
    },
    retry: false,
  });

  const login = async ({
    email,
    password,
  }: {
    email: string;
    password: string;
  }) => {
    try {
      const userInfo = await loginQuery({ email, password });
      queryClient.setQueryData(["current-profile"], userInfo.data.user); // Update cache
      return true;
    } catch (error) {
      console.error("Login failed", error);
      return false;
    }
  };

  const register = async ({
    email,
    username,
    password,
  }: {
    email: string;
    username: string;
    password: string;
  }) => {
    try {
      await registerQuery({ email, username, password });
      //await refetch(); // Refresh the user profile
      return true;
    } catch (error) {
      console.error("Registration failed", error);
      return false;
    }
  };

  const logout = async () => {
    try {
      await logoutQuery();
      queryClient.setQueryData(["current-profile"], null); // Clear user profile
    } catch (error) {
      console.error("Logout failed", error);
    }
  };

  return (
    <AuthContext.Provider
      value={{ user, isUserLoading: isLoading, login, register, logout }}
    >
      {children}
    </AuthContext.Provider>
  );
};
