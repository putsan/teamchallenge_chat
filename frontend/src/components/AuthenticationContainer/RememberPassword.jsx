import { Link } from "react-router-dom";
import { Typography } from "@mui/material";
import typography from "../../theme/typography.js";
import palette from "../../theme/palette.js";

const RememberPassword = () => {
  return (
    <Typography
      sx={{
        ...typography.caption,
        color: palette.midnight,
        marginBottom: "31px",
        textDecoration: "underline",
      }}
    >
      <Link to="/" style={{ color: palette.midnight }}>
        Я не пам&apos;ятаю свій пароль!
      </Link>
    </Typography>
  );
};
export default RememberPassword;
