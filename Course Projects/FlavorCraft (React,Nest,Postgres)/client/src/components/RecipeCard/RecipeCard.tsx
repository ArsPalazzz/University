import {
  Box,
  Card,
  CardContent,
  CardMedia,
  IconButton,
  Typography,
} from "@mui/material";
import StarBorderOutlinedIcon from "@mui/icons-material/StarBorderOutlined";
import StarIcon from "@mui/icons-material/Star";
import StarHalfIcon from "@mui/icons-material/StarHalf";
import { DEFAULT_RECIPE_IMAGE } from "consts/image";
import { useNavigate } from "react-router-dom";
import { RecipeMain } from "types/entities/recipe";
import {
  CREATE_RECIPE_PAGE_PATH,
  EDIT_RECIPE_PAGE_PATH,
  RECIPE_PAGE_PATH,
} from "consts/web-paths";
import ShowStars from "../../components/Stars/Stars";
import DeleteIcon from "@mui/icons-material/Delete";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toggleToFavouritesQuery } from "queries/favourite";
import { deleteRecipeByIdQuery } from "queries/recipe";
import ModeEditOutlinedIcon from "@mui/icons-material/ModeEditOutlined";

export const RecipeCard = ({
  recipe,
  maxCardWidth,
  imageHeight,
  canDelete = false,
  canEdit = false,
}: {
  recipe: RecipeMain;
  maxCardWidth?: number;
  imageHeight?: number;
  canDelete?: boolean;
  canEdit?: boolean;
}) => {
  const { title, image_path, author_name, rating_count, avg_rating } = recipe;

  const navigate = useNavigate();
  const queryClient = useQueryClient();

  const deleteRecipeMutation = useMutation({
    mutationFn: async (recipeId: string) => {
      if (recipeId) {
        return await deleteRecipeByIdQuery(recipeId);
      }

      return false;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["my-recipes"],
        type: "all",
      });
    },
    onError: () => {
      console.error("Error");
    },
  });

  return (
    <Card
      sx={{
        maxWidth: maxCardWidth ?? 370,
        minWidth: maxCardWidth ?? 370,
        position: "relative",
        cursor: "pointer",
      }}
    >
      <Box
        sx={{
          position: "absolute",
          top: 8,
          right: 8,
          zIndex: 1,
        }}
      >
        <IconButton onClick={() => deleteRecipeMutation.mutateAsync(recipe.id)}>
          {canDelete && <DeleteIcon sx={{ color: "red", cursor: "pointer" }} />}
        </IconButton>
      </Box>
      <Box
        sx={{
          position: "absolute",
          top: 8,
          left: 8,
          zIndex: 1,
        }}
      >
        <IconButton onClick={() => navigate(EDIT_RECIPE_PAGE_PATH + recipe.id)}>
          {canEdit && (
            <ModeEditOutlinedIcon sx={{ color: "orange", cursor: "pointer" }} />
          )}
        </IconButton>
      </Box>
      <CardMedia
        component="img"
        height={imageHeight?.toString() ?? "200"}
        image={
          image_path
            ? process.env.REACT_APP_API_URL +
              image_path +
              `?timestamp=${new Date().getTime()}`
            : DEFAULT_RECIPE_IMAGE
        }
        alt={title}
        sx={{ cursor: "pointer" }}
        onClick={() => navigate(RECIPE_PAGE_PATH + `/${recipe.id}`)}
      />
      <CardContent>
        <Box>
          <Typography>{title}</Typography>
          <Typography>{author_name}</Typography>

          <ShowStars
            rating={Number(avg_rating)}
            rating_count={Number(rating_count)}
          />
        </Box>
      </CardContent>
    </Card>
  );
};
