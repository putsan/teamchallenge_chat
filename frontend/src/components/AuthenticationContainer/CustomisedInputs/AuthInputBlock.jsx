import { Field } from "formik";
import { Grid, Typography, TextField } from "@mui/material";
import ErrorFeedback from "./ErrorFeedback.jsx";
import typography from "../../../theme/typography.js";

const AuthInputBlock = ({ label, name, placeholder }) => {
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
              type="text"
              value={field.value}
              onChange={field.onChange}
              onBlur={field.onBlur}
              name={field.name}
              variant="outlined"
              placeholder={placeholder}
            />
            <ErrorFeedback errors={meta.error} touched={meta.touched} />
          </>
        )}
      </Field>
    </Grid>
  );
};

export default AuthInputBlock;
