import React, { useEffect, useState } from "react";
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
import { User, UserAuthPayload } from "types/entities/user";
import {
  createUserAdminQuery,
  deleteUserAdminQuery,
  getAllUsersAdminQuery,
  updateUserAdminQuery,
} from "queries/admin/user";
import EditIcon from "@mui/icons-material/Edit";
import { Avatar } from "./../Avatar/Avatar";
import { z } from "zod";
import {
  Controller,
  FieldErrors,
  useForm,
  UseFormGetValues,
} from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { toast } from "react-toastify";
import { uploadImageQuery } from "queries/file";

interface UserRegisterPayload {
  username: string;
  email: string;
  password: string;
}

interface UserEdit1Payload {
  username: string;
  email: string;
  formData?: any;
}

interface UserEdit2Payload {
  username: string;
  email: string;
  avatar_url?: string;
}

const registerSchema = z.object({
  email: z.string().email("Invalid email").nonempty("Email is required"),
  username: z
    .string()
    .nonempty("Username is required")
    .min(3, "Username must be at least 3 characters"),
  password: z.string().min(6, "Password must be at least 6 characters"),
});

const editSchema = z.object({
  email: z.string().email("Invalid email").nonempty("Email is required"),
  username: z
    .string()
    .nonempty("Username is required")
    .min(3, "Username must be at least 3 characters"),
  formData: z.any().optional(),
});

type RegisterFormValues = z.infer<typeof registerSchema>;
type EditFormValues = z.infer<typeof editSchema>;

const ManageUsers = () => {
  const queryClient = useQueryClient();

  const [editingUser, setEditingUser] = useState<User | null>(null);
  const [editUsername, setEditUsername] = useState("");
  const [editEmail, setEditEmail] = useState("");

  const {
    control,
    handleSubmit,
    formState: { errors, isValid },
    getValues,
  } = useForm<RegisterFormValues>({
    resolver: zodResolver(registerSchema),
    mode: "onChange",
  });

  const { data: users, isLoading } = useQuery({
    queryKey: ["admin-users"],
    queryFn: getAllUsersAdminQuery,
  });

  console.log("users: ", users);

  const createUserMutation = useMutation({
    mutationFn: async (payload: UserRegisterPayload) =>
      payload ? createUserAdminQuery(payload) : undefined,
    onSuccess: () =>
      queryClient.invalidateQueries({ queryKey: ["admin-users"] }),
    onError: (error) => {
      console.error(error);
      toast.error("Something went wrong: " + error);
    },
  });

  const deleteUserMutation = useMutation({
    mutationFn: async (userId: string) =>
      userId ? deleteUserAdminQuery(userId) : undefined,
    onSuccess: () =>
      queryClient.invalidateQueries({ queryKey: ["admin-users"] }),
  });

  const updateUserMutation = useMutation({
    mutationFn: async (payload: Partial<User>) => {
      if (payload && payload.id) {
        await updateUserAdminQuery(
          {
            username: payload.username,
            email: payload.email,
            avatar_url: payload.avatar_url,
          },
          payload.id
        );
      }
    },
    onSuccess: () =>
      queryClient.invalidateQueries({ queryKey: ["admin-users"] }),
  });

  const handleCreateUser = () => {
    createUserMutation.mutateAsync(getValues() as any);
  };

  const handleEditUser = (user: User) => {
    setEditingUser(user);
    setEditUsername(user.username);
    setEditEmail(user.email);
  };

  const handleUpdateUser = async ({
    username,
    email,
    formData,
  }: UserEdit1Payload) => {
    debugger;
    if (editingUser) {
      let globalFilePath;
      if (formData && editingUser.id) {
        const { filePath } = await uploadImageQuery({
          type: "user",
          id: editingUser.id,
          formData,
        });
        globalFilePath = filePath;
      }

      updateUserMutation.mutateAsync({
        username,
        email,
        id: editingUser.id,
        avatar_url: globalFilePath,
      });

      setEditingUser(null);
      setEditUsername("");
      setEditEmail("");
    }
  };

  if (isLoading) return <Typography>Loading...</Typography>;

  return (
    <Box sx={{ padding: 3 }}>
      <Typography variant="h4">User management</Typography>

      <Box sx={{ display: "flex", gap: 2, marginTop: 3 }}>
        <Controller
          name="username"
          control={control}
          render={({ field }) => (
            <TextField
              {...field}
              sx={{ width: 250, maxWidth: 250, my: 0 }}
              label="Username"
              type="text"
              margin="normal"
              error={!!(errors as FieldErrors<RegisterFormValues>).username}
              helperText={
                (errors as FieldErrors<RegisterFormValues>).username?.message
              }
            />
          )}
        />

        <Controller
          name="email"
          control={control}
          render={({ field }) => {
            return (
              <TextField
                {...field}
                label="Email"
                type="email"
                sx={{ width: 250, maxWidth: 250, my: 0 }}
                margin="normal"
                error={!!errors.email?.message}
                helperText={errors.email?.message}
              />
            );
          }}
        />

        <Controller
          name="password"
          control={control}
          render={({ field }) => (
            <TextField
              {...field}
              label="Password"
              type="password"
              sx={{ width: 250, maxWidth: 250, my: 0 }}
              margin="normal"
              error={!!errors.password}
              helperText={errors.password?.message}
            />
          )}
        />
        <Button
          variant="contained"
          color="primary"
          onClick={handleSubmit(handleCreateUser)}
          disabled={!isValid}
          sx={{ height: 56 }}
        >
          Create user
        </Button>
      </Box>

      <List sx={{ marginTop: 3 }}>
        {users?.map((user: User) => (
          <ListItem
            key={user.id}
            secondaryAction={
              <>
                <IconButton
                  edge="end"
                  onClick={() => handleEditUser(user)}
                  sx={{ marginRight: 1 }}
                >
                  <EditIcon />
                </IconButton>
                <IconButton
                  edge="end"
                  onClick={() => deleteUserMutation.mutate(user.id)}
                >
                  <DeleteIcon />
                </IconButton>
              </>
            }
          >
            {user.username} ({user.email})
          </ListItem>
        ))}
      </List>

      {/* Диалоговое окно для редактирования пользователя */}
      <EditUserDialog
        editingUser={editingUser}
        setEditingUser={setEditingUser}
        editUsername={editUsername}
        setEditUsername={setEditUsername}
        editEmail={editEmail}
        setEditEmail={setEditEmail}
        handleUpdateUser={({ username, email, formData }) =>
          handleUpdateUser({ username, email, formData })
        }
        getValues={getValues}
      />
    </Box>
  );
};

const EditUserDialog = ({
  editingUser,
  setEditingUser,
  editUsername,
  setEditUsername,
  editEmail,
  setEditEmail,
  handleUpdateUser,
  getValues,
}: {
  editingUser: User | null;
  setEditingUser: React.Dispatch<React.SetStateAction<any>>;
  editUsername: string;
  setEditUsername: React.Dispatch<React.SetStateAction<string>>;
  editEmail: string;
  setEditEmail: React.Dispatch<React.SetStateAction<string>>;
  handleUpdateUser: ({ username, email, formData }: UserEdit1Payload) => void;
  getValues: UseFormGetValues<{
    username: string;
    email: string;
    password: string;
  }>;
}) => {
  const [newAvatar, setNewAvatar] = useState<string | null>(null); // URL для предпросмотра
  const [selectedFile, setSelectedFile] = useState<File | null>(null); // Сохраненный файл
  const [isAvatarDialogOpen, setAvatarDialogOpen] = useState(false);

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    debugger;
    if (e.target.files && e.target.files[0]) {
      const file = e.target.files[0];
      setSelectedFile(file);
      setNewAvatar(URL.createObjectURL(file)); // Создаем URL для предпросмотра
    }
    setAvatarDialogOpen(false);
  };

  const {
    control,
    handleSubmit,
    reset,
    formState: { errors, isValid },
    getValues: editGetValues,
    setValue: editSetValue,
  } = useForm<EditFormValues>({
    resolver: zodResolver(editSchema),
    mode: "onChange",
    defaultValues: {
      username: editingUser?.username,
      email: editingUser?.email,
    },
  });

  const onSubmit = (data: {
    username: string;
    email: string;
    formData?: any;
  }) => {
    debugger;
    handleUpdateUser(data);
  };

  useEffect(() => {
    if (editingUser) {
      reset({
        username: editingUser.username || "",
        email: editingUser.email || "",
      });
    }
  }, [editingUser, reset]);

  return (
    <>
      <Dialog
        open={!!editingUser}
        onClose={() => {
          setEditingUser(null);
          setSelectedFile(null);
          setNewAvatar(null);
        }}
      >
        <DialogTitle>Edit user</DialogTitle>
        <DialogContent
          sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            minWidth: 500,
          }}
        >
          <Avatar
            preload={newAvatar || undefined}
            user={
              newAvatar
                ? { id: editingUser?.id || "", avatar_url: newAvatar }
                : editingUser || undefined
            }
            onClick={() => setAvatarDialogOpen(true)} // Открыть выбор аватара
          />
          <Controller
            name="username"
            control={control}
            render={({ field }) => (
              <TextField
                {...field}
                sx={{ width: 250, maxWidth: 250, mb: 2, mt: 4 }}
                label="Username"
                type="text"
                margin="normal"
                error={!!(errors as FieldErrors<EditFormValues>).username}
                helperText={
                  (errors as FieldErrors<EditFormValues>).username?.message
                }
              />
            )}
          />

          <Controller
            name="email"
            control={control}
            render={({ field }) => {
              return (
                <TextField
                  {...field}
                  label="Email"
                  type="email"
                  sx={{ width: 250, maxWidth: 250, my: 1 }}
                  margin="normal"
                  error={!!errors.email?.message}
                  helperText={errors.email?.message}
                />
              );
            }}
          />
        </DialogContent>
        <DialogActions>
          <Button
            onClick={() => {
              setEditingUser(null);
              setSelectedFile(null);
              setNewAvatar(null);
            }}
          >
            Cancel
          </Button>
          <Button
            onClick={() => {
              debugger;
              if (selectedFile) {
                const formData = new FormData();
                formData.append("file", selectedFile);
                editSetValue("formData", formData);
              }
              handleSubmit(onSubmit)();
            }}
            color="primary"
            variant="contained"
            disabled={!editUsername || !editEmail}
          >
            Save
          </Button>
        </DialogActions>
      </Dialog>

      {/* Диалог выбора фотографии */}
      <Dialog
        open={isAvatarDialogOpen}
        onClose={() => setAvatarDialogOpen(false)}
      >
        <DialogTitle>Select Avatar</DialogTitle>
        <DialogContent>
          <input
            type="file"
            accept="image/*"
            onChange={handleFileChange}
            style={{ display: "block", marginTop: "1rem" }}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setAvatarDialogOpen(false)}>Cancel</Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default ManageUsers;
