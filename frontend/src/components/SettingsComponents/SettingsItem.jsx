import { Grid, IconButton, Typography } from "@mui/material";
import KeyboardArrowRightIcon from "@mui/icons-material/KeyboardArrowRight";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import { useState } from "react";
import typography from "../../theme/typography.js";
import palette from "../../theme/palette.js";
import IconFactory from "../icons/IconFactory.jsx";
import SettingsModal from "./SettingsModal/SettingsModal.jsx";

const SettingsItem = ({ icon, title, props }) => {
  const [isArrowRight, setIsArrowRight] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);

  const onIconClick = () => {
    setIsArrowRight((prevIsArrowRight) => !prevIsArrowRight);
    setIsModalOpen((prevIsModalOpen) => !prevIsModalOpen);
  };

  return (
    <Grid
      container
      justifyContent="space-between"
      alignItems="center"
      sx={{ backgroundColor: palette.grey["50"], padding: "7px 7px 7px 20px" }}
    >
      <Grid sx={{ display: "flex", alignItems: "center" }}>
        <IconFactory icon={icon} />
        <Typography
          sx={{
            marginLeft: "16px",
            ...typography.body2,
          }}
        >
          {title}
        </Typography>
      </Grid>
      <Grid container sx={{ width: "40px", position: "relative" }}>
        <IconButton
          onClick={onIconClick}
          sx={{
            color: palette.grey["350"],
            "&:hover": {
              backgroundColor: "transparent",
            },
          }}
        >
          {isArrowRight ? (
            <KeyboardArrowRightIcon />
          ) : (
            <KeyboardArrowDownIcon />
          )}
        </IconButton>
        {isModalOpen && <SettingsModal props={props} />}
      </Grid>
    </Grid>
  );
};
export default SettingsItem;
