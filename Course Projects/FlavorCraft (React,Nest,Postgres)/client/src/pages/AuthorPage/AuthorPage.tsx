import React, { useLayoutEffect, useState } from "react";
import BlockOutlinedIcon from "@mui/icons-material/BlockOutlined";
import {
  Typography,
  Box,
  TextField,
  Button,
  CircularProgress,
} from "@mui/material";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { TabPanel } from "../../components/TabPanel/TabPanel";
import { MyRecipesList } from "../../components/MyRecipes/MyRecipes";
import {
  blockUserByIdQuery,
  getAuthorProfileQuery,
  updateCurrentProfileQuery,
} from "queries/user";
import { useAuth } from "providers/AuthContext";
import { Avatar } from "../../components/Avatar/Avatar";
import { useLocation } from "react-router-dom";
import { fetchRecipesByAuthorIdQuery } from "queries/recipe";
import { RecipeCard } from "../../components/RecipeCard/RecipeCard";
import { AuthRole } from "consts/entities/user.const";
import { blockCommentByIdQuery } from "queries/comment";
import { createFollowQuery, deleteFollowQuery } from "queries/follow";
import { AuthModal } from "modals/AuthModal";

const AuthorPage: React.FC = () => {
  const queryClient = useQueryClient();
  const location = useLocation();
  const { user } = useAuth();

  const [authorId, setAuthorId] = useState<string | null>();
  const [isAuthOpen, setAuthOpen] = useState<boolean>(false);

  const block = user?.role === AuthRole.Moderator;

  const {
    data: authorInfo,
    isLoading,
    error,
  } = useQuery({
    queryKey: ["author", authorId],
    queryFn: () => (authorId ? getAuthorProfileQuery(authorId) : undefined),
    enabled: !!authorId,
  });

  const {
    data: allRecipes,
    isLoading: isRecipesLoading,
    error: allRecipesError,
  } = useQuery({
    queryKey: ["author-recipes", authorId],
    queryFn: () =>
      authorId ? fetchRecipesByAuthorIdQuery(authorId, undefined) : undefined,
    enabled: !!authorId,
  });

  const blockUserMutation = useMutation({
    mutationFn: async (userId: string) => {
      if (userId) {
        return await blockUserByIdQuery(userId, "You're not cool");
      }

      return false;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["author"],
        type: "all",
      });
    },
    onError: () => {
      console.error("Error");
    },
  });

  const createOrDeleteFollowMutation = useMutation({
    mutationFn: async (authorId: string) => {
      debugger;
      if (authorId) {
        if (!authorInfo?.isFollowingAuthor) {
          return await createFollowQuery({ followed_id: authorId });
        } else {
          return await deleteFollowQuery({ followed_id: authorId });
        }
      }
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["author"],
        type: "all",
      });
    },
    onError: (error) => {
      console.error("Error: ", error);
    },
  });

  const handleCreateOrDeleteFollow = () => {
    if (!user) {
      return setAuthOpen((prev) => !prev);
    }

    createOrDeleteFollowMutation.mutateAsync(authorInfo?.id || "");
  };

  useLayoutEffect(() => {
    const pathname = location.pathname;
    const segments = pathname.split("/");
    const authorIdLocal = segments[segments.length - 1];
    setAuthorId(authorIdLocal);
  }, []);

  if (authorInfo?.is_blocked) {
    return <Box>This user was blocked</Box>;
  }

  return (
    <>
      <Box
        sx={{
          minHeight: "100vh",
          display: "flex",
          justifyContent: "center",
        }}
      >
        <Box
          sx={{
            width: "90vw",
            mt: "20vh",
            display: "flex",
            flexDirection: "column",
            gap: 4,
          }}
        >
          <Box
            sx={{
              display: "flex",
              gap: 5,
              justifyContent: "space-between",
              position: "relative",
            }}
          >
            <Box
              sx={{
                display: "flex",
                gap: 5,
                //justifyContent: "space-between",
                position: "relative",
                width: "100%",
              }}
            >
              <Avatar user={authorInfo || undefined} />
              <Box>
                <Typography>{authorInfo?.username}</Typography>
                <Box sx={{ display: "flex", gap: 3 }}>
                  <Typography>
                    Followers count: {authorInfo?.followers_count}
                  </Typography>
                  <Typography>
                    Following count: {authorInfo?.following_count}
                  </Typography>
                </Box>
              </Box>

              {block && !!authorId && (
                <BlockOutlinedIcon
                  sx={{
                    position: "absolute",
                    right: 0,
                    top: 0,
                    cursor: "pointer",
                    color: "red",
                  }}
                  onClick={() => blockUserMutation.mutateAsync(authorId)}
                />
              )}
            </Box>

            <Button
              variant="contained"
              color={authorInfo?.isFollowingAuthor ? "error" : "primary"}
              sx={{ height: 50, textTransform: "capitalize", width: 140 }}
              onClick={handleCreateOrDeleteFollow}
            >
              {authorInfo?.isFollowingAuthor ? "Unfollow" : "Follow"}
            </Button>
          </Box>

          <Box>
            {isLoading ? (
              <CircularProgress />
            ) : error ? (
              <Typography color="error">Failed to load recipes.</Typography>
            ) : allRecipes?.length !== undefined &&
              allRecipes?.length > 0 &&
              !error ? (
              <Box
                sx={{
                  display: "flex",
                  gap: 4,
                }}
              >
                {allRecipes &&
                  allRecipes.map((recipe) => (
                    <RecipeCard recipe={recipe} key={recipe.id} />
                  ))}
              </Box>
            ) : (
              <Typography>There's no recipes yet</Typography>
            )}
          </Box>
        </Box>
      </Box>
      <AuthModal
        handleClose={(prev: boolean) => setAuthOpen(!prev)}
        open={isAuthOpen}
      />
    </>
  );
};

export default AuthorPage;
