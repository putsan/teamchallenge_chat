import "./LobbyHeader.scss";
import { Box, IconButton, Typography } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import ChatBubbleOutlineIcon from "@mui/icons-material/ChatBubbleOutline";
import SetingsButton from "../SettingsComponents/SetingsButton.jsx";
import palette from "../../theme/palette";
import typography from "../../theme/typography.js";

const LobbyHeader = () => {
  return (
    <Box className="lobby__header">
      <Box sx={{ display: "flex", flexDirection: "row", alignItems: "center" }}>
        <Box
          sx={{
            backgroundColor: palette.secondary.main,
            marginRight: "9px",
          }}
          className="lobby__header__circle"
        >
          <Typography
            sx={{ color: palette.primary.main, ...typography.h6Bold }}
          >
            LDIS
          </Typography>
        </Box>
        <Typography sx={{ ...typography.subtitle, color: palette.midnight }}>
          Головна
        </Typography>
      </Box>
      <Box
        sx={{
          display: "flex",
          flexDirection: "row",
          alignItems: "center",
          color: palette.midnight,
        }}
      >
        <IconButton sx={{ color: palette.midnight }}>
          <SearchIcon />
        </IconButton>
        <IconButton sx={{ color: palette.midnight }}>
          <ChatBubbleOutlineIcon />
        </IconButton>
        <SetingsButton />
      </Box>
    </Box>
  );
};

export default LobbyHeader;
