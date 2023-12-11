import { Field } from "formik";
import { Grid, Typography, TextField, InputAdornment } from "@mui/material";
import VisibilityIcon from "@mui/icons-material/Visibility";
import VisibilityOffIcon from "@mui/icons-material/VisibilityOff";
import { useState } from "react";
import ErrorFeedback from "./ErrorFeedback.jsx";
import typography from "../../../theme/typography.js";

const AuthInputPasswordBlock = ({ label, name, placeholder }) => {
  const [isVisible, setIsVisible] = useState(false);
  const toggleVisibility = () => {
    setIsVisible((prev) => !prev);
  };
  return (
    <Grid
      item
      display="flex"
      flexDirection="column"
      justifyContent="flex-start"
      sx={{ margin: "0 25px 2px 25px" }}
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
      <Field name={name}>
        {({ field, meta }) => (
          <>
            <TextField
              type={!isVisible ? "password" : "text"}
              value={field.value}
              onChange={field.onChange}
              onBlur={field.onBlur}
              name={field.name}
              variant="outlined"
              placeholder={placeholder}
              InputProps={{
                endAdornment: (
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
                ),
              }}
            />
            <ErrorFeedback errors={meta.error} touched={meta.touched} />
          </>
        )}
      </Field>
    </Grid>
  );
};

export default AuthInputPasswordBlock;
