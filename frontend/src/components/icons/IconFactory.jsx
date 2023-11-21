import { ICON_STYLES } from "../../app/constants.js";
import LangIcon from "./LangIcon.jsx";
import ThemeIcon from "./ThemeIcon.jsx";
import InfoIcon from "./InfoIcon.jsx";

const IconFactory = ({ icon }) => {
  let IconComponent;

  switch (icon) {
    case ICON_STYLES.LANGUAGE:
      IconComponent = LangIcon;
      break;
    case ICON_STYLES.THEME:
      IconComponent = ThemeIcon;
      break;
    case ICON_STYLES.INFO:
      IconComponent = InfoIcon;
      break;
    default:
      IconComponent = " ";
  }

  return <IconComponent />;
};
export default IconFactory;
