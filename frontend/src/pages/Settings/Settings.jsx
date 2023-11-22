import { Grid, IconButton, Typography } from "@mui/material";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import Avatar from "@mui/material/Avatar";
import { useNavigate } from "react-router-dom";
import palette from "../../theme/palette.js";
import typography from "../../theme/typography.js";
import "./Settings.scss";
import SettingsItem from "../../components/SettingsComponents/SettingsItem.jsx";
import { ICON_STYLES } from "../../app/constants.js";

const Settings = () => {
  const navigate = useNavigate();
  // дані для відображення(тест)
  const languages = ["Українська", "English"];
  const themes = ["Світла", "Темна"];

  const handleGoBack = () => {
    navigate(-1);
  };
  return (
    <div>
      <Grid
        container
        justifyContent="start"
        alignItems="center"
        sx={{ marginBottom: "27px" }}
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
          Налаштування
        </Typography>
      </Grid>

      <Grid
        container
        justifyContent="start"
        alignItems="center"
        sx={{ marginTop: "13px", marginBottom: "13px", paddingLeft: "15px" }}
      >
        <Grid item>
          <Avatar alt="userName" sx={{ width: 66, height: 66 }} />
        </Grid>
        <Grid item sx={{ marginLeft: "15px" }}>
          <div className="settings-profile-name">
            <Typography variant="h6" sx={{ flex: 1, ...typography.body1 }}>
              Alina
            </Typography>
            <Typography variant="body2" sx={{ color: palette.grey[250] }}>
              @jacob_d
            </Typography>
          </div>
        </Grid>
      </Grid>
      <div className="separator" />
      <SettingsItem
        title="Мова інтерфейсу"
        icon={ICON_STYLES.LANGUAGE}
        props={languages}
      />
      <div className="separator" style={{ marginLeft: "64px" }} />
      <SettingsItem title="Тема" icon={ICON_STYLES.THEME} props={themes} />
      <div style={{ marginTop: "22px" }}>
        <SettingsItem title="Правила спільноти" icon={ICON_STYLES.INFO} />
      </div>
    </div>
  );
};
export default Settings;
