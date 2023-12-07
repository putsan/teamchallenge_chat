import axios from "axios";

export const instance = axios.create({
  baseURL: "https://localhost:44451",
  // withCredentials: true,
});

export const authAPI = {
  googleAuth() {
    return instance.get("oauth/ApiAuthentification");
  },
  login(values) {
    return instance.post(
      `oauth/ApiAuthentification/login/${values.email},${values.password}`,
    );
  },
};
