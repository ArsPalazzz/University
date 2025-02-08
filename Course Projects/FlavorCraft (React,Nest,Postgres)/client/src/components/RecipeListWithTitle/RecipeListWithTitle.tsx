import { ReactNode } from "react";
import { Typography, Box, CircularProgress } from "@mui/material";
import { RecipeMain } from "types/entities/recipe";
import { RecipeCard } from "../../components/RecipeCard/RecipeCard";

interface IRecipeListWithTitleProps {
  data?: RecipeMain[];
  isLoading: boolean;
  error: Error | null;
  titleName?: string;
  maxCardWidth?: number;
  imageHeight?: number;
  cardsGap?: number;
}

const RecipeListWithTitle = ({
  data,
  isLoading,
  error,
  titleName,
  maxCardWidth,
  imageHeight,
  cardsGap,
}: IRecipeListWithTitleProps) => {
  return (
    <Box
      sx={{
        padding: "2rem 0",
        boxSizing: "border-box",
      }}
    >
      {titleName && (
        <Typography variant="h4" fontWeight={700} gutterBottom>
          {titleName}:
        </Typography>
      )}

      {isLoading ? (
        <CircularProgress />
      ) : error ? (
        <Typography color="error">Failed to load data.</Typography>
      ) : data && data.length > 0 && !error ? (
        <Box
          sx={{
            display: "flex",
            gap: cardsGap ?? 11,
            flexWrap: "wrap",
          }}
        >
          {data &&
            data.map((recipe) => (
              <RecipeCard
                recipe={recipe}
                maxCardWidth={maxCardWidth}
                imageHeight={imageHeight}
                key={recipe.id}
              />
            ))}
        </Box>
      ) : (
        <Typography>There's no recipes :(</Typography>
      )}
    </Box>
  );
};

export default RecipeListWithTitle;
