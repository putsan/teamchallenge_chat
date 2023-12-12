import { useLocation } from "react-router-dom";
import { Grid } from "@mui/material";
import "./Authentication.scss";
import Ellipse from "../../components/Elipse.jsx";
import { SETTINGS_ITEM_STYLES } from "../../app/constants.js";
import IconFactory from "../../components/icons/IconFactory.jsx";
import RegistrationForm from "../../components/AuthenticationContainer/RegistrationContainer/RegistrationForm.jsx";
import AuthorizationForm from "../../components/AuthenticationContainer/AuthorizationContainer/AuthorizationForm.jsx";
import AuthenticationTitle from "../../components/AuthenticationContainer/AuthenticationTitle.jsx";

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
      <AuthenticationTitle />
      <div className="auth__form">
        {isRegistrationScreen ? <RegistrationForm /> : <AuthorizationForm />}
      </div>

      <Grid
        position="absolute"
        sx={{ left: "-27px", bottom: "104px", transform: "scaleX(-1)" }}
      >
        <Ellipse />
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
