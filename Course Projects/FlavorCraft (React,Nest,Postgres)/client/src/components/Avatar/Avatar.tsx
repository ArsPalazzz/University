import { Box } from "@mui/material";
import { DEFAULT_PROFILE_PICTURE_IMAGE } from "consts/image";

export const Avatar = ({
  user,
  size = 100,
  preload,
  onClick,
}: {
  user?: { id: string; avatar_url: string };
  size?: number;
  preload?: string;
  onClick?: () => void;
}) => {
  return (
    <Box
      component="img"
      onClick={onClick}
      sx={{
        width: size,
        height: size,
        borderRadius: "50%",
        objectFit: "cover",
        cursor: onClick ? "pointer" : "default",
      }}
      src={
        preload
          ? preload
          : user?.avatar_url
          ? process.env.REACT_APP_API_URL +
            `/uploads/user_${user?.id}.jpg?timestamp=${new Date().getTime()}`
          : DEFAULT_PROFILE_PICTURE_IMAGE
      }
    />
  );
};
