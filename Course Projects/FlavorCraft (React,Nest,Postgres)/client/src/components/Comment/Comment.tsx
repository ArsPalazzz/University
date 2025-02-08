import ShowStars from "../Stars/Stars";
import { Box, Typography } from "@mui/material";
import { formatDateToLongString } from "../../utils/time";
import { RecipeFull } from "types/entities/recipe";
import BlockOutlinedIcon from "@mui/icons-material/BlockOutlined";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { deleteRecipeByIdQuery } from "queries/recipe";
import { blockCommentByIdQuery } from "queries/comment";
import { useAuth } from "providers/AuthContext";
import { useNavigate } from "react-router-dom";
import { AUTHOR_PAGE_PATH, PROFILE_PAGE_PATH } from "consts/web-paths";
import { DEFAULT_PROFILE_PICTURE_IMAGE } from "consts/image";

export const Comment = ({
  comment,
  block = false,
}: {
  comment: {
    id: number;
    content: string;
    created_at: Date;
    authorName: string;
    authorId: string;
    rating: string;
    avatarUrl: string;
  };
  block?: boolean;
}) => {
  const queryClient = useQueryClient();
  const { user } = useAuth();
  const navigate = useNavigate();

  const blockCommentMutation = useMutation({
    mutationFn: async (commentId: number) => {
      if (commentId) {
        return await blockCommentByIdQuery(commentId);
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

  const isOwn = user?.id === comment.authorId;

  console.log(comment);

  return (
    <Box sx={{ display: "flex", gap: 2, width: "100%", maxWidth: 700 }}>
      <Box
        component="img"
        src={
          comment.avatarUrl
            ? process.env.REACT_APP_API_URL + comment.avatarUrl
            : DEFAULT_PROFILE_PICTURE_IMAGE
        }
        sx={{
          width: 50,
          height: 50,
          borderRadius: "50%",
        }}
        onClick={() =>
          navigate(
            isOwn
              ? PROFILE_PAGE_PATH
              : AUTHOR_PAGE_PATH + `/${comment?.authorId}`
          )
        }
      />

      <Box sx={{ width: "100%" }}>
        <Box sx={{ width: "100%" }}>
          <Box sx={{ width: "100%" }}>
            <Box
              sx={{
                display: "flex",
                justifyContent: "space-between",
                position: "relative",
                width: "100%",
              }}
            >
              <Typography>{comment.authorName}</Typography>
              {block && (
                <BlockOutlinedIcon
                  sx={{
                    position: "absolute",
                    right: 0,
                    top: 0,
                    cursor: "pointer",
                    color: "red",
                  }}
                  onClick={() => blockCommentMutation.mutateAsync(comment.id)}
                />
              )}
            </Box>

            <Typography>
              {formatDateToLongString(comment.created_at)}
            </Typography>
          </Box>
          <ShowStars rating={Number(comment.rating)} />
        </Box>
        <Typography>{comment.content}</Typography>
      </Box>
    </Box>
  );
};
