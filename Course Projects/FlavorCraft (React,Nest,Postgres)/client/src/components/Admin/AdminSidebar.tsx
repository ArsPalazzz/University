import React from "react";
import {
  List,
  ListItem,
  ListItemText,
  Drawer,
  Box,
  Typography,
} from "@mui/material";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "providers/AuthContext";
import { MAIN_PAGE_PATH } from "consts/web-paths";

const AdminSidebar = () => {
  const { logout } = useAuth();
  const navigate = useNavigate();

  return (
    <Box sx={{ borderRight: "1px solid black" }}>
      <Box
        sx={{
          width: 250,
          padding: 2,
          display: "flex",
          boxSizing: "border-box",
          flexDirection: "column",
          justifyContent: "space-between",
          height: "100vh",
        }}
      >
        <Box>
          <Typography variant="h6">Admin Panel</Typography>
          <List>
            <ListItem
              component={Link}
              to="/admin/users"
              sx={{ textDecoration: "none", color: "inherit" }}
            >
              <ListItemText primary="Users" />
            </ListItem>
            <ListItem
              component={Link}
              to="/admin/ingredients"
              sx={{ textDecoration: "none", color: "inherit" }}
            >
              <ListItemText primary="Ingredients" />
            </ListItem>
            <ListItem
              component={Link}
              to="/admin/recipes"
              sx={{ textDecoration: "none", color: "inherit" }}
            >
              <ListItemText primary="Recipes" />
            </ListItem>
            <ListItem
              component={Link}
              to="/admin/categories"
              sx={{ textDecoration: "none", color: "inherit" }}
            >
              <ListItemText primary="Categories" />
            </ListItem>
            <ListItem
              component={Link}
              to="/admin/follows"
              sx={{ textDecoration: "none", color: "inherit" }}
            >
              <ListItemText primary="Follows" />
            </ListItem>
          </List>
        </Box>

        <Typography
          variant="body1"
          sx={{ cursor: "pointer" }}
          onClick={() => {
            logout();
            navigate(MAIN_PAGE_PATH);
          }}
        >
          Log out
        </Typography>
      </Box>
    </Box>
  );
};

export default AdminSidebar;
