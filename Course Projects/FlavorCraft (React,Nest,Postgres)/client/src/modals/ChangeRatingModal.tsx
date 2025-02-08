// AuthModal.tsx
import React, { useEffect, useState } from "react";
import { useAuth } from "../providers/AuthContext";
import { Modal, Box, Button, TextField, Typography } from "@mui/material";
import { useForm, Controller, FieldErrors } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import StarBorderOutlinedIcon from "@mui/icons-material/StarBorderOutlined";
import StarIcon from "@mui/icons-material/Star";

const style = {
  position: "absolute" as "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
  display: "flex",
  flexDirection: "column",
  gap: 4,
};

interface ChangeRatingModalProps {
  open: boolean;
  handleClose: (prev: boolean) => void;
  startRating?: number | undefined;
  onSave: (rating: number) => void;
}

export const ChangeRatingModal = ({
  open,
  handleClose,
  onSave,
  startRating,
}: ChangeRatingModalProps) => {
  const [rating, setRating] = useState<number>(startRating || 0);

  useEffect(() => {
    if (startRating) setRating(startRating);
  }, [startRating]);
  console.log("startRating: ", startRating);
  console.log("rating: ", rating);
  //console.log('startRating: ', startRating);

  const handleStarClick = (index: number) => {
    setRating(index + 1); // Устанавливаем рейтинг от 1 до 5
  };

  return (
    <Modal open={open} onClose={handleClose}>
      <Box sx={style}>
        <Typography variant="h6" component="h2" fontWeight={700}>
          Change your rating
        </Typography>
        <Box>
          <Typography>Your rating: </Typography>
          <Box sx={{ display: "flex" }}>
            {new Array(5).fill(0).map((_, index) => (
              <Box
                key={index}
                onClick={() => handleStarClick(index)} // Устанавливаем рейтинг при клике
                sx={{
                  cursor: "pointer",
                }}
              >
                {rating && rating > index ? (
                  <StarIcon sx={{ color: "gold" }} />
                ) : (
                  <StarBorderOutlinedIcon sx={{ color: "gold" }} />
                )}
              </Box>
            ))}
          </Box>
        </Box>
        <Box sx={{ display: "flex", justifyContent: "space-between" }}>
          <Button
            variant="outlined"
            color="error"
            onClick={() => handleClose(true)}
            sx={{
              margin: "16px",
              textTransform: "capitalize",
            }}
          >
            Cancel
          </Button>
          <Button
            variant="contained"
            onClick={() => onSave(rating)}
            sx={{
              margin: "16px",
              textTransform: "capitalize",
            }}
          >
            Save
          </Button>
        </Box>
      </Box>
    </Modal>
  );
};
