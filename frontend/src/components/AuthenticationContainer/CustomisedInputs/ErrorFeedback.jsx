import { Typography } from "@mui/material";
import palette from "../../../theme/palette.js";
import typography from "../../../theme/typography.js";

const ErrorFeedback = ({ errors, touched }) => {
  return (
    <div
      style={{
        minHeight: "2em",
        paddingTop: "8px",
        color: palette.primary.main,
      }}
    >
      {errors && touched && (
        <Typography sx={{ ...typography.caption }}>{errors}</Typography>
      )}
    </div>
  );
};
export default ErrorFeedback;
