import {
  Box,
  Card,
  CardContent,
  CardMedia,
  IconButton,
  Typography,
} from "@mui/material";
import { DEFAULT_RECIPE_IMAGE } from "consts/image";
import { useNavigate } from "react-router-dom";
import { RecipeMain } from "types/entities/recipe";
import { RECIPE_PAGE_PATH } from "consts/web-paths";
import ShowStars from "../Stars/Stars";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import FavoriteIcon from "@mui/icons-material/Favorite";
import { useState } from "react";

export const FavRecipeCard = ({
  recipe,
  maxCardWidth,
  imageHeight,
  onRemoveFromFav,
}: {
  recipe: RecipeMain;
  maxCardWidth?: number;
  imageHeight?: number;
  onRemoveFromFav: (id: string) => void;
}) => {
  const { title, image_path, author_name, rating_count, avg_rating } = recipe;

  const navigate = useNavigate();

  const [isFavorited, setIsFavorited] = useState(true);

  const handleFavoriteClick = () => {
    debugger;
    onRemoveFromFav(recipe.id);
  };

  return (
    <Card sx={{ maxWidth: maxCardWidth ?? 370, position: "relative" }}>
      <Box
        sx={{
          position: "absolute",
          top: 8,
          right: 8,
          zIndex: 1,
        }}
      >
        <IconButton onClick={handleFavoriteClick}>
          {isFavorited ? (
            <FavoriteIcon sx={{ color: "pink" }} />
          ) : (
            <FavoriteBorderIcon />
          )}
        </IconButton>
      </Box>

      <CardMedia
        component="img"
        height={imageHeight?.toString() ?? "200"}
        image={
          image_path
            ? process.env.REACT_APP_API_URL + image_path
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
            rating_count={Number(rating_count) || 0}
          />
        </Box>
      </CardContent>
    </Card>
  );
};
