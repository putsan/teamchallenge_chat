import { Grid, Typography } from "@mui/material";
import Avatar from "@mui/material/Avatar";
import palette from "../../theme/palette.js";
import typography from "../../theme/typography.js";
import "./Settings.scss";
import SettingsItem from "../../components/SettingsComponents/SettingsItem.jsx";
import { ICON_STYLES } from "../../app/constants.js";
import SettingsFooter from "../../components/SettingsComponents/SettingsFooter/SettingsFooter.jsx";
import SettingsHeader from "../../components/SettingsComponents/SettingsHeader.jsx";

const Settings = ({ isAuthUser = true }) => {
  // дані для відображення(тест)
  const languages = ["Українська", "English"];
  const themes = ["Світла", "Темна"];

  return (
    <Grid
      container
      direction="column"
      justifyContent="space-between"
      height="100vh"
      padding="8px 0"
    >
      <div>
        <SettingsHeader title="Налаштування" dots={false} />

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

        <Grid>
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
        </Grid>
      </div>

      <div>
        <SettingsFooter isAuthUser={isAuthUser} />
      </div>
    </Grid>
  );
};
export default Settings;
