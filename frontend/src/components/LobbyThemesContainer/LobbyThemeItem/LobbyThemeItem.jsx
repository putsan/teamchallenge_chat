import "./LobbyThemeItem.scss";
import { Box, Typography } from "@mui/material";
import typography from "../../../theme/typography.js";

const LobbyThemeItem = ({ item }) => {
  const { url, title } = item;
  return (
    <Box className="lobby-theme__item">
      <img className="lobby-theme__img" src={url} alt="" />
      <Box sx={{ padding: "4px", maxWidth: "100%" }}>
        <Typography
          className="lobby-theme__title"
          sx={{ ...typography.caption }}
        >
          {title}
        </Typography>
      </Box>
    </Box>
  );
};
export default LobbyThemeItem;
