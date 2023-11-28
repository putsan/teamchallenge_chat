import { Grid } from "@mui/material";
import "./SettingsModal.scss";
import palette from "../../../theme/palette.js";

const SettingsModal = ({ props }) => {
  if (!props) {
    return undefined;
  }

  return (
    <Grid className="settings-item-modal">
      {props &&
        props.map((el, i, arr) => (
          <Grid
            key={el}
            item
            className="settings-item-modal-language"
            style={
              i !== arr.length - 1
                ? { borderBottom: "1px solid #DDE2E580" }
                : {}
            }
          >
            {el === "Світла" ? (
              <span style={{ color: palette.secondary.main }}>{el}</span>
            ) : (
              el
            )}
          </Grid>
        ))}
    </Grid>
  );
};
export default SettingsModal;
