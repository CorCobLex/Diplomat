import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import Buefy from "buefy";
import "buefy/dist/buefy.css";
import AuthService from "./services/AuthService";
import axios from "axios";

Vue.use(Buefy);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  Buefy,

  render: function (h) {
    return h(App);
  },
}).$mount("#app");

const authService = AuthService;

axios.interceptors.request.use((request) => {
  const token = authService.getAccessToken();
  if (token) {
    request.headers["Authorization"] = `Bearer ${token}`;
  }
  return request;
});

function createAxiosResponseInterceptor() {
  const interceptor = axios.interceptors.response.use(
    (response) => response,
    (error) => {
      const status = error.response ? error.response.status : null;

      if (status !== 401) {
        return Promise.reject(error);
      }

      axios.interceptors.response.eject(interceptor);

      authService
        .renewToken()
        .then(() => {
          const token = authService.getAccessToken();
          if (token) {
            error.response.config.headers["Authorization"] = `Bearer ${token}`;
            return axios(error.response.config);
          }
        })
        .catch((error) => {
          localStorage.clear();
          router.push("/authorizate");
          return Promise.reject(error);
        })
        .finally(createAxiosResponseInterceptor);
    }
  );
}

createAxiosResponseInterceptor();
