// AuthModal.tsx
import React, { useState } from "react";
import { useAuth } from "../providers/AuthContext";
import { Modal, Box, Button, TextField, Typography } from "@mui/material";
import { useForm, Controller, FieldErrors } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";

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
};

const loginSchema = z.object({
  email: z.string().email("Invalid email").nonempty("Email is required"),
  password: z.string().min(6, "Password must be at least 6 characters"),
});

const registerSchema = z.object({
  email: z.string().email("Invalid email").nonempty("Email is required"),
  username: z
    .string()
    .nonempty("Username is required")
    .min(3, "Username must be at least 3 characters"),
  password: z.string().min(6, "Password must be at least 6 characters"),
});

type LoginFormValues = z.infer<typeof loginSchema>;
type RegisterFormValues = z.infer<typeof registerSchema>;

interface AuthModalProps {
  open: boolean;
  handleClose: (prev: boolean) => void;
}

export const AuthModal = ({ open, handleClose }: AuthModalProps) => {
  const { login, register: registerUser } = useAuth();
  const [isLogin, setIsLogin] = useState(true);

  const schema = isLogin ? loginSchema : registerSchema;
  const {
    control,
    handleSubmit,
    formState: { errors, isValid },
    reset,
  } = useForm<LoginFormValues | RegisterFormValues>({
    resolver: zodResolver(schema),
    mode: "onChange",
  });

  const onSubmit = async (data: LoginFormValues | RegisterFormValues) => {
    if (isLogin) {
      const isSuccess = await login(data as LoginFormValues);
      if (isSuccess) {
        reset();
        handleClose(open);
      }
    } else {
      const isSuccess = await registerUser(data as RegisterFormValues);
      if (isSuccess) {
        reset();
        handleClose(open);
      }
    }
  };

  return (
    <Modal open={open} onClose={handleClose}>
      <Box sx={style}>
        <Typography variant="h6" component="h2">
          {isLogin ? "Login" : "Register"}
        </Typography>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Controller
            name="email"
            control={control}
            render={({ field }) => {
              return (
                <TextField
                  {...field}
                  label="Email"
                  type="email"
                  fullWidth
                  margin="normal"
                  error={!!errors.email?.message}
                  helperText={errors.email?.message}
                />
              );
            }}
          />

          {!isLogin && (
            <Controller
              name="username"
              control={control}
              render={({ field }) => (
                <TextField
                  {...field}
                  label="Username"
                  type="text"
                  fullWidth
                  margin="normal"
                  error={!!(errors as FieldErrors<RegisterFormValues>).username}
                  helperText={
                    (errors as FieldErrors<RegisterFormValues>).username
                      ?.message
                  }
                />
              )}
            />
          )}

          <Controller
            name="password"
            control={control}
            render={({ field }) => (
              <TextField
                {...field}
                label="Password"
                type="password"
                fullWidth
                margin="normal"
                error={!!errors.password}
                helperText={errors.password?.message}
              />
            )}
          />

          <Button
            type="submit"
            variant="contained"
            fullWidth
            sx={{ mt: 2 }}
            disabled={!isValid}
          >
            {isLogin ? "Login" : "Register"}
          </Button>
          <Button
            onClick={() => {
              setIsLogin(!isLogin);
              reset(); // Сброс формы при переключении
            }}
            fullWidth
            sx={{ mt: 2 }}
          >
            Switch to {isLogin ? "Register" : "Login"}
          </Button>
        </form>
      </Box>
    </Modal>
  );
};
