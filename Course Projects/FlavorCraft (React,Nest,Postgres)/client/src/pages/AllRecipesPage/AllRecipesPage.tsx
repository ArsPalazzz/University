import LoadingSpinner from "../../components/LoadingSpinner/LoadingSpinner";
import RecipeListWithTitle from "../../components/RecipeListWithTitle/RecipeListWithTitle";
import {
  Box,
  Card,
  CardContent,
  Grid,
  MenuItem,
  Pagination,
  Select,
  TextField,
  Typography,
} from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import axiosInstance from "config/axios";
import { useState } from "react";
import { PaginatedResponse } from "types/common/PaginatedResponse";
import { RecipeFilter, RecipeFull, RecipeMain } from "types/entities/recipe";

const fetchRecipes = async (filters: any) => {
  if (!filters.sortBy) filters.sortBy = "created_at";
  if (!filters.order) filters.order = "desc";

  const { data } = await axiosInstance.get<PaginatedResponse<RecipeFilter>>(
    "/recipes",
    { params: filters }
  );
  return data;
};

export const AllRecipesPage = () => {
  const [filters, setFilters] = useState({
    search: "",
    minCalories: 0,
    maxCalories: 0,
    categories: [],
    tags: [],
    sortBy: "",
    order: "",
    limit: 9,
    page: 1,
  });

  const { data, isLoading, error } = useQuery({
    queryKey: ["recipes", filters],
    queryFn: () => fetchRecipes(filters),
  });

  console.log(data);

  const handleFilterChange = (key: any, value: any) => {
    setFilters((prev) => ({ ...prev, [key]: value, page: 1 }));
  };

  const handlePaginationChange = (event: any, value: any) => {
    setFilters((prev) => ({ ...prev, page: value }));
  };

  return (
    <Box sx={{ p: 4, width: "100%" }}>
      {/* Top Banner */}
      <Box
        sx={{ height: 200, backgroundColor: "#ddd", mb: 4, width: "100%" }}
      />

      {/* Search and Filters */}
      <Grid container spacing={2} sx={{ mb: 4, width: "100%" }}>
        <Grid item xs={12} sm={6} md={3}>
          <TextField
            fullWidth
            label="Search"
            value={filters.search}
            onChange={(e) => handleFilterChange("search", e.target.value)}
          />
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <TextField
            fullWidth
            label="Min Calories"
            type="number"
            value={filters.minCalories}
            onChange={(e) =>
              handleFilterChange("minCalories", Number(e.target.value))
            }
          />
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <TextField
            fullWidth
            label="Max Calories"
            type="number"
            value={filters.maxCalories}
            onChange={(e) =>
              handleFilterChange("maxCalories", Number(e.target.value))
            }
          />
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <Select
            fullWidth
            value={filters.sortBy}
            displayEmpty
            onChange={(e) => handleFilterChange("sortBy", e.target.value)}
          >
            <MenuItem value="">Sort By</MenuItem>
            <MenuItem value="calories">Calories</MenuItem>
            <MenuItem value="rating">Rating</MenuItem>
            <MenuItem value="created_at">Created At</MenuItem>
          </Select>
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <Select
            fullWidth
            value={filters.order}
            displayEmpty
            onChange={(e) => handleFilterChange("order", e.target.value)}
          >
            <MenuItem value="">Order</MenuItem>
            <MenuItem value="asc">Ascending</MenuItem>
            <MenuItem value="desc">Descending</MenuItem>
          </Select>
        </Grid>
      </Grid>

      {/* Recipe Cards */}
      <Grid container spacing={2}>
        {isLoading ? (
          <LoadingSpinner />
        ) : (
          data?.data && (
            <RecipeListWithTitle
              data={data?.data as any}
              isLoading={isLoading}
              error={error}
            />
          )
        )}
      </Grid>

      {/* Pagination */}
      <Box sx={{ mt: 4, display: "flex", justifyContent: "center" }}>
        <Pagination
          count={data?.totalPages || 0}
          page={filters.page}
          onChange={handlePaginationChange}
        />
      </Box>
    </Box>
  );
};
