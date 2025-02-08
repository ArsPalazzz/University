import React, { useState } from "react";
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";
import {
  Box,
  Button,
  TextField,
  Typography,
  List,
  ListItem,
  IconButton,
  DialogActions,
  DialogContent,
  Dialog,
  DialogTitle,
} from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import {
  createIngredientAdminQuery,
  deleteIngredientAdminQuery,
  getAllIngredientsAdminQuery,
  updateIngredientAdminQuery,
} from "queries/admin/ingredient";
import { Ingredient } from "types/entities/ingredient";
import { toast } from "react-toastify";
import {
  createFollowAdminQuery,
  deleteFollowAdminQuery,
  getAllFollowsAdminQuery,
  updateFollowAdminQuery,
} from "queries/admin/follow";
import { Follow } from "types/entities/follow";

const ManageFollows = () => {
  const queryClient = useQueryClient();
  //const [name, setName] = useState("");
  const [followerId, setFollowerId] = useState("");
  const [followedId, setFollowedId] = useState("");
  const [editingFollow, setEditingFollow] = useState<Follow | null>(null);

  //const [editName, setEditName] = useState("");
  const [editFollowerId, setEditFollowerId] = useState("");
  const [editFollowedId, setEditFollowedId] = useState("");

  const { data: follows, isLoading } = useQuery({
    queryKey: ["admin-follows"],
    queryFn: getAllFollowsAdminQuery,
  });

  const createFollowMutation = useMutation({
    mutationFn: async () =>
      createFollowAdminQuery({
        follower_id: followerId,
        followed_id: followedId,
      }),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-follows"] });
      setFollowedId("");
      setFollowerId("");
      toast.success("Follow has been created successfully");
    },
    onError: (error: any) => {
      console.error(
        "Error:",
        error.response.data?.message?.message || error.response.data?.message
      );
      toast.error(
        `Error: ${
          error.response.data?.message?.message || error.response.data?.message
        }`
      );
    },
  });

  const deleteFollowMutation = useMutation({
    mutationFn: async (id: number) => deleteFollowAdminQuery(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-follows"] });
      toast.success("Follow has been deleted successfully");
    },
  });

  const updateFollowMutation = useMutation({
    mutationFn: async () =>
      editingFollow
        ? updateFollowAdminQuery(
            {
              follower_id: editFollowerId,
              followed_id: editFollowedId,
            },
            editingFollow.id
          )
        : undefined,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-follows"] });
      setEditingFollow(null);
      setEditFollowedId("");
      setEditFollowerId("");
      toast.success("Follow has been updated successfully");
    },
  });

  const handleCreateFollow = () => {
    createFollowMutation.mutate();
  };

  const handleEditFollow = (follow: Follow) => {
    setEditingFollow(follow);
    setEditFollowedId(follow.followed_id);
    setEditFollowerId(follow.follower_id);
  };

  const handleUpdateFollow = () => {
    if (editingFollow) {
      updateFollowMutation.mutate();
    }
  };

  if (isLoading) return <Typography>Loading...</Typography>;

  return (
    <Box sx={{ padding: 3 }}>
      <Typography variant="h4">Follow Management</Typography>

      <Box sx={{ display: "flex", gap: 2, marginTop: 3 }}>
        <TextField
          label="Follower Id"
          value={followerId}
          onChange={(e) => setFollowerId(e.target.value)}
        />
        <TextField
          label="Followed Id"
          value={followedId}
          onChange={(e) => setFollowedId(e.target.value)}
        />
        <Button
          variant="contained"
          color="primary"
          onClick={handleCreateFollow}
          disabled={!followerId || !followedId}
        >
          Add Follow
        </Button>
      </Box>

      <List
        sx={{
          marginTop: 3,
          display: "flex",
          flexDirection: "column",
          alignItems: "flex-start",
          gap: 4,
        }}
      >
        {follows?.map((follow: Follow) => (
          <ListItem
            key={follow.id}
            sx={{
              display: "flex",
              flexDirection: "column",
              alignItems: "flex-start",
            }}
            secondaryAction={
              <>
                <IconButton
                  edge="end"
                  onClick={() => handleEditFollow(follow)}
                  sx={{ marginRight: 1 }}
                >
                  <EditIcon />
                </IconButton>
                <IconButton
                  edge="end"
                  onClick={() => deleteFollowMutation.mutate(follow.id)}
                >
                  <DeleteIcon />
                </IconButton>
              </>
            }
          >
            <Typography>Id: {follow.id}</Typography>
            <Typography>FollowerId: {follow.follower_id}</Typography>
            <Typography>FollowedId: {follow.followed_id}</Typography>
          </ListItem>
        ))}
      </List>

      {/* Диалог для редактирования ингредиента */}
      <Dialog open={!!editingFollow} onClose={() => setEditingFollow(null)}>
        <DialogTitle>Edit Follow</DialogTitle>
        <DialogContent>
          <TextField
            fullWidth
            margin="dense"
            label="Follower id"
            value={editFollowerId}
            onChange={(e) => setEditFollowerId(e.target.value)}
          />
          <TextField
            fullWidth
            margin="dense"
            label="Followed id"
            value={editFollowedId}
            onChange={(e) => setEditFollowedId(e.target.value)}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setEditingFollow(null)}>Cancel</Button>
          <Button
            onClick={handleUpdateFollow}
            color="primary"
            variant="contained"
            disabled={!editFollowerId || !editFollowedId}
          >
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </Box>
  );
};

export default ManageFollows;
