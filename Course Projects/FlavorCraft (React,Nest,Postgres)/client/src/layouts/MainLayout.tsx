import React from "react";
import { Outlet } from "react-router-dom";
import Header from "../components/Header/Header";
import { Box } from "@mui/material";

const MainLayout: React.FC = () => {
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        pt: 15,
        pb: 15,
        paddingLeft: "8vw",
        bgcolor: "background.default",
        paddingRight: "8vw",
      }}
    >
      <Header />
      <main
        style={{
          minHeight: "84vh",
          width: "100%",
          height: "100%",
        }}
      >
        <Outlet />
      </main>
      {/* <Footer />  */}
    </Box>
  );
};

export default MainLayout;
