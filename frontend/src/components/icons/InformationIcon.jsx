import InfoIcon from "@mui/icons-material/Info";
import palette from "../../theme/palette.js";
import BaseIcon from "./BaseIcon.jsx";

const InformationIcon = () => {
  const params = {
    color: palette.secondary.main,
    borderRadius: "50%",
    width: "43px",
    height: "43px",
  };

  return <BaseIcon params={params} name={InfoIcon} />;
};
export default InformationIcon;
