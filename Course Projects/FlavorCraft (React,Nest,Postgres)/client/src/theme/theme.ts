import { createTheme } from "@mui/material/styles";
import { PaletteColorOptions } from "@mui/material/styles";

declare module "@mui/material/styles" {
  interface Palette {
    active?: PaletteColorOptions;
    inactive?: PaletteColorOptions;
  }
  interface PaletteOptions {
    active?: PaletteColorOptions;
    inactive?: PaletteColorOptions;
  }
}

const theme = createTheme({
  palette: {
    primary: {
      main: "#FFB74D", // Апельсиновый
    },
    secondary: {
      main: "#8BC34A", // Светло-зелёный
    },
    error: {
      main: "#E57373", // Нежный красный
    },
    active: {
      main: "#FFD54F", // Ярко-жёлтый для активного состояния
    },
    inactive: {
      main: "#BDBDBD", // Серый для неактивного состояния
    },
    background: {
      default: "#FFF8E1", // Кремовый фон
      paper: "#FFFFFF", // Фон для компонентов
    },
    text: {
      primary: "#424242", // Тёмно-серый текст
      secondary: "#757575", // Светло-серый текст
      disabled: "#BDBDBD", // Текст неактивных элементов
    },
    divider: "#E0E0E0", // Границы и разделители
  },
  typography: {
    fontFamily: "Arial, sans-serif",
  },
});

export default theme;
