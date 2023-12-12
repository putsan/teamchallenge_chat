import { useField } from "formik";
import { Grid, InputAdornment, TextField, Typography } from "@mui/material";
import VisibilityIcon from "@mui/icons-material/Visibility";
import VisibilityOffIcon from "@mui/icons-material/VisibilityOff";
import { useState } from "react";
import ErrorFeedback from "./ErrorFeedback.jsx";
import typography from "../../../theme/typography.js";
import palette from "../../../theme/palette.js";

const CustomInputField = ({ label, name, type = "text", placeholder }) => {
  const [isVisible, setIsVisible] = useState(false);

  const toggleVisibility = () => {
    setIsVisible((prev) => !prev);
  };

  const [field, meta] = useField(name);

  const inputStyles = {
    "& .MuiOutlinedInput-root.Mui-focused .MuiOutlinedInput-notchedOutline ": {
      borderColor:
        meta.error && meta.touched ? palette.error.main : palette.grey["200"],
    },
    "&:hover .MuiOutlinedInput-notchedOutline": {
      borderColor: meta.error && meta.touched && palette.error.main,
    },

    "& .MuiOutlinedInput-notchedOutline": {
      borderColor: meta.error && meta.touched && palette.error.main,
    },
  };

  const inputProps = {
    style: {
      color: meta.error && meta.touched ? palette.error.main : "inherit",
    },
    endAdornment:
      type === "password" ? (
        <InputAdornment
          position="end"
          sx={{ cursor: "pointer" }}
          onMouseDown={(e) => {
            e.preventDefault();
            toggleVisibility();
          }}
        >
          {isVisible ? <VisibilityIcon /> : <VisibilityOffIcon />}
        </InputAdornment>
      ) : undefined,
  };

  return (
    <Grid
      item
      display="flex"
      flexDirection="column"
      justifyContent="flex-start"
      sx={{
        margin: "0 25px 2px 25px",
        borderColor: palette.error.main,
      }}
      position="relative"
    >
      <Typography
        display="flex"
        sx={{
          ...typography.caption,
          textTransform: "uppercase",
          paddingBottom: "8px",
        }}
      >
        {label}
      </Typography>
      <TextField
        type={type === "password" && !isVisible ? "password" : "text"}
        value={field.value}
        onChange={field.onChange}
        onBlur={field.onBlur}
        name={field.name}
        variant="outlined"
        placeholder={placeholder}
        sx={inputStyles}
        InputProps={inputProps}
      />
      <ErrorFeedback errors={meta.error} touched={meta.touched} />
    </Grid>
  );
};

export default CustomInputField;
