import LockIcon from "@mui/icons-material/Lock";
import palette from "../../theme/palette.js";
import BaseIcon from "./BaseIcon.jsx";

const RulesIcon = () => {
  const backgroundColor = { backgroundColor: palette.grey["100"] };

  return <BaseIcon params={backgroundColor} name={LockIcon} />;
};
export default RulesIcon;
