import { Typography } from "@mui/material";
import palette from "../../theme/palette.js";
import typography from "../../theme/typography.js";

const ErrorFeedback = ({ errors, touched }) => {
  return (
    <div
      style={{
        display: "flex",
        minHeight: "2em",
        paddingTop: "4px",
        color: palette.error.main,
      }}
    >
      {errors && touched && (
        <Typography sx={{ ...typography.caption }}>{errors}</Typography>
      )}
    </div>
  );
};
export default ErrorFeedback;
