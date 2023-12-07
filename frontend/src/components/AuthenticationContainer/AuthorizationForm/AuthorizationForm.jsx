import { Grid } from "@mui/material";
import { Form, Formik } from "formik";
import * as Yup from "yup";
import palette from "../../../theme/palette.js";
import SubmitFormButton from "../SubmitFormButton.jsx";
import AuthInputBlock from "../CustomisedInputs/AuthInputBlock.jsx";
import AuthInputPasswordBlock from "../CustomisedInputs/AuthInputPasswordBlock.jsx";
import RememberPassword from "../RememberPassword.jsx";

const AuthorizationForm = () => {
  const AuthorizationSchema = () => {
    return Yup.object().shape({
      username: Yup.string()
        .min(2, "Мінімальна довжина імені - 2 символи")
        .max(15, "Максимальна довжина імені - 15 символів")
        .required("Обовʼязкове поле"),
      password: Yup.string()
        .min(8, "Мінімальна довжина пароля - 8 символів")
        .max(15, "Максимальна довжина пароля - 15 символів")
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
          }}
          validationSchema={AuthorizationSchema}
          onSubmit={(values, { setSubmitting }) => {
            setTimeout(() => {
              alert(JSON.stringify(values, null, 2));
              setSubmitting(false);
            }, 400);
          }}
        >
          {({ isSubmitting, isValid }) => (
            <Form>
              <AuthInputBlock
                name="username"
                placeholder="Імʼя користувача"
                label="Username"
              />
              <AuthInputPasswordBlock
                name="password"
                placeholder="Мінімум 8 символів"
                label="Пароль"
              />
              <RememberPassword />
              <SubmitFormButton isSubmitting={isSubmitting} isValid={isValid} />
            </Form>
          )}
        </Formik>
      </Grid>
    </Grid>
  );
};

export default AuthorizationForm;
