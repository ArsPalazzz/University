import React, { useState } from "react";
import { Button, Box, Typography } from "@mui/material";
import axios from "axios";
import axiosInstance from "config/axios";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { uploadImageQuery } from "queries/file";
import { useNavigate } from "react-router-dom";

const UploadPhoto = ({ myId, myType }: { myId: string; myType: string }) => {
  const [selectedFile, setSelectedFile] = useState(null);
  const [preview, setPreview] = useState("");
  const queryClient = useQueryClient();
  const navigate = useNavigate();

  // Обработчик выбора файла
  const handleFileChange = (event: any) => {
    const file = event.target.files[0];
    if (file) {
      setSelectedFile(file);
      setPreview(URL.createObjectURL(file));
      console.log("correct image_path: ", URL.createObjectURL(file));
    }
  };

  const uploadImageMutation = useMutation({
    mutationFn: async () => {
      if (!selectedFile) {
        alert("Пожалуйста, выберите файл для отправки.");
        return;
      }

      if (myType && myId) {
        const formData = new FormData();
        formData.append("file", selectedFile);

        return await uploadImageQuery({ type: myType, id: myId, formData });
      }

      return false;
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({
        queryKey: ["current-profile"],
      });
      navigate(0);
    },
    onError: () => {
      console.error("Error");
    },
  });

  return (
    <Box sx={{ textAlign: "center", mt: 4 }}>
      <Typography variant="h5" gutterBottom>
        Upload your avatar
      </Typography>

      {/* Выбор файла */}
      <Button variant="contained" component="label">
        Choose file
        <input type="file" accept=".jpg" hidden onChange={handleFileChange} />
      </Button>

      {/* Кнопка отправки */}
      <Button
        variant="contained"
        color="primary"
        onClick={() => uploadImageMutation.mutateAsync()}
      >
        Upload a photo
      </Button>

      {/* Предпросмотр изображения */}
      {preview && (
        <Box sx={{ mt: 2 }}>
          <img
            src={preview}
            alt="Preview"
            style={{ maxWidth: "100%", maxHeight: "200px" }}
          />
        </Box>
      )}
    </Box>
  );
};

export default UploadPhoto;
