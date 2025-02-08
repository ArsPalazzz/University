import AdminSidebar from "../components/Admin/AdminSidebar";
import ManageCategories from "../components/Admin/ManageCategories";
import ManageFollows from "../components/Admin/ManageFollows";
import ManageIngredients from "../components/Admin/ManageIngredients";
import ManageRecipes from "../components/Admin/ManageRecipes";
import ManageUsers from "../components/Admin/ManageUsers";
import React from "react";
import { Outlet, Route, Routes } from "react-router-dom";

const AdminLayout = () => (
  <div style={{ display: "flex", minHeight: "100vh" }}>
    <AdminSidebar />
    <main style={{ flex: 1, padding: "16px" }}>
      <Outlet />
    </main>
  </div>
);

const AdminRoutes = () => (
  <Routes>
    <Route element={<AdminLayout />}>
      <Route path="/admin/users" element={<ManageUsers />} />
      <Route path="/admin/recipes" element={<ManageRecipes />} />
      <Route path="/admin/categories" element={<ManageCategories />} />
      <Route path="/admin/ingredients" element={<ManageIngredients />} />
      <Route path="/admin/follows" element={<ManageFollows />} />
    </Route>
  </Routes>
);

export default AdminRoutes;
