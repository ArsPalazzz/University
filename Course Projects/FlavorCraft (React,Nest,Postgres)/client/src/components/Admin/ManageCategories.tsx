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
  createCategoryAdminQuery,
  deleteCategoryAdminQuery,
  getAllCategoriesAdminQuery,
  updateCategoryAdminQuery,
} from "queries/admin/category";
import { Category } from "types/entities/category";

const ManageCategories = () => {
  const queryClient = useQueryClient();
  const [name, setName] = useState("");
  const [editingCategory, setEditingCategory] = useState<Category | null>(null);
  const [editName, setEditName] = useState("");

  const { data: categories, isLoading } = useQuery({
    queryKey: ["admin-categories"],
    queryFn: getAllCategoriesAdminQuery,
  });

  const createCategoryMutation = useMutation({
    mutationFn: async (payload: { name: string }) =>
      createCategoryAdminQuery(payload),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-categories"] });
      toast.success("Category has been created successfully");
    },
  });

  const deleteCategoryMutation = useMutation({
    mutationFn: async (id: number) => deleteCategoryAdminQuery(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-categories"] });
      toast.success("Category has been deleted successfully");
    },
  });

  const updateCategoryMutation = useMutation({
    mutationFn: async (payload: { id: number; name: string }) =>
      updateCategoryAdminQuery({ name: payload.name }, payload.id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-categories"] });
      toast.success("Category has been updated successfully");
    },
  });

  const handleCreateCategory = () => {
    createCategoryMutation.mutate({ name });
    setName("");
  };

  const handleEditCategory = (category: Category) => {
    setEditingCategory(category);
    setEditName(category.name);
  };

  const handleUpdateCategory = () => {
    if (editingCategory) {
      updateCategoryMutation.mutate({
        id: editingCategory.id,
        name: editName,
      });
      setEditingCategory(null);
      setEditName("");
    }
  };

  if (isLoading) return <Typography>Loading...</Typography>;

  return (
    <Box sx={{ padding: 3 }}>
      <Typography variant="h4">Category Management</Typography>

      <Box sx={{ display: "flex", gap: 2, marginTop: 3 }}>
        <TextField
          label="Category Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <Button
          variant="contained"
          color="primary"
          onClick={handleCreateCategory}
          disabled={!name}
        >
          Add Category
        </Button>
      </Box>

      <List sx={{ marginTop: 3 }}>
        {categories?.map((category: Category) => (
          <ListItem
            key={category.id}
            secondaryAction={
              <>
                <IconButton
                  edge="end"
                  onClick={() => handleEditCategory(category)}
                  sx={{ marginRight: 1 }}
                >
                  <EditIcon />
                </IconButton>
                <IconButton
                  edge="end"
                  onClick={() => deleteCategoryMutation.mutate(category.id)}
                >
                  <DeleteIcon />
                </IconButton>
              </>
            }
          >
            {category.name}
          </ListItem>
        ))}
      </List>

      {/* Диалог для редактирования ингредиента */}
      <Dialog open={!!editingCategory} onClose={() => setEditingCategory(null)}>
        <DialogTitle>Edit Category</DialogTitle>
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
          <Button onClick={() => setEditingCategory(null)}>Cancel</Button>
          <Button
            onClick={handleUpdateCategory}
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

export default ManageCategories;
