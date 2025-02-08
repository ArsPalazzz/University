import { ThemeProvider } from "@mui/material";
import { AuthProvider, useAuth } from "providers/AuthContext";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  BrowserRouter,
} from "react-router-dom";

import { ToastContainer } from "react-toastify";
import AppRoutes from "routes";
import theme from "./theme/theme";
import ScrollToTop from "./components/ScrollToTop/ScrollToTop";
import { AuthRole } from "consts/entities/user.const";
import AdminRoutes from "routes/AdminRoutes";

function App() {
  return (
    <>
      <ThemeProvider theme={theme}>
        <AuthProvider>
          <AppContent />

          <ToastContainer key="toast-container" />
        </AuthProvider>
      </ThemeProvider>
    </>
  );
}

function AppContent() {
  const { user } = useAuth();
  console.log("userHui: ", user);

  // Если роль пользователя - admin, отображаем маршруты для админа
  if (user?.role === AuthRole.Admin) {
    return (
      <Router>
        <ScrollToTop />
        <AdminRoutes /> {/* Ваши маршруты для админа */}
      </Router>
    );
  }

  // Для обычных пользователей отображаем стандартные маршруты
  return (
    <Router>
      <ScrollToTop />
      <AppRoutes /> {/* Ваши маршруты для обычных пользователей */}
    </Router>
  );
}

export default App;
