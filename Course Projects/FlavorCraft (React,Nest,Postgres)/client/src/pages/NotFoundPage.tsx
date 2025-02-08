import React from "react";
import { Box, Typography } from "@mui/material";

const NotFoundPage: React.FC = () => {
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        height: "100vh",
        bgcolor: "black", // Фон страницы черный
        color: "white", // Цвет текста белый
        textAlign: "center",
      }}
    >
      <Typography
        variant="h1"
        gutterBottom
        sx={{
          fontWeight: "bold",
          fontSize: { xs: "6rem", md: "8rem" }, // Размер шрифта
          letterSpacing: "0.2rem",
          color: "#eee",
        }}
      >
        404
      </Typography>
      <Typography
        variant="h5"
        sx={{
          fontWeight: "light",
          color: "gray",
          fontSize: { xs: "1.2rem", md: "1.5rem" },
        }}
      >
        This page could not be found.
      </Typography>
    </Box>
  );
};

export default NotFoundPage;
