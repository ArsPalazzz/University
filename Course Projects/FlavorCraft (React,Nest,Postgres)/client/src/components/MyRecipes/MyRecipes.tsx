import React, { useEffect } from "react";
import { Typography, Box, CircularProgress, Button } from "@mui/material";
import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import { RecipeCard } from "../../components/RecipeCard/RecipeCard";
import axiosInstance from "config/axios";
import { fetchMyRecipesQuery } from "queries/recipe";
import { useNavigate } from "react-router-dom";
import { CREATE_RECIPE_PAGE_PATH } from "consts/web-paths";

export const MyRecipesList: React.FC = () => {
  const navigate = useNavigate();

  const {
    data: recipes,
    isLoading,
    error,
  } = useQuery({
    queryKey: ["my-recipes"],
    queryFn: fetchMyRecipesQuery,
  });

  console.log("AAA: ", recipes);

  return (
    <>
      <Button
        variant="contained"
        color="primary"
        sx={{ mb: 5 }}
        onClick={() => navigate(CREATE_RECIPE_PAGE_PATH)}
      >
        Create new recipe
      </Button>
      <Box>
        {isLoading ? (
          <CircularProgress />
        ) : error ? (
          <Typography color="error">Failed to load recipes.</Typography>
        ) : recipes?.length !== undefined && recipes?.length > 0 && !error ? (
          <Box
            sx={{
              display: "flex",
              gap: 4,
            }}
          >
            {recipes &&
              recipes.map((recipe) => (
                <RecipeCard recipe={recipe} key={recipe.id} canDelete canEdit />
              ))}
          </Box>
        ) : (
          <Typography>There's no recipes yet</Typography>
        )}
      </Box>
    </>
  );
};
