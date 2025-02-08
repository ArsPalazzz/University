import {
  Box,
  Card,
  CardContent,
  CardMedia,
  Divider,
  Typography,
} from "@mui/material";
import { DEFAULT_RECIPE_IMAGE } from "consts/image";
import { useNavigate } from "react-router-dom";
import { RecipeMain } from "types/entities/recipe";
import { RECIPE_PAGE_PATH } from "consts/web-paths";

export const SmallRecipeCard = ({
  recipe,
  lastElement = false,
}: {
  recipe: RecipeMain;
  lastElement: boolean;
}) => {
  const { title, image_path } = recipe;

  const navigate = useNavigate();

  return (
    <>
      <Card sx={{ display: "flex", width: 300, height: 120 }}>
        <CardMedia
          component="img"
          sx={{
            width: 120,
            height: 120,
            objectFit: "cover",
            cursor: "pointer",
          }}
          image={
            image_path
              ? process.env.REACT_APP_API_URL + image_path
              : DEFAULT_RECIPE_IMAGE
          }
          alt={title}
          onClick={() => navigate(RECIPE_PAGE_PATH + `/${recipe.id}`)}
        />
        <CardContent
          sx={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "flex-start",
            padding: "8px",
            overflow: "hidden",
          }}
        >
          <Typography
            variant="body1"
            sx={{
              display: "-webkit-box",
              WebkitBoxOrient: "vertical",
              WebkitLineClamp: 3, // Ограничение до 3 строк
              overflow: "hidden",
              textOverflow: "ellipsis",
            }}
          >
            {title}
          </Typography>
        </CardContent>
      </Card>

      {!lastElement && <Divider sx={{ color: "black" }} />}
    </>
  );
};
