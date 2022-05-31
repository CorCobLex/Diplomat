import axios from "axios";

export default {
  async login(login, password) {
    return await axios.post("/api/Authorization/login", {
      userName: login,
      password: password,
    });
  },

  getAccessToken() {
    return sessionStorage.getItem("accessToken");
  },

  async renewToken() {
    const token = sessionStorage.getItem("refreshToken");

    return await axios.post("/api/Authorization/refresh", {
      refreshToken: token,
    });
  },
};
