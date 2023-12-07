import { useLocation } from "react-router-dom";
import { Grid, Typography } from "@mui/material";
import typography from "../theme/typography.js";
import palette from "../theme/palette.js";
import "./Authentication.scss";
import Ellipse from "../components/Elipse.jsx";
import { SETTINGS_ITEM_STYLES } from "../app/constants.js";
import RegistrationFooter from "../components/AuthenticationContainer/RegistrationContainer/RegistrationFooter.jsx";
import LoginFooter from "../components/AuthenticationContainer/LoginContainer/LoginFooter.jsx";
import IconFactory from "../components/icons/IconFactory.jsx";
import RegistrationForm from "../components/AuthenticationContainer/RegistrationForm/RegistrationForm.jsx";
import AuthorizationForm from "../components/AuthenticationContainer/AuthorizationForm/AuthorizationForm.jsx";

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

      {isRegistrationScreen ? <RegistrationForm /> : <AuthorizationForm />}

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
