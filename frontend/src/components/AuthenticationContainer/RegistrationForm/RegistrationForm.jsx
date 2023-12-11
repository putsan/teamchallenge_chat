import { Grid } from "@mui/material";
import { Form, Formik } from "formik";
import * as Yup from "yup";
import palette from "../../../theme/palette.js";
import SubmitFormButton from "../SubmitFormButton.jsx";
import RememberPassword from "../RememberPassword.jsx";
import CustomInputField from "../CustomisedInputs/CustomInputField.jsx";

// продумати логіку використання

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
              <CustomInputField
                name="username"
                placeholder="Створи своє унікальне ім’я"
                label="Імʼя користувача"
              />
              <CustomInputField
                name="email"
                placeholder="Username@gmail.com"
                label="Електронна пошта"
              />
              <CustomInputField
                type="password"
                name="password"
                placeholder="Мінімум 8 символів"
                label="Пароль"
              />
              <CustomInputField
                type="password"
                name="confirmPassword"
                placeholder="Мінімум 8 символів"
                label="Підтвердіть пароль"
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

export default RegistrationForm;
