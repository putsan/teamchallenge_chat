import { Grid, IconButton, Typography } from "@mui/material";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import Avatar from "@mui/material/Avatar";
import { useNavigate } from "react-router-dom";
import palette from "../../theme/palette.js";
import "./Settings.scss";

const Settings = () => {
  const navigate = useNavigate();
  const handleGoBack = () => {
    navigate(-1);
  };
  return (
    <div>
      <Grid
        container
        justifyContent="start"
        alignItems="center"
        sx={{ marginLeft: "20px" }}
      >
        <IconButton edge="start" aria-label="back" onClick={handleGoBack}>
          <ArrowBackIcon style={{ color: palette.midnight }} />
        </IconButton>
        <Typography
          variant="p"
          style={{ flexGrow: 1, color: palette.primary.main }}
        >
          Налаштування
        </Typography>
      </Grid>

      <Grid
        container
        spacing={2}
        justifyContent="start"
        alignItems="center"
        sx={{ margin: "10px" }}
      >
        <Grid item>
          <Avatar alt="userName" sx={{ width: 66, height: 66 }} />
        </Grid>
        <Grid item>
          <div className="settings-profile-name">
            <Typography variant="h6">Alina</Typography>
            <Typography variant="body2" style={{ color: palette.grey[250] }}>
              @jacob_d
            </Typography>
          </div>
        </Grid>
      </Grid>
    </div>
  );
};
export default Settings;
