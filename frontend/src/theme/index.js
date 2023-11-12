import { createTheme } from "@mui/material/styles";
import palette from "./palette";
import typography from "./typography";
import componentsOverride from "./components";

const theme = createTheme({
  palette,
  typography,
  components: componentsOverride,
});

export default theme;
