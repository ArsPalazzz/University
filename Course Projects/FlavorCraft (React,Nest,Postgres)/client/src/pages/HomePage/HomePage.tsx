import React, { useEffect } from "react";
import { Typography, Box, CircularProgress } from "@mui/material";
import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import axiosInstance from "config/axios";
import { DEFAULT_MAIN_DISH_IMAGE } from "consts/image";
import {
  fetchMainDietRecipesQuery,
  fetchMainVegetarianRecipesQuery,
} from "queries/recipe";
import RecipeListWithTitle from "../../components/RecipeListWithTitle/RecipeListWithTitle";

const HomePage: React.FC = () => {
  const {
    data: vegetarianRecipes,
    isLoading: isVegetarianLoading,
    error: vegetarianError,
  } = useQuery({
    queryKey: ["main-vegetarian-recipes"],
    queryFn: fetchMainVegetarianRecipesQuery,
  });

  const {
    data: dietRecipes,
    isLoading: isDietLoading,
    error: dietError,
  } = useQuery({
    queryKey: ["main-diet-recipes"],
    queryFn: fetchMainDietRecipesQuery,
  });

  return (
    <Box
      sx={{
        backgroundColor: "background.default",
        position: "relative",
      }}
    >
      <Box
        sx={{
          display: "flex",
          alignItems: "center",
          justifyContent: "space-between",
          height: "80vh",
          pb: 6,
          boxSizing: "border-box",
        }}
      >
        <Typography
          variant="h4"
          sx={{
            fontWeight: "bold",
            maxWidth: "60%",
            lineHeight: "1.5",
          }}
        >
          <Box
            component="span"
            sx={{ color: "primary.main", WebkitTextStroke: "0.25px black" }}
          >
            Discover
          </Box>{" "}
          new flavors and{" "}
          <Box
            component="span"
            sx={{ color: "primary.main", WebkitTextStroke: "0.25px black" }}
          >
            cook
          </Box>{" "}
          delicious meals with us!
        </Typography>

        <Box
          component="img"
          src={DEFAULT_MAIN_DISH_IMAGE}
          alt="Food Image"
          sx={{
            maxHeight: "400px",
            maxWidth: "100%",
            borderRadius: "12px",
          }}
        />
      </Box>

      <RecipeListWithTitle
        data={vegetarianRecipes}
        isLoading={isVegetarianLoading}
        error={vegetarianError}
        titleName="Vegeratian"
      />

      <RecipeListWithTitle
        data={dietRecipes}
        isLoading={isDietLoading}
        error={dietError}
        titleName="Diet"
      />
    </Box>
  );
};

export default HomePage;
