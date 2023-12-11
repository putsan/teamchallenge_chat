import axios from "axios";

export const instance = axios.create({
  baseURL: "https://localhost:7237/",
  // withCredentials: true,
});

export const authAPI = {
  googleAuth() {
    return instance.get("api/ApiRequest");
  },

  login(values) {
    return instance.post(
      `oauth/ApiAuthentification/login/${values.email},${values.password}`,
    );
  },
};
