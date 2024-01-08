import { Grid } from "@mui/material";
import { Form, Formik } from "formik";
import * as Yup from "yup";
import palette from "../../../theme/palette.js";
import SubmitFormButton from "../SubmitFormButton.jsx";
import RememberPassword from "../RememberPassword.jsx";
import CustomInputField from "../CustomisedInputs/CustomInputField.jsx";
import {
  CONFIRM_PASSWORD_INPUT_FIELD,
  EMAIL_INPUT_FIELD,
  PASSWORD_INPUT_FIELD,
  USERNAME_INPUT_FIELD,
} from "../../../app/constants.js";
import AuthorizationFooter from "../AuthorizationContainer/AuthorizationFooter.jsx";

const RegistrationForm = () => {
  const RegistrationSchema = () => {
    return Yup.object().shape({
      username: Yup.string()
        .min(2, "Мінімальна довжина імені - 2 символи")
        .max(15, "Максимальна довжина імені - 15 символів")
        .required("Обовʼязкове поле"),
      password: Yup.string()
        .min(8, "Мінімальна довжина пароля - 8 символів")
        .max(15, "Максимальна довжина пароля - 15 символів")
        .required("Обовʼязкове поле"),
      email: Yup.string()
        .email("Некоректна електронна пошта")
        .required("Обовʼязкове поле"),
      confirmPassword: Yup.string()
        .oneOf([Yup.ref("password"), null], "Паролі мають співпадати")
        .required("Обовʼязкове поле"),
    });
  };

  return (
    <Grid
      container
      display="flex"
      flexDirection="column"
      alignItems="center"
      sx={{ color: palette.grey["300"] }}
    >
      <Grid
        container
        display="flex"
        flexDirection="column"
        sx={{ marginBottom: "31px" }}
      >
        <Formik
          initialValues={{
            username: "",
            password: "",
            email: "",
            confirmPassword: "",
          }}
          validationSchema={RegistrationSchema}
          onSubmit={(values, { setSubmitting }) => {
            setTimeout(() => {
              alert(JSON.stringify(values, null, 2));
              setSubmitting(false);
            }, 400);
          }}
        >
          {({ isSubmitting, isValid }) => (
            <Form>
              <CustomInputField fieldItem={USERNAME_INPUT_FIELD} />
              <CustomInputField fieldItem={PASSWORD_INPUT_FIELD} />
              <CustomInputField fieldItem={EMAIL_INPUT_FIELD} />
              <CustomInputField fieldItem={CONFIRM_PASSWORD_INPUT_FIELD} />
              <RememberPassword />
              <SubmitFormButton isSubmitting={isSubmitting} isValid={isValid} />
              <Grid sx={{ margin: "40px 0" }}>
                <AuthorizationFooter />
              </Grid>
            </Form>
          )}
        </Formik>
      </Grid>
    </Grid>
  );
};

export default RegistrationForm;
