<template>
  <div class="columns">
    <div class="column"></div>
    <form class="column is-four doda" onsubmit="return false">
      <b-notification :closable="false">
        Введите логин и пароль
        <b-loading :is-full-page="isFullPage" v-model="isLoading"></b-loading>
      </b-notification>

      <b-field label="Login" horizontal>
        <b-input v-model="login" maxlength="30" />
      </b-field>
      <b-field label="Password" horizontal>
        <b-input type="password" v-model="password" password-reveal> </b-input>
      </b-field>
      <button type="submit" @click="authorization" style="display: none">
        Авторизация
      </button>
      <b-button type="is-info" @click="authorization" expanded>
        Авторизация
      </b-button>
    </form>
    <div class="column"></div>
  </div>
</template>

<script>
import AuthService from "../services/AuthService";

export default {
  data: function () {
    return {
      login: "",
      password: "",
    };
  },

  methods: {
    async authorization() {
      this.$store.state.isBusy = true;
      var result = await AuthService.login(this.login, this.password);
      if (result.data.isSuccessful) {
        sessionStorage.setItem(
          "accessToken",
          result.data.data.accessToken.token
        );
        sessionStorage.setItem(
          "refreshToken",
          result.data.data.refreshToken.token
        );
        this.$router.push("/");
      } else {
        this.$store.state.isBusy = false;
      }
    },
  },
};
</script>

<style>
.doda {
  margin-top: 20%;
}
</style>
