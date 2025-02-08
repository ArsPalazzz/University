import RecipeListWithTitle from "../../components/RecipeListWithTitle/RecipeListWithTitle";
import { SmallRecipeCard } from "../../components/SmallRecipeCard/SmallRecipeCard";
import ShowStars from "../../components/Stars/Stars";
import StarBorderOutlinedIcon from "@mui/icons-material/StarBorderOutlined";
import StarIcon from "@mui/icons-material/Star";
import StarHalfIcon from "@mui/icons-material/StarHalf";
import { Box, Button, TextField, Typography } from "@mui/material";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { fromMinutesToHours } from "../../utils/time";
import axiosInstance from "config/axios";
import BlockOutlinedIcon from "@mui/icons-material/BlockOutlined";
import { DEFAULT_RECIPE_IMAGE } from "consts/image";
import { AuthModal } from "modals/AuthModal";
import { useAuth } from "providers/AuthContext";
import {
  isRecipeInFavouritesQuery,
  toggleToFavouritesQuery,
} from "queries/favourite";
import {
  blockRecipeByIdQuery,
  fetchFullRecipeByIdQuery,
  fetchRecipesByAuthorIdQuery,
  fetchRecipesWithTheSameCategoryQuery,
} from "queries/recipe";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { RecipeFull, RecipeStatus } from "types/entities/recipe";
import { Comment } from "./../../components/Comment/Comment";
import { Avatar } from "../../components/Avatar/Avatar";
import { blockCommentByIdQuery, createReviewQuery } from "queries/comment";
import { AuthRole } from "consts/entities/user.const";
import { AUTHOR_PAGE_PATH, PROFILE_PAGE_PATH } from "consts/web-paths";
import { ChangeRatingModal } from "modals/ChangeRatingModal";
import { updateRatingQuery } from "queries/rating";

const RecipePage = () => {
  const [isAuthOpen, setAuthOpen] = useState<boolean>(false);
  const [isChangeRatingOpen, setChangeRatingOpen] = useState<boolean>(false);

  const [rating, setRating] = useState<number>();
  const [commentState, setCommentState] = useState<string>("");

  const queryClient = useQueryClient();
  const { id: recipeId } = useParams();
  const { user } = useAuth();

  const handleStarClick = (index: number) => {
    setRating(index + 1); // Устанавливаем рейтинг от 1 до 5
  };

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setCommentState(event.target.value); // Обновляем значение в состоянии
  };

  const handleCreateCommentClick = () => {
    if (!user) {
      return setAuthOpen((prev) => !prev);
    }

    debugger;
    createReviewMutation.mutateAsync();
  };

  console.log("userA: ", user);

  const handleFavouriteClick = () => {
    if (!user) {
      return setAuthOpen((prev) => !prev);
    }

    toggleFavouriteMutation.mutateAsync();
  };

  const {
    data: recipe,
    isLoading,
    error,
  } = useQuery({
    queryKey: ["current-recipe", recipeId],
    queryFn: async () => {
      if (!recipeId) return undefined;
      try {
        return await fetchFullRecipeByIdQuery(recipeId);
      } catch (err: any) {
        if (err.response?.status === 404) {
          return null;
        }
        throw err;
      }
    },
    enabled: !!recipeId,
    retry: false,
  });

  const { data: recipesWithTheSameCategory } = useQuery({
    queryKey: ["category-recipes", recipeId],
    queryFn: () => {
      return recipeId
        ? fetchRecipesWithTheSameCategoryQuery(
            recipeId,
            recipe?.category_id !== undefined ? recipe?.category_id : null
          )
        : undefined;
    },

    enabled: !!recipe,
  });

  const { data: isRecipeInFavourites } = useQuery({
    queryKey: ["recipe-in-fav", recipeId],
    queryFn: () => {
      return recipeId && user ? isRecipeInFavouritesQuery(recipeId) : false;
    },
    enabled: !!recipeId,
  });

  const navigate = useNavigate();

  const { data: authorsRecipes } = useQuery({
    queryKey: ["author_recipe", recipeId],
    queryFn: () => {
      return recipeId && recipe
        ? fetchRecipesByAuthorIdQuery(recipe.user.id, recipeId)
        : undefined;
    },
    enabled: !!recipeId && !!recipe,
  });

  useEffect(() => {
    if (recipe?.comments.some((item) => item.authorId === user?.id)) {
      setRating(
        Number(
          recipe?.comments.find((item) => item.authorId === user?.id)?.rating
        )
      );
    }
  }, [recipe?.comments, user]);

  const toggleFavouriteMutation = useMutation({
    mutationFn: async () => {
      if (recipeId) {
        return await toggleToFavouritesQuery({ recipeId });
      }

      return false;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["recipe-in-fav", recipeId],
        type: "all",
      });
    },
    onError: () => {
      console.error("Error");
    },
  });

  const createReviewMutation = useMutation({
    mutationFn: async () => {
      if (recipeId) {
        return await createReviewQuery({
          recipe_id: recipeId,
          content: commentState,
          rating,
        });
      }

      return false;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["current-recipe", recipeId],
        type: "all",
      });
      setCommentState("");
    },
    onError: () => {
      console.error("Error");
    },
  });

  const updateRatingMutation = useMutation({
    mutationFn: async (rating: number) => {
      debugger;
      if (rating && recipe?.ratingId) {
        await updateRatingQuery(
          { rating: rating.toString() },
          recipe?.ratingId
        );

        return setChangeRatingOpen(false);
      }
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["current-recipe", recipeId],
        type: "all",
      });
    },
    onError: () => {
      console.error("Error");
    },
  });

  const blockRecipeMutation = useMutation({
    mutationFn: async (recipeId: string) => {
      if (recipeId) {
        return await blockRecipeByIdQuery(recipeId);
      }

      return false;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["current-recipe"],
        type: "all",
      });
    },
    onError: () => {
      console.error("Error");
    },
  });

  if (!recipe && !isLoading) {
    return (
      <Box
        sx={{
          width: "100%",
          height: "100%",
          display: "flex",
          alignItems: "center",
        }}
      >
        <Typography variant="h5">Recipe wasn't found :(</Typography>
      </Box>
    );
  }

  if (recipe && recipe.status === RecipeStatus.BLOCKED) {
    return (
      <Box
        sx={{
          width: "100%",
          height: "100%",
          display: "flex",
          alignItems: "center",
        }}
      >
        <Typography variant="h5">This recipe was blocked :(</Typography>
      </Box>
    );
  }

  return (
    <>
      <Box sx={{ display: "flex", gap: 3, height: "100%", width: "100%" }}>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            gap: 2,
            width: "100%",
          }}
        >
          <Box>
            <Box
              sx={{
                position: "relative",
                display: "inline-block",
                height: 450,
                width: 800,
              }}
            >
              <Box
                component="img"
                sx={{ height: "100%", width: "100%", objectFit: "cover" }}
                src={
                  recipe?.image_path
                    ? process.env.REACT_APP_API_URL +
                      recipe?.image_path +
                      `?timestamp=${new Date().getTime()}`
                    : DEFAULT_RECIPE_IMAGE
                }
                alt="Recipe"
              />
              {user?.role === AuthRole.Moderator && recipe?.id && (
                <BlockOutlinedIcon
                  sx={{
                    position: "absolute",
                    right: 10,
                    top: 10,
                    width: 30,
                    height: 30,
                    cursor: "pointer",
                    color: "red",
                  }}
                  onClick={() => blockRecipeMutation.mutateAsync(recipe.id)}
                />
              )}
            </Box>
            <Box
              sx={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                gap: 1,
              }}
            >
              <Avatar
                user={recipe?.user as { id: string; avatar_url: string }}
                onClick={() => {
                  if (recipe?.user.id === user?.id) {
                    navigate(PROFILE_PAGE_PATH);
                  } else navigate(AUTHOR_PAGE_PATH + `/${recipe?.user.id}`);
                }}
              />
              <Typography>{recipe?.user.name}</Typography>
            </Box>
          </Box>

          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
            }}
          >
            <Typography>{recipe?.title}</Typography>

            {recipe?.rating_count !== undefined && (
              <ShowStars
                rating={Number(recipe?.avg_rating)}
                rating_count={recipe?.rating_count}
              />
            )}
          </Box>

          <Box
            sx={{
              display: "flex",
            }}
          >
            <Box
              sx={{
                border: "1px solid black",
                borderLeft: "none",
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                p: 2,
              }}
            >
              <Typography>Level: {recipe?.difficulty_level}</Typography>
            </Box>

            {!!recipe?.prep_time && (
              <Box
                sx={{
                  border: "1px solid black",
                  borderLeft: "none",
                  display: "flex",
                  alignItems: "center",
                  justifyContent: "center",
                  p: 2,
                }}
              >
                <Typography>
                  Time: {fromMinutesToHours(recipe?.prep_time)}
                </Typography>
              </Box>
            )}

            <Box
              sx={{
                border: "1px solid black",
                borderRight: "none",
                borderLeft: "none",
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                p: 2,
              }}
            >
              <Typography>
                Yield: {recipe?.portions_min}
                {recipe?.portions_min === recipe?.portions_max
                  ? ""
                  : ` to ${recipe?.portions_max}`}{" "}
                servings
              </Typography>
            </Box>
          </Box>

          <Button
            variant="contained" // Стиль кнопки: "contained", "outlined" или "text"
            onClick={handleFavouriteClick} // Обработчик клика
            disabled={toggleFavouriteMutation.isPending}
            sx={{
              margin: "16px",
              textTransform: "capitalize",
              bgcolor: !isRecipeInFavourites ? "active.main" : "error.main",
            }} // Дополнительное оформление через sx
          >
            {isRecipeInFavourites ? "Remove from" : "Add to"} Favourites
          </Button>

          <Box
            sx={{
              display: "flex",
              justifyContent: "space-between",
              width: "100%",
            }}
          >
            <Box
              sx={{
                display: "flex",
                flexDirection: "column",
                gap: 1,
                minWidth: 300,
              }}
            >
              <Typography variant="h4" fontWeight={700}>
                Ingredients:
              </Typography>
              <Box sx={{ display: "flex", flexDirection: "column", gap: 1 }}>
                {recipe?.ingredients.map((item) => (
                  <Typography>
                    {item.name} ({item.quantity})
                  </Typography>
                ))}
              </Box>
            </Box>
            <Box
              sx={{
                display: "flex",
                flexDirection: "column",
                gap: 1,
                minWidth: 300,
              }}
            >
              <Typography variant="h4" fontWeight={700}>
                Directions:
              </Typography>
              <Box sx={{ display: "flex", flexDirection: "column", gap: 1 }}>
                {recipe?.instructions.map((item, index) => (
                  <Box sx={{ display: "flex", gap: 1.5 }}>
                    <Typography variant="h5" fontWeight={700}>
                      {index + 1}
                    </Typography>
                    <Typography>{item}</Typography>
                  </Box>
                ))}
              </Box>
            </Box>
          </Box>

          <Box
            sx={{
              width: "100%",
              pt: 10,
              display: "flex",
              flexDirection: "column",
              gap: 1,
            }}
          >
            <Box>
              <Typography>Protein: {recipe?.protein}g</Typography>
              <Typography>Fats: {recipe?.fats}g</Typography>
              <Typography>Carbs: {recipe?.carbs}g</Typography>
            </Box>

            <Typography variant="h6" fontWeight={700}>
              Calories: {recipe?.calories}cal
            </Typography>
          </Box>

          <Box sx={{ width: "100%", pt: 10 }}>
            {recipe?.cuisine.id && (
              <Typography>Cuisine: {recipe.cuisine.name}</Typography>
            )}
            <Typography>Category: {recipe?.category_name}</Typography>
            <Typography>
              Tags:{" "}
              {recipe?.tags.map(
                (item, index) =>
                  item.name + (index === recipe?.tags.length - 1 ? "" : ", ")
              )}
            </Typography>
          </Box>

          <Box sx={{ width: "100%" }}>
            <RecipeListWithTitle
              titleName={`More ${recipe?.user.name}'s recipes`}
              isLoading={isLoading}
              error={error}
              data={authorsRecipes}
              maxCardWidth={270}
              imageHeight={170}
              cardsGap={6}
            />
          </Box>

          <Box
            sx={{
              width: "100%",
              display: "flex",
              flexDirection: "column",
              gap: 4,
            }}
          >
            <Box>
              <Typography>{recipe?.comments.length} reviews:</Typography>
              <ShowStars rating={Number(recipe?.avg_rating || 0)} />
            </Box>

            <Box sx={{ display: "flex", gap: 3 }}>
              <Avatar
                size={70}
                user={user || undefined}
                onClick={() => navigate(PROFILE_PAGE_PATH)}
              />

              <Box
                width={600}
                sx={{ display: "flex", flexDirection: "column", gap: 1 }}
              >
                <TextField
                  multiline
                  rows={3}
                  variant="outlined" // Стиль инпута: "outlined", "filled" или "standard"
                  fullWidth
                  onChange={handleChange}
                  value={commentState}
                />

                <Box sx={{ display: "flex", justifyContent: "space-between" }}>
                  <Box
                    sx={{ display: "flex", justifyContent: "space-between" }}
                  >
                    <Box>
                      <Typography>Your rating: </Typography>
                      <Box sx={{ display: "flex" }}>
                        {new Array(5).fill(0).map((_, index) => (
                          <Box
                            key={index}
                            onClick={() =>
                              !recipe?.has_rated && handleStarClick(index)
                            } // Устанавливаем рейтинг при клике
                            sx={{
                              cursor: recipe?.has_rated
                                ? "not-allowed"
                                : "pointer",
                            }} // Добавляем стиль курсора для интерактивности
                          >
                            {rating && rating > index ? (
                              <StarIcon sx={{ color: "gold" }} />
                            ) : (
                              <StarBorderOutlinedIcon sx={{ color: "gold" }} />
                            )}
                          </Box>
                        ))}
                      </Box>
                    </Box>
                    {recipe?.has_rated && (
                      <Button
                        variant="outlined"
                        onClick={() => setChangeRatingOpen(true)}
                        sx={{
                          margin: "16px",
                          textTransform: "capitalize",
                        }}
                      >
                        Change a rating
                      </Button>
                    )}
                  </Box>

                  <Button
                    variant="contained" // Стиль кнопки: "contained", "outlined" или "text"
                    onClick={handleCreateCommentClick} // Обработчик клика
                    disabled={
                      toggleFavouriteMutation.isPending ||
                      !commentState ||
                      (!recipe?.has_rated && (!commentState || !rating))
                    }
                    sx={{
                      margin: "16px",
                      textTransform: "capitalize",
                    }} // Дополнительное оформление через sx
                  >
                    Post a review
                  </Button>
                </Box>
              </Box>
            </Box>

            <Box sx={{ display: "flex", flexDirection: "column", gap: 7 }}>
              {recipe?.comments.map((comment) => (
                <Comment
                  comment={comment}
                  block={user?.role === AuthRole.Moderator}
                />
              ))}
            </Box>
          </Box>
        </Box>
        <Box
          sx={{
            position: "sticky",
            display: "flex",
            flexDirection: "column",
            height: "100%",
            gap: 2,
            top: 90,
          }}
        >
          <Typography fontWeight={700}>
            Other recipes with this category
          </Typography>

          {recipesWithTheSameCategory &&
          recipesWithTheSameCategory?.length > 0 ? (
            recipesWithTheSameCategory.map((recipe, index) => {
              return (
                <SmallRecipeCard
                  recipe={recipe}
                  key={recipe.id}
                  lastElement={index === recipesWithTheSameCategory.length - 1}
                />
              );
            })
          ) : (
            <Typography variant="body2">
              There's no recipes with this category :(
            </Typography>
          )}
        </Box>
      </Box>
      <AuthModal
        handleClose={(prev: boolean) => setAuthOpen(!prev)}
        open={isAuthOpen}
      />
      <ChangeRatingModal
        handleClose={(prev: boolean) => setChangeRatingOpen(!prev)}
        open={isChangeRatingOpen}
        startRating={Number(recipe?.avg_rating)}
        onSave={(rating) => updateRatingMutation.mutateAsync(rating)}
      />
    </>
  );
};

export default RecipePage;
