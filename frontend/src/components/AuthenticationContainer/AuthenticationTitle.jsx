import { Grid, Typography } from "@mui/material";
import typography from "../../theme/typography.js";
import palette from "../../theme/palette.js";
import Ellipse from "../Elipse.jsx";
import { AUTH_SUBTITLE, MAIN_TITLE } from "../../app/constants.js";

const AuthenticationTitle = () => {
  return (
    <>
      <Typography
        sx={{
          ...typography.h1Bold,
          color: palette.primary.main,
          paddingBottom: "14px",
          position: "relative",
        }}
      >
        {MAIN_TITLE}
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
        {AUTH_SUBTITLE}
      </Typography>
    </>
  );
};
export default AuthenticationTitle;
