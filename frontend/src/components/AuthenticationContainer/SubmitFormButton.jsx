import { Button, Grid, Typography } from "@mui/material";
import ArrowForwardIcon from "@mui/icons-material/ArrowForward";
import GoogleIcon from "@mui/icons-material/Google";
import { useLocation } from "react-router-dom";
import palette from "../../theme/palette.js";
import typography from "../../theme/typography.js";
import "./SubmitFormButton.scss";
import { authAPI } from "../../app/api/auth.api.js";

const SubmitFormButton = ({ isValid, isSubmitting }) => {
  const location = useLocation();
  const { state } = location;
  const isRegistrationScreen = state && state.stage === "registration";

  const handleGoogleAuthClick = async () => {
    try {
      const response = await authAPI.googleAuth();
      console.log(response); // Обрабатываем ответ, если это необходимо
    } catch (error) {
      console.error("Error during Google authentication:", error);
    }
  };

  return (
    <Grid container flexDirection="column" alignItems="center">
      <Grid item className="submit-form__container">
        <Button
          variant="contained"
          size="small"
          sx={{
            width: "100%",
            "&.Mui-disabled": {
              background: "hsl(345,77%,76%)",
              color: "white",
            },
          }}
          type="submit"
          disabled={!isValid || isSubmitting}
        >
          {(isRegistrationScreen && "Зареєстуватись") || "Вхід"}
          <ArrowForwardIcon />
        </Button>
      </Grid>

      <Grid
        sx={{ margin: "6px 0", width: "100%" }}
        display="flex"
        alignItems="center"
        justifyContent="space-between"
      >
        <div
          className="submit-form__separator"
          style={{ backgroundColor: palette.midnight }}
        />
        <Typography sx={{ margin: "0 28px", ...typography.caption }}>
          АБО
        </Typography>
        <div
          className="submit-form__separator"
          style={{ backgroundColor: palette.midnight }}
        />
      </Grid>

      <Grid item className="submit-form__container">
        <Button
          variant="outlined"
          size="small"
          sx={{ width: "100%" }}
          onClick={handleGoogleAuthClick}
        >
          <Typography sx={{ ...typography.body1, marginRight: "10px" }}>
            Продовжити з
          </Typography>
          <GoogleIcon />
        </Button>
      </Grid>
    </Grid>
  );
};

export default SubmitFormButton;
