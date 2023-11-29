import { useLocation, Link } from "react-router-dom";
import { Button, Grid, TextField, Typography } from "@mui/material";
import GoogleIcon from "@mui/icons-material/Google";
import typography from "../theme/typography.js";
import palette from "../theme/palette.js";

function Authentication() {
  const location = useLocation();
  const { state } = location;
  // debugger;
  const isItRegistrationScreen = state && state.stage === "registration";

  return (
    <Grid
      container
      sx={{ display: "flex", flexDirection: "column", paddingTop: "55px" }}
    >
      <Typography
        sx={{
          ...typography.h1Bold,
          color: palette.primary.main,
          paddingBottom: "14px",
        }}
      >
        LDIS
      </Typography>
      <Typography sx={{ ...typography.h4, color: palette.midnight }}>
        Твоя платформа для вільного спілкування!
      </Typography>
      <Grid container>
        <Typography sx={{ ...typography.caption, textTransform: "uppercase" }}>
          Ім’я користувача
        </Typography>
        <TextField
          id="outlined-basic"
          sx={{ margin: "0 25px" }}
          variant="outlined"
        />
      </Grid>

      <TextField
        id="outlined-basic"
        sx={{ margin: "25px" }}
        variant="outlined"
        type="password"
      />

      {/* <TextField label="Пароль" variant="standard" type="password" /> */}

      {isItRegistrationScreen && (
        <div style={{ margin: "25px" }}>
          <TextField
            label="Підтвердіть пароль"
            variant="standard"
            type="password"
          />
        </div>
      )}

      <div>
        <Link to="/">
          <Button variant="contained" sx={{ marginRight: "10px" }}>
            {(isItRegistrationScreen && "Продовжити") || "Вхід"}
          </Button>
        </Link>

        <Link to="/">
          <Button variant="contained">
            <GoogleIcon />
          </Button>
        </Link>
      </div>

      <br />
      {(isItRegistrationScreen && <RegistrationFooter />) || <LoginFooter />}
    </Grid>
  );
}

export default Authentication;

function RegistrationFooter() {
  return (
    <>
      <p>Вже є аккаунт?</p>
      <Link to="/auth">
        <p style={{ textDecoration: "underline" }}> Вхід </p>
      </Link>
      <br />
      <Link to="/">
        <Button variant="contained" sx={{ fontSize: "16px" }}>
          Назад
        </Button>
      </Link>
    </>
  );
}

function LoginFooter() {
  return (
    <>
      <p>Перший раз? ?</p>

      <Link to="/auth" state={{ stage: "registration" }}>
        <p style={{ textDecoration: "underline" }}> Зареєстуватись </p>
      </Link>

      <br />
      <Link to="/">
        <Button variant="contained" sx={{ fontSize: "16px" }}>
          Назад
        </Button>
      </Link>
    </>
  );
}
