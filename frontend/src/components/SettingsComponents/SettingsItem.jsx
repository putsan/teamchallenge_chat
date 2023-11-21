import { Grid, IconButton, Typography } from "@mui/material";
import KeyboardArrowRightIcon from "@mui/icons-material/KeyboardArrowRight";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import { useState } from "react";
import typography from "../../theme/typography.js";
import palette from "../../theme/palette.js";
import IconFactory from "../icons/IconFactory.jsx";

const SettingsItem = ({ icon, title }) => {
  const [isArrowRight, setIsArrowRight] = useState(true);

  const onIconClick = () => {
    setIsArrowRight((prevIsArrowRight) => !prevIsArrowRight);
  };
  return (
    <Grid
      container
      justifyContent="start"
      alignItems="center"
      sx={{ backgroundColor: palette.grey["50"], padding: "7px 7px 7px 20px" }}
    >
      <IconFactory icon={icon} />
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
