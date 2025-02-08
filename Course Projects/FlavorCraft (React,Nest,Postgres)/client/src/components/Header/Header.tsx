import React, { MouseEvent, useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  AppBar,
  Toolbar,
  Typography,
  Box,
  Menu,
  MenuItem,
  IconButton,
  Popover,
} from "@mui/material";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import NoAccountsIcon from "@mui/icons-material/NoAccounts";
import AccountCircleIcon from "@mui/icons-material/AccountCircle";
import { AuthModal } from "modals/AuthModal";
import { useAuth } from "providers/AuthContext";
import {
  ALL_RECIPES_PAGE_PATH,
  MAIN_PAGE_PATH,
  PROFILE_PAGE_PATH,
} from "consts/web-paths";
import { Avatar } from "../Avatar/Avatar";

const Header: React.FC = () => {
  const [anchorElRecipes, setAnchorElRecipes] =
    React.useState<null | HTMLElement>(null);
  const [anchorElCuisines, setAnchorElCuisines] =
    React.useState<null | HTMLElement>(null);
  const [isAuthOpen, setAuthOpen] = useState<boolean>(false);
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);

  const { user, logout } = useAuth();
  const navigate = useNavigate();

  const open = Boolean(anchorEl);

  const handleMenuOpen = (
    event: MouseEvent<HTMLElement>,
    setAnchorEl: React.Dispatch<React.SetStateAction<HTMLElement | null>>
  ) => setAnchorEl(event.currentTarget);

  const handleMenuClose = (
    setAnchorEl: React.Dispatch<React.SetStateAction<HTMLElement | null>>
  ) => setAnchorEl(null);

  const handleAuthModal = () => {
    setAuthOpen((prev) => !prev);
  };

  const handlePopoverClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handlePopoverClose = () => {
    setAnchorEl(null);
  };

  console.log(user);

  return (
    <>
      <AppBar
        position="fixed"
        elevation={0}
        sx={{
          paddingLeft: "8vw",
          paddingRight: "8vw",
          bgcolor: "primary.main",
        }}
      >
        <Toolbar
          sx={{
            display: "flex",
            justifyContent: "space-between",
          }}
          disableGutters
        >
          <Box sx={{ display: "flex", alignItems: "center", gap: 4 }}>
            <Typography
              variant="h6"
              fontWeight="bold"
              sx={{ flexGrow: 1, cursor: "pointer" }}
              onClick={() => navigate(MAIN_PAGE_PATH)}
            >
              FlavorCraft
            </Typography>
            <Box>
              <Typography
                variant="body1"
                onClick={() => navigate(ALL_RECIPES_PAGE_PATH)}
                sx={{
                  display: "inline",
                  mx: 2,
                  cursor: "pointer",
                  py: 0.5,
                }}
              >
                All Recipes
              </Typography>

              {/* <Typography
                variant="body1"
                sx={{ display: "inline", mx: 2, cursor: "pointer", py: 0.5 }}
                onMouseEnter={(e) => handleMenuOpen(e, setAnchorElRecipes)}
              >
                Categories
              </Typography>
              <Menu
                anchorEl={anchorElRecipes}
                open={Boolean(anchorElRecipes)}
                onClose={() => handleMenuClose(setAnchorElRecipes)}
                MenuListProps={{
                  onMouseLeave: () => handleMenuClose(setAnchorElRecipes),
                }}
              >
                <MenuItem onClick={() => handleMenuClose(setAnchorElRecipes)}>
                  Breakfast
                </MenuItem>
                <MenuItem onClick={() => handleMenuClose(setAnchorElRecipes)}>
                  Lunch
                </MenuItem>
                <MenuItem onClick={() => handleMenuClose(setAnchorElRecipes)}>
                  Dinner
                </MenuItem>
              </Menu>

              <Typography
                variant="body1"
                sx={{ display: "inline", mx: 2, cursor: "pointer", py: 0.5 }}
                onMouseEnter={(e) => handleMenuOpen(e, setAnchorElCuisines)}
              >
                Cuisines
              </Typography>
              <Menu
                anchorEl={anchorElCuisines}
                open={Boolean(anchorElCuisines)}
                onClose={() => handleMenuClose(setAnchorElCuisines)}
                MenuListProps={{
                  onMouseLeave: () => handleMenuClose(setAnchorElCuisines),
                }}
              >
                <MenuItem onClick={() => handleMenuClose(setAnchorElCuisines)}>
                  Asian
                </MenuItem>
                <MenuItem onClick={() => handleMenuClose(setAnchorElCuisines)}>
                  Italian
                </MenuItem>
                <MenuItem onClick={() => handleMenuClose(setAnchorElCuisines)}>
                  Mexican
                </MenuItem>
              </Menu> */}
            </Box>
          </Box>

          <Box sx={{ display: "flex", alignItems: "center" }}>
            {!user ? (
              <Box
                onClick={handleAuthModal}
                sx={{
                  display: "flex",
                  alignItems: "center",
                  cursor: "pointer",
                }}
              >
                <Typography variant="body1" sx={{ mx: 2 }}>
                  Log in
                </Typography>

                <NoAccountsIcon sx={{ width: 36, height: 36 }} />
              </Box>
            ) : (
              <>
                <IconButton color="default">
                  <FavoriteBorderIcon
                    onClick={() => navigate(PROFILE_PAGE_PATH + "?tab=fav")}
                  />
                </IconButton>
                <Typography variant="body1" sx={{ mx: 2 }}>
                  {user.username}
                </Typography>

                <IconButton onClick={handlePopoverClick}>
                  <Avatar user={user} size={36} />
                  {/* <AccountCircleIcon sx={{ width: 36, height: 36 }} /> */}
                </IconButton>
              </>
            )}
          </Box>
        </Toolbar>
      </AppBar>
      <AuthModal
        handleClose={(prev: boolean) => setAuthOpen(!prev)}
        open={isAuthOpen}
      />

      <Popover
        open={open}
        anchorEl={anchorEl}
        onClose={handlePopoverClose}
        anchorOrigin={{
          vertical: "bottom",
          horizontal: "right",
        }}
        transformOrigin={{
          vertical: "top",
          horizontal: "right",
        }}
      >
        <Box
          sx={{
            p: 2,
            minWidth: 200,
            backgroundColor: "background.default",
            borderRadius: 1,
            display: "flex",
            flexDirection: "column",
            gap: 3,
          }}
        >
          <Box>
            <Typography
              variant="body1"
              sx={{ cursor: "pointer" }}
              onClick={() => {
                navigate(PROFILE_PAGE_PATH);
                handlePopoverClose();
              }}
            >
              Profile
            </Typography>
          </Box>

          <Typography
            variant="body1"
            sx={{ cursor: "pointer" }}
            onClick={() => {
              logout();
              handlePopoverClose();
              navigate(MAIN_PAGE_PATH);
            }}
          >
            Log out
          </Typography>
        </Box>
      </Popover>
    </>
  );
};

export default Header;
