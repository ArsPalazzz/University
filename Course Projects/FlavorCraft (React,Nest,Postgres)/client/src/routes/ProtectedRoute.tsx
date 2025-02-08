import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "providers/AuthContext"; // Ваш провайдер авторизации
import { MAIN_PAGE_PATH } from "consts/web-paths";
import { checkAuthQuery } from "queries/auth";
import { useQuery } from "@tanstack/react-query";

const ProtectedRoute = () => {
  const { user, isUserLoading } = useAuth();

  if (isUserLoading) {
    // Показать индикатор загрузки, пока идет проверка
    return <div>Loading...</div>;
  }

  if (!user) {
    return <Navigate to="/" replace />;
  }

  // Если пользователь авторизован, показываем дочерние компоненты
  return <Outlet />;
};

export default ProtectedRoute;
