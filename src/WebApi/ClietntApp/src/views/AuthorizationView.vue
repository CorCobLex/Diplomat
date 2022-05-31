<template>
  <div class="columns">
    <div class="column"></div>
    <form class="column is-four doda" onsubmit="return false">
      <b-field label="Email" horizontal>
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
      var result = await AuthService.login(this.login, this.password);
      console.log(result);
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
