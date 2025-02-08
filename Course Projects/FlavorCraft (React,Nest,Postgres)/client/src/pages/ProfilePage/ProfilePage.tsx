import React, { useState } from "react";
import { Typography, Box, TextField, Button } from "@mui/material";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { TabPanel } from "../../components/TabPanel/TabPanel";
import { MyRecipesList } from "../../components/MyRecipes/MyRecipes";
import { updateCurrentProfileQuery } from "queries/user";
import { useAuth } from "providers/AuthContext";
import { Avatar } from "../../components/Avatar/Avatar";
import UploadPhoto from "../../components/UploadPhoto/UploadPhoto";
import { FavouritesRecipes } from "../../components/FavouritesRecipes/FavouritesRecipes";

const ProfilePage: React.FC = () => {
  const { user: profile } = useAuth();
  const queryClient = useQueryClient();

  const [usernameState, setUsernameState] = useState<string>("");
  const handleUsernameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setUsernameState(event.target.value);
  };

  const updateUsernameMutation = useMutation({
    mutationFn: async () => {
      if (!usernameState) {
        return;
      }

      return await updateCurrentProfileQuery(
        { username: usernameState },
        profile?.id || ""
      );
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["current-profile"],
        type: "all",
      });
    },
    onError: () => {
      console.error("Error");
    },
  });

  return (
    <Box
      sx={{
        minHeight: "100vh",
        display: "flex",
        justifyContent: "center",
      }}
    >
      <Box sx={{ width: "90vw", mt: "20vh" }}>
        <Box sx={{ display: "flex", gap: 5 }}>
          <Avatar user={profile || undefined} />
          <Box>
            <Typography>{profile?.username}</Typography>
            <Box sx={{ display: "flex", gap: 3 }}>
              <Typography>
                Followers count: {profile?.followers_count}
              </Typography>
              <Typography>
                Following count: {profile?.following_count}
              </Typography>
            </Box>
          </Box>
        </Box>

        <TabPanel labels={["My Recipes", "Favorites", "Settings"]}>
          <MyRecipesList />
          <FavouritesRecipes />
          <Box>
            <Box sx={{ display: "flex", gap: 1 }}>
              <Typography>Change username: </Typography>
              <TextField
                variant="outlined"
                onChange={handleUsernameChange}
                value={usernameState}
              />
              <Button
                variant="contained"
                color="primary"
                onClick={() => updateUsernameMutation.mutateAsync()}
              >
                Update username
              </Button>
            </Box>
            <UploadPhoto myId={profile?.id ?? ""} myType="user" />
          </Box>
        </TabPanel>
      </Box>
    </Box>
  );
};

export default ProfilePage;
