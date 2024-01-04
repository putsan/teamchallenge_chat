import SettingsOutlinedIcon from "@mui/icons-material/SettingsOutlined";
import { useNavigate } from "react-router-dom";
import { IconButton } from "@mui/material";
import palette from "../../theme/palette.js";

const SetingsButton = () => {
  const navigate = useNavigate();

  const handleOpen = () => {
    navigate("/settings");
  };

  return (
    <div>
      <IconButton onClick={handleOpen} sx={{ color: palette.midnight }}>
        <SettingsOutlinedIcon />
      </IconButton>
    </div>
  );
};
export default SetingsButton;
