import { Grid, IconButton, Typography } from "@mui/material";
import KeyboardArrowRightIcon from "@mui/icons-material/KeyboardArrowRight";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import { useState } from "react";
import LanguageIcon from "@mui/icons-material/Language";
import FormatPaintIcon from "@mui/icons-material/FormatPaint";
import LockIcon from "@mui/icons-material/Lock";
import typography from "../../theme/typography.js";
import palette from "../../theme/palette.js";
import { ICON_STYLES } from "../../app/constants.js";

const iconStyles = {
  default: {
    width: "24px",
    height: "24px",
    color: "white",
    padding: "3px",
    borderRadius: "5px",
  },
  language: {
    backgroundColor: palette.primary.main,
  },
  theme: {
    backgroundColor: palette.secondary.main,
  },
  info: {
    backgroundColor: palette.grey["100"],
  },
};
const SettingsItem = ({ icon, title }) => {
  const [isArrowRight, setIsArrowRight] = useState(true);

  const onIconClick = () => {
    setIsArrowRight((prevIsArrowRight) => !prevIsArrowRight);
  };

  let IconComponent;
  switch (icon) {
    case ICON_STYLES.LANGUAGE:
      IconComponent = LanguageIcon;
      break;
    case ICON_STYLES.THEME:
      IconComponent = FormatPaintIcon;
      break;
    case ICON_STYLES.INFO:
      IconComponent = LockIcon;
      break;
    default:
      IconComponent = LanguageIcon;
  }
  return (
    <Grid
      container
      justifyContent="start"
      alignItems="center"
      sx={{ backgroundColor: palette.grey["50"], padding: "7px 7px 7px 20px" }}
    >
      <IconComponent sx={{ ...iconStyles.default, ...iconStyles[icon] }} />
      <Typography
        sx={{
          marginLeft: "16px",
          ...typography.body2,
        }}
      >
        {title}
      </Typography>
      <IconButton sx={{ marginLeft: "auto" }} onClick={onIconClick}>
        {isArrowRight ? <KeyboardArrowRightIcon /> : <KeyboardArrowDownIcon />}
      </IconButton>
    </Grid>
  );
};
export default SettingsItem;
