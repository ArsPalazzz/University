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
  FormControl,
  Select,
  MenuItem,
  FormHelperText,
  Checkbox,
  ListItemText,
  FormControlLabel,
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
import { Recipe } from "types/entities/recipe";
import { calculateCalories } from "../../utils/common";
import { recipeCreationSchema } from "pages/CreateRecipePage/CreateRecipePage";
import { fetchAllCuisinesQuery } from "queries/cuisine";
import { fetchAllCategoriesQuery } from "queries/category";
import { fetchAllTagsQuery } from "queries/tag";
import { fromMinutesToHours, fromPatternToMinutes } from "../../utils/time";
import {
  createRecipeQuery,
  fetchFullRecipeByIdQuery,
  updateRecipeQuery,
} from "queries/recipe";
import {
  createRecipeAdminQuery,
  deleteRecipeAdminQuery,
  getAllRecipesAdminQuery,
  getFullRecipeByIdAdminQuery,
} from "queries/admin/recipe";

type RecipeCreationSchema = z.infer<typeof recipeCreationSchema>;

const ManageRecipes = () => {
  const queryClient = useQueryClient();

  const [open, setOpen] = useState(false);
  const [isEdit, setIsEdit] = useState(false);
  const [recipeIdToEdit, setRecipeIdToEdit] = useState("");

  const handleOpenCreate = () => setOpen(true);
  const handleOpenEdit = (recipeId: string) => {
    setRecipeIdToEdit(recipeId);
    setIsEdit(true);
    setOpen(true);
  };
  const handleClose = () => {
    setRecipeIdToEdit("");
    setIsEdit(false);
    setOpen(false);
  };

  const [editingRecipe, setEditingRecipe] = useState<Recipe | null>(null);
  // const [editUsername, setEditUsername] = useState("");
  // const [editEmail, setEditEmail] = useState("");

  const { data: recipes, isLoading } = useQuery({
    queryKey: ["admin-recipes"],
    queryFn: getAllRecipesAdminQuery,
  });

  console.log("recipes: ", recipes);

  const deleteRecipeMutation = useMutation({
    mutationFn: async (recipeId: string) =>
      recipeId ? deleteRecipeAdminQuery(recipeId) : undefined,
    onSuccess: () =>
      queryClient.invalidateQueries({ queryKey: ["admin-recipes"] }),
  });

  if (isLoading) return <Typography>Loading...</Typography>;

  return (
    <>
      {isEdit ? (
        <AddRecipeDialog
          open={open}
          handleClose={handleClose}
          recipeId={recipeIdToEdit}
        />
      ) : (
        <AddRecipeDialog open={open} handleClose={handleClose} />
      )}

      <Box sx={{ padding: 3 }}>
        <Typography variant="h4">Recipe management</Typography>

        <Box sx={{ display: "flex", gap: 2, marginTop: 3 }}>
          <Button
            variant="contained"
            color="primary"
            onClick={handleOpenCreate}
            sx={{ height: 56 }}
          >
            Create recipe
          </Button>
        </Box>

        <List sx={{ marginTop: 3 }}>
          {recipes?.map((recipe: Recipe) => (
            <ListItem
              key={recipe.id}
              secondaryAction={
                <>
                  <IconButton
                    edge="end"
                    onClick={() => handleOpenEdit(recipe.id)}
                    sx={{ marginRight: 1 }}
                  >
                    <EditIcon />
                  </IconButton>
                  <IconButton
                    edge="end"
                    onClick={() => deleteRecipeMutation.mutate(recipe.id)}
                  >
                    <DeleteIcon />
                  </IconButton>
                </>
              }
            >
              {recipe.id} ({recipe.title}) ({recipe.description})
            </ListItem>
          ))}
        </List>
      </Box>
    </>
  );
};

const AddRecipeDialog = ({
  open,
  handleClose,
  recipeId,
}: {
  open: any;
  handleClose: any;
  recipeId?: string | undefined;
}) => {
  const [selectedFile, setSelectedFile] = useState<any | null>(null);
  const [preview, setPreview] = useState("");

  const [caloriesState, setCaloriesState] = useState<number | undefined>();

  const handleCheckboxChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setIsRange(e.target.checked);
    if (!e.target.checked) {
      setValue("portions_max", undefined, { shouldValidate: true }); // Очистка значения второго инпута
    }
  };

  const {
    register,
    control,
    trigger,
    handleSubmit,
    setValue,
    watch,
    formState: { errors, isValid },
  } = useForm<RecipeCreationSchema>({
    mode: "onChange",
    resolver: zodResolver(recipeCreationSchema),
    defaultValues: {
      ingredients: [{ name: "", quantity: "" }],
      instructions: [""],
    },
  });

  console.log("RES: ", recipeId);

  const {
    data: existingRecipe,
    isLoading: isRecipeDataLoading,
    error,
  } = useQuery({
    queryKey: ["current-recipe", recipeId],
    queryFn: async () => {
      if (!recipeId) return undefined;
      try {
        return await getFullRecipeByIdAdminQuery(recipeId);
      } catch (err: any) {
        if (err.response?.status === 404) {
          return null;
        }
        throw err;
      }
    },
    enabled: !!recipeId,
    retry: false,
  });

  const portionsMin = watch("portions_min");
  const portionsMax = watch("portions_max");

  const proteins = watch("protein");
  const fats = watch("fat");
  const carbs = watch("carbs");

  const image_path = watch("image_path");

  useEffect(() => {
    if (proteins && fats && carbs) {
      const calories = calculateCalories(proteins, fats, carbs);
      setCaloriesState(calories);
    } else setCaloriesState(undefined);
  }, [proteins, fats, carbs]);

  const queryClient = useQueryClient();

  const { data: categories } = useQuery({
    queryKey: ["all-categories"],
    queryFn: fetchAllCategoriesQuery,
  });

  useEffect(() => {
    setMinMoreThanMax(portionsMax ? portionsMin >= portionsMax : false);

    if (portionsMax ? portionsMin >= portionsMax : false) {
      setMinMoreThanMaxErr("Decrease your max yield");
    } else setMinMoreThanMaxErr("");
  }, [portionsMin, portionsMax]);

  useEffect(() => {
    if (existingRecipe) {
      setValue("title", existingRecipe.title);
      setValue("description", existingRecipe.description);
      if (existingRecipe.ingredients) {
        const ingredients = existingRecipe.ingredients.length
          ? existingRecipe.ingredients.map(({ name, quantity }) => ({
              name,
              quantity,
            }))
          : [{ name: "", quantity: "" }];

        setValue(
          "ingredients",
          ingredients as [
            { name: string; quantity: string },
            ...{ name: string; quantity: string }[]
          ]
        );
      }
      setValue("category_name", existingRecipe.category_name);
      setValue("cuisine_name", existingRecipe.cuisine.name);
      if (existingRecipe.tags) {
        const tags = existingRecipe.tags.length
          ? existingRecipe.tags.map((tag) => tag.name)
          : [""];

        setValue("tags", tags as [name: string]);
      }
      if (existingRecipe.instructions) {
        const instructions = existingRecipe.instructions.length
          ? existingRecipe.instructions.map((instruction) => instruction)
          : [""];

        setValue("instructions", instructions as [name: string]);
      }
      setValue(
        "difficulty_level",
        existingRecipe.difficulty_level as "Easy" | "Medium" | "Hard"
      );

      setValue(
        "image_path",
        process.env.REACT_APP_API_URL + existingRecipe.image_path
      );

      setValue("portions_min", existingRecipe.portions_min);
      if (existingRecipe.portions_max) {
        setIsRange(true);
        setValue("portions_max", existingRecipe.portions_max);
      }
      setValue("protein", existingRecipe.protein);
      setValue("fat", existingRecipe.fats);
      setValue("carbs", existingRecipe.carbs);

      setValue(
        "prep_time",
        fromMinutesToHours(existingRecipe.prep_time).toString(),
        {
          shouldValidate: true,
        }
      );
    }
  }, [existingRecipe, setValue]);

  useEffect(() => {
    setMinMoreThanMax(portionsMax ? portionsMin >= portionsMax : false);

    if (portionsMax ? portionsMin >= portionsMax : false) {
      setMinMoreThanMaxErr("Decrease your max yield");
    } else setMinMoreThanMaxErr("");
  }, [portionsMin, portionsMax]);

  const createOrUpdateRecipeMutation = useMutation({
    mutationFn: async (data: any) => {
      try {
        if (!data || Object.keys(data).length === 0) return;

        if (!data.portions_max) data.portions_max = data.portions_min;
        let usedRecipeId;

        if (recipeId) usedRecipeId = await updateRecipeQuery(data, recipeId);
        else usedRecipeId = await createRecipeAdminQuery(data);

        debugger;
        if (usedRecipeId && selectedFile) {
          const formData = new FormData();
          debugger;
          formData.append("file", selectedFile);

          await uploadImageQuery({
            type: "recipe",
            id: usedRecipeId,
            formData,
          });
        }
        debugger;

        return false;
      } catch (error: any) {
        debugger;
        console.error(
          "Error:",
          error.response.data?.message?.message || error.response.data?.message
        );
        toast.error(
          `Error: ${
            error.response.data?.message?.message ||
            error.response.data?.message
          }`
        );
      }
    },
    onSuccess: (arg) => {
      debugger;
      if (arg === false) {
        queryClient.invalidateQueries({
          queryKey: ["admin-recipes"],
          type: "all",
        });
        handleClose();
      }
    },
    onError: (error) => {
      console.error("Error: ", error);
    },
  });

  const [minMoreThanMax, setMinMoreThanMax] = useState(false);

  const createOrUpdateRecipeHandler = (data: any) => {
    console.log("allData: ", data);
    const minutesCount = fromPatternToMinutes(data.prep_time);
    data.prep_time = minutesCount;
    debugger;
    createOrUpdateRecipeMutation.mutateAsync(data);
  };

  const { data: cuisines } = useQuery({
    queryKey: ["all-cuisines"],
    queryFn: fetchAllCuisinesQuery,
  });

  const { data: tags } = useQuery({
    queryKey: ["all-tags"],
    queryFn: fetchAllTagsQuery,
  });

  console.log(existingRecipe);

  const levels = ["Easy", "Medium", "Hard"];
  const [isRange, setIsRange] = useState(false);

  const [minMoreThanMaxErr, setMinMoreThanMaxErr] = useState("");

  return (
    <Dialog open={open} onClose={handleClose} maxWidth="lg" fullWidth>
      <DialogContent>
        <Box
          sx={{
            width: "100%",
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            gap: 4,
          }}
        >
          <Controller
            name="image_path"
            control={control}
            render={({ field }) => (
              <Box
                sx={{
                  width: 600,
                  height: 350,
                  backgroundColor: "#e0e0e0",
                  backgroundImage: field.value ? `url(${field.value})` : "none",
                  backgroundSize: "cover",
                  backgroundPosition: "center",
                  border: "1px solid #ccc",
                  display: "flex",
                  alignItems: "flex-end",
                  justifyContent: "flex-end",
                  mb: 2,
                }}
              >
                <Button variant="contained" component="label" sx={{ m: 1 }}>
                  Upload
                  <input
                    type="file"
                    accept=".jpg"
                    hidden
                    onChange={(e) => {
                      if (e.target.files?.[0]) {
                        const file = e.target.files[0] as any;
                        debugger;

                        if (file) {
                          setSelectedFile(file);
                          setPreview(URL.createObjectURL(file));
                          console.log(
                            "image_path_value: ",
                            URL.createObjectURL(file)
                          );
                          setValue("image_path", URL.createObjectURL(file), {
                            shouldValidate: true,
                          });
                        }
                      }
                    }}
                  />
                </Button>
              </Box>
            )}
          />
          {errors.image_path && (
            <Typography color="error" variant="body2">
              {errors.image_path.message}
            </Typography>
          )}

          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              gap: 1,
              width: "100%",
            }}
          >
            <Typography sx={{ textAlign: "left" }}>Title</Typography>
            <TextField
              placeholder="Pasta"
              fullWidth
              {...register("title")}
              error={!!errors.title}
              helperText={errors.title?.message}
            />
          </Box>

          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              gap: 1,
              width: "100%",
            }}
          >
            <Typography sx={{ textAlign: "left" }}>Description</Typography>
            <TextField
              placeholder="Great Pasta"
              fullWidth
              multiline
              minRows={3}
              {...register("description")}
              error={!!errors.description}
              helperText={errors.description?.message}
            />
          </Box>

          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              gap: 1,
              width: "100%",
            }}
          >
            <Typography sx={{ textAlign: "left" }}>Ingredients</Typography>
            <Controller
              name="ingredients"
              control={control}
              render={({ field }) => (
                <Box
                  sx={{
                    display: "flex",
                    flexDirection: "column",
                  }}
                >
                  {field?.value?.map((ingredient, index) => (
                    <Box
                      key={index}
                      sx={{ display: "flex", gap: 1, mb: 1, width: "100%" }}
                    >
                      <TextField
                        fullWidth
                        label="Ingredient"
                        value={ingredient.name}
                        onChange={(e) => {
                          const updated = [...field.value];
                          updated[index].name = e.target.value;
                          field.onChange(updated);
                        }}
                      />
                      <TextField
                        fullWidth
                        label="Quantity"
                        value={ingredient.quantity}
                        onChange={(e) => {
                          const updated = [...field.value];
                          updated[index].quantity = e.target.value;
                          field.onChange(updated);
                        }}
                      />
                      <IconButton
                        onClick={() => {
                          if (field.value.length === 1)
                            return alert(
                              "You cannot remove the only ingredient"
                            );

                          const updated = field.value.filter(
                            (_, i) => i !== index
                          );
                          field.onChange(updated);
                        }}
                        color="error"
                      >
                        <DeleteIcon />
                      </IconButton>
                    </Box>
                  ))}
                  <Button
                    variant="outlined"
                    sx={{ maxWidth: 200 }}
                    onClick={() => {
                      const lastIngredient =
                        field.value[field.value.length - 1];
                      if (
                        lastIngredient.name.trim() === "" &&
                        lastIngredient.quantity.trim() === ""
                      ) {
                        alert(
                          "Please fill in the last ingredient and quantity before adding a new one."
                        );
                        return;
                      }

                      field.onChange([
                        ...field.value,
                        { name: "", quantity: "" },
                      ]);
                    }}
                  >
                    Add Ingredient
                  </Button>
                </Box>
              )}
            />
          </Box>

          <FormControl fullWidth error={!!errors.category_name}>
            <Typography sx={{ textAlign: "left" }}>Category</Typography>
            <Controller
              name="category_name"
              control={control} // Передаем `control` из `useForm`
              render={({ field }) => (
                <Select
                  {...field}
                  value={field.value || ""} // Обрабатываем значение
                  onChange={(e) => field.onChange(e.target.value)} // Обрабатываем изменения
                  MenuProps={{
                    PaperProps: {
                      style: {
                        maxHeight: 200, // Ограничиваем высоту списка
                        overflow: "auto", // Добавляем скроллинг
                      },
                    },
                  }}
                  sx={{
                    textAlign: "left", // Выравнивание текста слева
                    "& .MuiSelect-select": {
                      textAlign: "left", // Важно для содержимого
                    },
                  }}
                >
                  {categories?.map((item) => (
                    <MenuItem key={item.name} value={item.name}>
                      {item.name}
                    </MenuItem>
                  ))}
                </Select>
              )}
            />
            {errors.category_name && (
              <FormHelperText>{errors.category_name?.message}</FormHelperText>
            )}
          </FormControl>

          <FormControl fullWidth error={!!errors.cuisine_name}>
            <Typography sx={{ textAlign: "left" }}>Cuisine</Typography>
            <Controller
              name="cuisine_name"
              control={control} // Передаем `control` из `useForm`
              render={({ field }) => (
                <Select
                  {...field}
                  value={field.value || ""} // Обрабатываем значение
                  onChange={(e) => field.onChange(e.target.value)} // Обрабатываем изменения
                  MenuProps={{
                    PaperProps: {
                      style: {
                        maxHeight: 200, // Ограничиваем высоту списка
                        overflow: "auto", // Добавляем скроллинг
                      },
                    },
                  }}
                  sx={{
                    textAlign: "left", // Выравнивание текста слева
                    "& .MuiSelect-select": {
                      textAlign: "left", // Важно для содержимого
                    },
                  }}
                >
                  {cuisines?.map((item) => (
                    <MenuItem key={item.name} value={item.name}>
                      {item.name}
                    </MenuItem>
                  ))}
                </Select>
              )}
            />
            {errors.cuisine_name && (
              <FormHelperText>{errors.cuisine_name?.message}</FormHelperText>
            )}
          </FormControl>

          <FormControl fullWidth error={!!errors.tags}>
            <Typography sx={{ textAlign: "left" }}>Tags</Typography>
            <Controller
              name="tags"
              control={control} // Передаем `control` из `useForm`
              rules={{
                validate: (value) => {
                  if (!value || value.length === 0) {
                    return "At least one tag must be selected";
                  }
                  return true;
                },
              }}
              render={({ field }) => (
                <Select
                  {...field}
                  multiple
                  value={field.value || []} // Устанавливаем значения
                  onChange={(e) => field.onChange(e.target.value)} // Обновляем значение
                  MenuProps={{
                    PaperProps: {
                      style: {
                        maxHeight: 200, // Ограничиваем высоту списка
                        overflow: "auto", // Добавляем скроллинг
                      },
                    },
                  }}
                  sx={{
                    textAlign: "left", // Выравнивание текста слева
                    "& .MuiSelect-select": {
                      textAlign: "left", // Важно для содержимого
                    },
                  }}
                  renderValue={(selected) => selected.join(", ")} // Отображение выбранных значений
                >
                  {tags?.map((item) => (
                    <MenuItem key={item.name} value={item.name}>
                      <Checkbox
                        checked={(field.value || []).includes(item.name)}
                      />
                      <ListItemText primary={item.name} />
                    </MenuItem>
                  ))}
                </Select>
              )}
            />
            {errors.tags && (
              <FormHelperText>{errors.tags?.message}</FormHelperText>
            )}
          </FormControl>

          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              gap: 1,
              width: "100%",
            }}
          >
            <Typography sx={{ textAlign: "left" }}>Instructions</Typography>
            <Controller
              name="instructions"
              control={control}
              render={({ field }) => (
                <Box
                  sx={{
                    display: "flex",
                    flexDirection: "column",
                  }}
                >
                  {field?.value?.map((instruction, index) => (
                    <Box
                      key={index}
                      sx={{ display: "flex", gap: 1, mb: 1, width: "100%" }}
                    >
                      <TextField
                        fullWidth
                        label={`Step ${index + 1}`}
                        value={instruction}
                        onChange={(e) => {
                          const updated = [...field.value];
                          updated[index] = e.target.value;
                          field.onChange(updated);
                        }}
                        error={!!errors.instructions?.[index]?.message}
                        helperText={errors.instructions?.[index]?.message}
                      />
                      <IconButton
                        onClick={() => {
                          const updated = field.value.filter(
                            (_, i) => i !== index
                          );
                          field.onChange(updated);
                        }}
                        color="error"
                      >
                        <DeleteIcon />
                      </IconButton>
                    </Box>
                  ))}
                  <Button
                    variant="outlined"
                    sx={{ maxWidth: 200 }}
                    onClick={() => {
                      field.onChange([...field.value, ""]);
                    }}
                  >
                    Add Step
                  </Button>
                </Box>
              )}
            />
          </Box>

          <FormControl fullWidth error={!!errors?.difficulty_level}>
            <Typography sx={{ textAlign: "left" }}>
              Difficulty of cooking
            </Typography>
            <Controller
              name="difficulty_level"
              control={control} // Передаем `control` из `useForm`
              render={({ field }) => (
                <Select
                  {...field}
                  value={field.value || ""} // Обрабатываем значение
                  onChange={(e) => field.onChange(e.target.value)} // Обрабатываем изменения
                  MenuProps={{
                    PaperProps: {
                      style: {
                        maxHeight: 200, // Ограничиваем высоту списка
                        overflow: "auto", // Добавляем скроллинг
                      },
                    },
                  }}
                  sx={{
                    textAlign: "left", // Выравнивание текста слева
                    "& .MuiSelect-select": {
                      textAlign: "left", // Важно для содержимого
                    },
                  }}
                >
                  {levels?.map((item) => (
                    <MenuItem key={item} value={item}>
                      {item}
                    </MenuItem>
                  ))}
                </Select>
              )}
            />
            {errors?.difficulty_level && (
              <FormHelperText>
                {errors.difficulty_level?.message}
              </FormHelperText>
            )}
          </FormControl>

          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              gap: 1,
              width: "100%",
            }}
          >
            <Typography sx={{ textAlign: "left" }}>Cook time</Typography>
            <TextField
              fullWidth
              placeholder="e.g., 2h, 7h 29m, or 29m"
              error={!!errors.prep_time}
              helperText={
                errors.prep_time?.message ||
                "Format: optional hours with 'h', and/or mandatory minutes with 'm'"
              }
              {...register("prep_time")}
              onChange={(e) =>
                setValue("prep_time", e.target.value, { shouldValidate: true })
              }
            />
          </Box>

          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              gap: 1,
              width: "100%",
            }}
          >
            <Typography sx={{ textAlign: "left" }}>Yield</Typography>
            <Box sx={{ display: "flex", gap: 3 }}>
              <TextField
                fullWidth
                placeholder="from"
                type="number"
                {...register("portions_min", {
                  valueAsNumber: true, // Преобразует значение в число
                  onChange: () => {
                    trigger(["portions_min", "portions_max"]); // Запуск полной проверки, включая superRefine
                  },
                })}
                error={!!errors.portions_min}
                helperText={errors.portions_min?.message}
              />

              <TextField
                fullWidth
                type="number"
                placeholder="to"
                disabled={!isRange} // Блокировка второго инпута
                {...register("portions_max", {
                  valueAsNumber: true, // Преобразует значение в число
                  onChange: () => {
                    trigger(["portions_min", "portions_max"]); // Запуск полной проверки, включая superRefine
                  },
                })}
                error={!!errors.portions_max}
                helperText={errors.portions_max?.message}
              />

              <FormControlLabel
                control={
                  <Checkbox checked={isRange} onChange={handleCheckboxChange} />
                }
                label="Range"
              />
            </Box>
            {minMoreThanMaxErr && (
              <Typography color="red" sx={{ textAlign: "left" }}>
                {minMoreThanMaxErr}
              </Typography>
            )}
          </Box>

          <Box
            sx={{
              width: "100%",
              display: "flex",
              flexDirection: "column",
              gap: 2,
            }}
          >
            <Typography
              sx={{ textAlign: "left" }}
              variant="h6"
              fontWeight={700}
            >
              Macronutrients
            </Typography>
            <Box>
              <Typography sx={{ textAlign: "left" }}>Proteins</Typography>
              <TextField
                placeholder="10"
                fullWidth
                sx={{ mb: 2 }}
                {...register("protein", {
                  valueAsNumber: true,
                })}
                error={!!errors.protein}
                helperText={errors.protein?.message}
              />
              <Box>
                <Typography sx={{ textAlign: "left" }}>Fats</Typography>
                <TextField
                  placeholder="10"
                  fullWidth
                  sx={{ mb: 2 }}
                  {...register("fat", {
                    valueAsNumber: true,
                  })}
                  error={!!errors.fat}
                  helperText={errors.fat?.message}
                />
              </Box>
              <Box>
                <Typography sx={{ textAlign: "left" }}>Carbs</Typography>
                <TextField
                  placeholder="10"
                  fullWidth
                  sx={{ mb: 2 }}
                  {...register("carbs", {
                    valueAsNumber: true,
                  })}
                  error={!!errors.carbs}
                  helperText={errors.carbs?.message}
                />
              </Box>

              <Box sx={{ mt: 2 }}>
                <Typography sx={{ textAlign: "left" }}>Calories</Typography>
                <TextField
                  placeholder={calculateCalories(10, 10, 10).toString()}
                  fullWidth
                  sx={{ mb: 2 }}
                  value={caloriesState}
                />
              </Box>
            </Box>
          </Box>

          <Button
            type="submit"
            variant="contained"
            disabled={
              !isValid ||
              (minMoreThanMax && !!portionsMax && !!portionsMin) ||
              (isRange && !!portionsMin && !portionsMax)
            }
            sx={{
              mt: 4,
              display: "flex",
              alignSelf: "flex-end",
              textTransform: "capitalize",
              width: 200,
              height: 60,
            }}
            onClick={handleSubmit(createOrUpdateRecipeHandler)}
          >
            <Typography fontWeight={600}>{"Create"} Recipe</Typography>
          </Button>
        </Box>
      </DialogContent>
    </Dialog>
  );
};

export default ManageRecipes;
