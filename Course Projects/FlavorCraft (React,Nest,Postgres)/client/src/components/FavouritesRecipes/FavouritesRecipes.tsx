import React, { useEffect } from "react";
import { Typography, Box, CircularProgress } from "@mui/material";
import axios from "axios";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { RecipeCard } from "../../components/RecipeCard/RecipeCard";
import axiosInstance from "config/axios";
import { fetchFavRecipesQuery, fetchMyRecipesQuery } from "queries/recipe";
import { FavRecipeCard } from "../FavRecipeCard/FavRecipeCard";
import { toggleToFavouritesQuery } from "queries/favourite";

export const FavouritesRecipes: React.FC = () => {
  const {
    data: recipes,
    isLoading,
    error,
  } = useQuery({
    queryKey: ["fav-recipes"],
    queryFn: fetchFavRecipesQuery,
  });

  const queryClient = useQueryClient();

  const onRemoveFromFav = (id: string) => {
    toggleFavouriteMutation.mutateAsync(id);
  };

  const toggleFavouriteMutation = useMutation({
    mutationFn: async (recipeId: string) => {
      if (recipeId) {
        debugger;
        return await toggleToFavouritesQuery({ recipeId });
      }

      return false;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["fav-recipes"],
        type: "all",
      });
    },
    onError: () => {
      console.error("Error");
    },
  });

  return (
    <Box>
      {isLoading ? (
        <CircularProgress />
      ) : error ? (
        <Typography color="error">Failed to load recipes.</Typography>
      ) : recipes?.length !== undefined && recipes?.length > 0 && !error ? (
        <Box
          sx={{
            display: "flex",
            grid: 4,
          }}
        >
          {recipes &&
            recipes.map((recipe) => (
              <FavRecipeCard
                recipe={recipe}
                key={recipe.id}
                onRemoveFromFav={(id) => onRemoveFromFav(id)}
              />
            ))}
        </Box>
      ) : (
        <Typography>There's no recipes yet</Typography>
      )}
    </Box>
  );
};
