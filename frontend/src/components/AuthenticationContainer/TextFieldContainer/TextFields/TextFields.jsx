import { Grid, TextField, Typography } from "@mui/material";
import "./TextFields.scss";
import VisibilityOffIcon from "@mui/icons-material/VisibilityOff";
import VisibilityIcon from "@mui/icons-material/Visibility";
import { useState } from "react";
import palette from "../../../../theme/palette.js";
import typography from "../../../../theme/typography.js";
import { TEXT_FIELD_NAMES } from "../../../../app/constants.js";

const placeholders = {
  [TEXT_FIELD_NAMES.USER_NAME]: "Username",
  [TEXT_FIELD_NAMES.PASSWORD]: "Мінімум 8 символів",
  [TEXT_FIELD_NAMES.EMAIL]: "Username@gmail.com",
  [TEXT_FIELD_NAMES.EMAIL_CODE]: "Код має містити 6 цифр",
  [TEXT_FIELD_NAMES.CONFIRM_PASSWORD]: "Підтвердіть пароль",
};

const TextFields = ({ name }) => {
  const isPassword = name === TEXT_FIELD_NAMES.PASSWORD;
  const isConfirmPassword = name === TEXT_FIELD_NAMES.CONFIRM_PASSWORD;
  const [isVisible, setIsVisible] = useState(false);

  const toggleVisibility = () => {
    setIsVisible((prev) => !prev);
  };
  const determineInputType = () => {
    if (isPassword || isConfirmPassword) {
      if (!isVisible) return "password";
    }
    return "text";
  };

  return (
    <Grid
      container
      display="flex"
      flexDirection="column"
      sx={{ marginBottom: "31px", color: palette.grey["300"] }}
      className="text-fields__container"
    >
      <Grid
        item
        display="flex"
        justifyContent="flex-start"
        sx={{ margin: "0 0 8px 25px" }}
      >
        <Typography sx={{ ...typography.caption, textTransform: "uppercase" }}>
          {name}
        </Typography>
      </Grid>
      <TextField
        id="outlined-basic"
        sx={{ margin: "0 25px" }}
        variant="outlined"
        type={determineInputType()}
        placeholder={placeholders[name]}
      />

      {(isPassword || isConfirmPassword) && (
        <Grid item onClick={toggleVisibility}>
          {!isVisible ? (
            <VisibilityOffIcon
              sx={{
                position: "absolute",
                top: "38px",
                right: "41px",
                cursor: "pointer",
              }}
            />
          ) : (
            <VisibilityIcon
              sx={{
                position: "absolute",
                top: "38px",
                right: "41px",
                cursor: "pointer",
              }}
            />
          )}
        </Grid>
      )}
    </Grid>
  );
};
export default TextFields;
