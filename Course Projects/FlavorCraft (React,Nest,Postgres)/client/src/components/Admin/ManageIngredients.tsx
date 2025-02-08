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

const ManageIngredients = () => {
  const queryClient = useQueryClient();
  const [name, setName] = useState("");
  const [editingIngredient, setEditingIngredient] = useState<Ingredient | null>(
    null
  );
  const [editName, setEditName] = useState("");

  const { data: ingredients, isLoading } = useQuery({
    queryKey: ["admin-ingredients"],
    queryFn: getAllIngredientsAdminQuery,
  });

  const createIngredientMutation = useMutation({
    mutationFn: async (payload: { name: string }) =>
      createIngredientAdminQuery(payload),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-ingredients"] });
      toast.success("Ingredient has been created successfully");
    },
  });

  const deleteIngredientMutation = useMutation({
    mutationFn: async (id: number) => deleteIngredientAdminQuery(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-ingredients"] });
      toast.success("Ingredient has been deleted successfully");
    },
  });

  const updateIngredientMutation = useMutation({
    mutationFn: async (payload: { id: number; name: string }) =>
      updateIngredientAdminQuery({ name: payload.name }, payload.id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-ingredients"] });
      toast.success("Ingredient has been updated successfully");
    },
  });

  const handleCreateIngredient = () => {
    createIngredientMutation.mutate({ name });
    setName("");
  };

  const handleEditIngredient = (ingredient: Ingredient) => {
    setEditingIngredient(ingredient);
    setEditName(ingredient.name);
  };

  const handleUpdateIngredient = () => {
    if (editingIngredient) {
      updateIngredientMutation.mutate({
        id: editingIngredient.id,
        name: editName,
      });
      setEditingIngredient(null);
      setEditName("");
    }
  };

  if (isLoading) return <Typography>Loading...</Typography>;

  return (
    <Box sx={{ padding: 3 }}>
      <Typography variant="h4">Ingredient Management</Typography>

      <Box sx={{ display: "flex", gap: 2, marginTop: 3 }}>
        <TextField
          label="Ingredient Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <Button
          variant="contained"
          color="primary"
          onClick={handleCreateIngredient}
          disabled={!name}
        >
          Add Ingredient
        </Button>
      </Box>

      <List sx={{ marginTop: 3 }}>
        {ingredients?.map((ingredient: Ingredient) => (
          <ListItem
            key={ingredient.id}
            secondaryAction={
              <>
                <IconButton
                  edge="end"
                  onClick={() => handleEditIngredient(ingredient)}
                  sx={{ marginRight: 1 }}
                >
                  <EditIcon />
                </IconButton>
                <IconButton
                  edge="end"
                  onClick={() => deleteIngredientMutation.mutate(ingredient.id)}
                >
                  <DeleteIcon />
                </IconButton>
              </>
            }
          >
            {ingredient.name}
          </ListItem>
        ))}
      </List>

      {/* Диалог для редактирования ингредиента */}
      <Dialog
        open={!!editingIngredient}
        onClose={() => setEditingIngredient(null)}
      >
        <DialogTitle>Edit Ingredient</DialogTitle>
        <DialogContent>
          <TextField
            fullWidth
            margin="dense"
            label="Name"
            value={editName}
            onChange={(e) => setEditName(e.target.value)}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setEditingIngredient(null)}>Cancel</Button>
          <Button
            onClick={handleUpdateIngredient}
            color="primary"
            variant="contained"
            disabled={!editName}
          >
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </Box>
  );
};

export default ManageIngredients;
