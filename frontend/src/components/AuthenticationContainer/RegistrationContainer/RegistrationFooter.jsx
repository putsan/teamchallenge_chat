import { Grid, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import palette from "../../../theme/palette.js";

const RegistrationFooter = () => {
  return (
    <Grid display="flex" justifyContent="center">
      <Typography sx={{ marginRight: "7px" }}>Перший раз? </Typography>

      <Link to="/auth" state={{ stage: "registration" }}>
        <Typography
          sx={{ textDecoration: "underline", color: palette.primary.main }}
        >
          {" "}
          Зареєстpуватись{" "}
        </Typography>
      </Link>
    </Grid>
  );
};
export default RegistrationFooter;
