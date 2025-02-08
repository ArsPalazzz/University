import React from "react";
import { Box, Typography, Button } from "@mui/material";
import { Link } from "react-router-dom";

const AdminDashboard = () => {
  return (
    <Box sx={{ padding: 3 }}>
      <Typography variant="h4" gutterBottom>
        Админ панель
      </Typography>
      <Typography variant="h6">Выберите одну из следующих опций:</Typography>

      <Box
        sx={{ display: "flex", flexDirection: "column", gap: 2, marginTop: 2 }}
      >
        <Button
          component={Link}
          to="/admin/users"
          variant="contained"
          color="primary"
        >
          Управление пользователями
        </Button>
        <Button
          component={Link}
          to="/admin/recipes"
          variant="contained"
          color="primary"
        >
          Управление рецептами
        </Button>
        <Button
          component={Link}
          to="/admin/categories"
          variant="contained"
          color="primary"
        >
          Управление категориями
        </Button>
        <Button
          component={Link}
          to="/admin/ingredients"
          variant="contained"
          color="primary"
        >
          Управление ингредиентами
        </Button>
      </Box>
    </Box>
  );
};

export default AdminDashboard;
