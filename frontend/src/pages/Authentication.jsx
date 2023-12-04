import { Link, useLocation } from "react-router-dom";
import { Button, Grid, Typography } from "@mui/material";
import GoogleIcon from "@mui/icons-material/Google";
import ArrowForwardIcon from "@mui/icons-material/ArrowForward";
import typography from "../theme/typography.js";
import palette from "../theme/palette.js";
import "./Authentication.scss";
import Ellipse from "../components/Elipse.jsx";
import { SETTINGS_ITEM_STYLES } from "../app/constants.js";
import RegistrationFooter from "../components/AuthenticationContainer/RegistrationContainer/RegistrationFooter.jsx";
import LoginFooter from "../components/AuthenticationContainer/LoginContainer/LoginFooter.jsx";
import IconFactory from "../components/icons/IconFactory.jsx";
import TextFieldsContainer from "../components/AuthenticationContainer/TextFieldContainer/TextFieldsContainer.jsx";

function Authentication() {
  const location = useLocation();
  const { state } = location;

  const isRegistrationScreen = state && state.stage === "registration";

  return (
    <Grid
      container
      display="flex"
      flexDirection="column"
      alignItems="center"
      wrap="nowrap"
      sx={{ paddingTop: "55px" }}
      position="relative"
    >
      <Typography
        sx={{
          ...typography.h1Bold,
          color: palette.primary.main,
          paddingBottom: "14px",
          position: "relative",
        }}
      >
        LDIS
      </Typography>

      <Grid position="absolute" sx={{ right: "0", top: "36px" }}>
        <Ellipse />
      </Grid>
      <Typography
        sx={{
          ...typography.h4,
          color: palette.midnight,
          margin: "0 20px 31px 20px ",
        }}
      >
        Твоя платформа для вільного спілкування!
      </Typography>

      <TextFieldsContainer isRegistrationScreen={isRegistrationScreen} />

      <Typography
        sx={{
          ...typography.caption,
          color: palette.midnight,
          marginBottom: "31px",
          textDecoration: "underline",
        }}
      >
        <Link to="/auth" style={{ color: palette.midnight }}>
          Я не пам&apos;ятаю свій пароль!
        </Link>
      </Typography>

      <Grid container flexDirection="column" alignItems="center">
        <Grid item className="auth-button__container">
          <Button variant="contained" size="small" sx={{ width: "100%" }}>
            {(isRegistrationScreen && "Продовжити") || "Вхід"}
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
            className="auth__separator"
            style={{ backgroundColor: palette.midnight }}
          />
          <Typography sx={{ margin: "0 28px", ...typography.caption }}>
            АБО
          </Typography>
          <div
            className="auth__separator"
            style={{ backgroundColor: palette.midnight }}
          />
        </Grid>

        <Grid item className="auth-button__container">
          <Button variant="outlined" size="small" sx={{ width: "100%" }}>
            <Typography sx={{ ...typography.body1, marginRight: "10px" }}>
              Продовжити з
            </Typography>
            <GoogleIcon />
          </Button>
        </Grid>
      </Grid>
      <Grid
        position="absolute"
        sx={{ left: "-27px", bottom: "104px", transform: "scaleX(-1)" }}
      >
        <Ellipse />
      </Grid>
      <Grid sx={{ margin: "40px 0" }}>
        {(isRegistrationScreen && <RegistrationFooter />) || <LoginFooter />}
      </Grid>
      <Grid
        container
        flexDirection="row-reverse"
        sx={{ margin: "13px 60px 13px 0" }}
      >
        <IconFactory itemData={SETTINGS_ITEM_STYLES.INFO} />
      </Grid>
    </Grid>
  );
}

export default Authentication;
