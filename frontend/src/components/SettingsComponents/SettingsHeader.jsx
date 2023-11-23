import { Grid, IconButton, Typography } from "@mui/material";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import { useNavigate } from "react-router-dom";
import MoreHorizOutlinedIcon from "@mui/icons-material/MoreHorizOutlined";
import palette from "../../theme/palette.js";
import typography from "../../theme/typography.js";

const SettingsHeader = ({ title, dots }) => {
  const navigate = useNavigate();
  const handleGoBack = () => {
    navigate(-1);
  };

  return (
    <Grid
      container
      justifyContent="start"
      alignItems="center"
      sx={{ paddingBottom: "27px", paddingTop: " 23px" }}
    >
      <IconButton
        edge="start"
        aria-label="back"
        onClick={handleGoBack}
        sx={{ marginLeft: "26px" }}
      >
        <ArrowBackIcon sx={{ color: palette.midnight }} />
      </IconButton>
      <Typography
        sx={{
          flex: 1,
          color: palette.primary.main,
          marginLeft: "-20px",
          ...typography.body1,
        }}
      >
        {title}
      </Typography>
      {dots && (
        <IconButton sx={{ marginRight: "18px" }}>
          <MoreHorizOutlinedIcon
            sx={{ color: palette.midnight, height: "32px", width: "32px" }}
          />
        </IconButton>
      )}
    </Grid>
  );
};
export default SettingsHeader;
