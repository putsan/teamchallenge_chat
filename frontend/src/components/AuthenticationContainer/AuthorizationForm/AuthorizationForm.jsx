import { Grid } from "@mui/material";
import { Form, Formik } from "formik";
import * as Yup from "yup";
import palette from "../../../theme/palette.js";
import SubmitFormButton from "../SubmitFormButton.jsx";
import RememberPassword from "../RememberPassword.jsx";
import { authAPI } from "../../../app/api/auth.api.js";
import CustomInputField from "../CustomisedInputs/CustomInputField.jsx";

const AuthorizationForm = () => {
  const AuthorizationSchema = () => {
    return Yup.object().shape({
      email: Yup.string()
        .email("Некоректна електронна пошта")
        .required("Обовʼязкове поле"),
      password: Yup.string()
        .min(8, "Мінімальна довжина пароля - 8 символів")
        .max(15, "Максимальна довжина пароля - 15 символів")
        .required("Обовʼязкове поле"),
    });
  };

  const handleFormSubmit = async (values, { setSubmitting }) => {
    console.log(values);
    try {
      // Выполнение запроса к серверу с использованием данных формы
      const response = await authAPI.login(values);

      // Обработка ответа от сервера, если это необходимо
      console.log(response);

      // Далее можете добавить свою логику обработки успешного запроса
    } catch (error) {
      // Обработка ошибок при выполнении запроса
      console.error("Error during login:", error);
    } finally {
      // В любом случае, снимаем флаг isSubmitting после завершения запроса
      setSubmitting(false);
    }
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
            email: "",
            password: "",
          }}
          validationSchema={AuthorizationSchema}
          onSubmit={handleFormSubmit}
        >
          {({ isSubmitting, isValid }) => (
            <Form>
              <CustomInputField
                name="email"
                placeholder="Електронна пошта"
                label="Email"
              />

              <CustomInputField
                name="password"
                type="password"
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
