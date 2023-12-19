import { Box, Typography } from "@mui/material";
import typography from "../../theme/typography.js";

const LobbyHeaderGreetings = ({ username = "username" }) => {
  return (
    <Box sx={{ margin: "7px 39px 32px 39px" }}>
      <Typography sx={{ ...typography.body1, fontWeight: "700" }}>
        {" "}
        Привіт, {username}!
      </Typography>{" "}
      <Typography sx={{ ...typography.body1 }}>
        {" "}
        Про що хочеш поговорити сьогодні?:){" "}
      </Typography>
    </Box>
  );
};

export default LobbyHeaderGreetings;
