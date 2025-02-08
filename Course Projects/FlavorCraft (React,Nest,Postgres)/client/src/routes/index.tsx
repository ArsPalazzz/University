import React, { lazy, Suspense } from "react";
import { Route, Routes } from "react-router-dom";
import MainLayout from "../layouts/MainLayout";
import LoadingSpinner from "../components/LoadingSpinner/LoadingSpinner";
import NotFoundPage from "pages/NotFoundPage";
import RecipePage from "pages/RecipePage/RecipePage";
import {
  ALL_RECIPES_PAGE_PATH,
  AUTHOR_PAGE_PATH,
  CREATE_RECIPE_PAGE_PATH,
  EDIT_RECIPE_PAGE_PATH,
  MAIN_PAGE_PATH,
  PROFILE_PAGE_PATH,
  RECIPE_PAGE_PATH,
} from "consts/web-paths";
import ProtectedRoute from "./ProtectedRoute";
import AuthorPage from "pages/AuthorPage/AuthorPage";
import { AllRecipesPage } from "pages/AllRecipesPage/AllRecipesPage";

// Ленивая загрузка страниц
const HomePage = lazy(() => import("../pages/HomePage/HomePage"));
// const RecipesPage = lazy(() => import("../pages/RecipesPage"));
// const NotFoundPage = lazy(() => import("../pages/NotFoundPage"));
const ProfilePage = lazy(() => import("../pages/ProfilePage/ProfilePage"));
const CreateRecipePage = lazy(
  () => import("../pages/CreateRecipePage/CreateRecipePage")
);

const AppRoutes: React.FC = () => {
  return (
    <Routes>
      {/* Основной layout (шапка, подвал и т.д.) */}
      <Route path={MAIN_PAGE_PATH} element={<MainLayout />}>
        <Route
          index
          element={
            <Suspense fallback={<LoadingSpinner />}>
              <HomePage />
            </Suspense>
          }
        />

        <Route
          path={ALL_RECIPES_PAGE_PATH}
          element={
            <Suspense fallback={<LoadingSpinner />}>
              <AllRecipesPage />
            </Suspense>
          }
        />

        <Route
          path={RECIPE_PAGE_PATH + "/:id"}
          element={
            <Suspense fallback={<LoadingSpinner />}>
              <RecipePage />
            </Suspense>
          }
        />

        <Route
          path={AUTHOR_PAGE_PATH + "/:id"}
          element={
            <Suspense fallback={<LoadingSpinner />}>
              <AuthorPage />
            </Suspense>
          }
        />

        <Route element={<ProtectedRoute />}>
          <Route
            path={PROFILE_PAGE_PATH}
            element={
              <Suspense fallback={<LoadingSpinner />}>
                <ProfilePage />
              </Suspense>
            }
          />
          <Route
            path={CREATE_RECIPE_PAGE_PATH}
            element={
              <Suspense fallback={<LoadingSpinner />}>
                <CreateRecipePage />
              </Suspense>
            }
          />
          <Route
            path={EDIT_RECIPE_PAGE_PATH + ":id"}
            element={
              <Suspense fallback={<LoadingSpinner />}>
                <CreateRecipePage />
              </Suspense>
            }
          />
        </Route>
      </Route>

      <Route
        path="*"
        element={
          <Suspense fallback={<LoadingSpinner />}>
            <NotFoundPage />
          </Suspense>
        }
      />
    </Routes>
  );
};

export default AppRoutes;
