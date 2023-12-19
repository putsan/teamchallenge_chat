import { Box, Button, Typography } from "@mui/material";
import PeopleOutlineOutlinedIcon from "@mui/icons-material/PeopleOutlineOutlined";
import AddOutlinedIcon from "@mui/icons-material/AddOutlined";
import typography from "../../theme/typography.js";
import "./LobbyHeaderButtons.scss";

const LobbyHeaderButtons = ({ isRegistered = true }) => {
  return (
    <Box className="lobby-header-buttons">
      <Box className="lobby-header-buttons__container">
        <Button variant="contained" sx={{ marginBottom: "10px" }}>
          <Typography
            sx={{ ...typography.body1, paddingRight: "7px", fontWeight: "500" }}
          >
            Почати рандомний чат
          </Typography>{" "}
          <PeopleOutlineOutlinedIcon />
        </Button>
        {isRegistered && (
          <Button variant="contained">
            <Typography
              sx={{
                ...typography.body1,
                paddingRight: "7px",
                fontWeight: "500",
              }}
            >
              Створити чат
            </Typography>{" "}
            <AddOutlinedIcon />
          </Button>
        )}
      </Box>
    </Box>
  );
};
export default LobbyHeaderButtons;
