import {
  Box,
  SxProps,
  TextField,
  TextFieldProps,
  Typography,
} from "@mui/material";
import { ReactNode } from "react";

interface TextFieldAtomProps {
  label: string;
  value: string;
  setValue: (value: string) => void;
}

type TextFieldBaseProps = Omit<TextFieldProps, "error" | "placeholder">;

export interface ITextFieldProps extends TextFieldBaseProps {
  numeric?: boolean;
  decimal?: boolean;
  hidePassword?: boolean;
  multiline?: boolean;

  boxSx?: SxProps;

  error?: boolean;
  hasError?: boolean;
  hasInputRef?: boolean;

  image?: string;
  startAdornment?: ReactNode;
  endAdornment?: ReactNode;
  placeholder?: string;
  disabledColor?: string;
}

export const TextFieldAtom = ({
  multiline,
  error,
  hasError,
  hasInputRef,
  startAdornment,
  endAdornment,
  InputProps,
  inputProps,
  disabledColor,
  numeric,
  hidePassword,
  decimal,
  boxSx,
  sx,
  ...rest
}: ITextFieldProps) => {
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        gap: 1,
        ...boxSx,
      }}
    >
      {rest.title && (
        <Typography sx={{ textAlign: "left" }}>{rest.title}</Typography>
      )}

      <TextField
        multiline={multiline}
        value={rest.value}
        //onChange={(e) => setValue(e.target.value)}
        sx={{ mb: 2, ...sx }}
        {...rest}
        error={!!error || hasError}
        helperText={rest.helperText}
      />
    </Box>
  );
};
