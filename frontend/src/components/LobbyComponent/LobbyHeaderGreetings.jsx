import { Box, Typography } from "@mui/material";
import typography from "../../theme/typography.js";
import { LOBBY_TITLES } from "../../app/constants.js";

const LobbyHeaderGreetings = ({ username = "username" }) => {
  return (
    <Box sx={{ margin: "7px 39px 32px 39px" }}>
      <Typography sx={{ ...typography.body1, fontWeight: "700" }}>
        Привіт, {username}!
      </Typography>
      <Typography sx={{ ...typography.body1 }}>
        {LOBBY_TITLES.MAIN_QUESTION}
      </Typography>
    </Box>
  );
};

export default LobbyHeaderGreetings;
