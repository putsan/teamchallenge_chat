import { Grid } from "@mui/material";
import TextFields from "./TextFields/TextFields.jsx";
import { TEXT_FIELD_NAMES } from "../../../app/constants.js";

const TextFieldsContainer = ({ isRegistrationScreen }) => (
  <Grid container justifyContent="center">
    {isRegistrationScreen ? (
      <>
        <TextFields name={TEXT_FIELD_NAMES.USER_NAME} />
        <TextFields name={TEXT_FIELD_NAMES.EMAIL} />
        <TextFields name={TEXT_FIELD_NAMES.PASSWORD} />
        <TextFields name={TEXT_FIELD_NAMES.CONFIRM_PASSWORD} />
      </>
    ) : (
      <>
        <TextFields name={TEXT_FIELD_NAMES.USER_NAME} />
        <TextFields name={TEXT_FIELD_NAMES.PASSWORD} />
      </>
    )}
  </Grid>
);

export default TextFieldsContainer;
