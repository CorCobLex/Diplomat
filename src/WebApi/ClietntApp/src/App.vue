<template>
  <div id="app">
    <nav></nav>
    <router-view />
  </div>
</template>

<script>
export default {
  data() {
    return {
      isLoading: true,
      isFullPage: true,
    };
  },

  computed: {
    loading: {
      get() {
        return this.$store.state.isBusy;
      },
    },
  },

  methods: {
    open() {
      const loadingComponent = this.$buefy.loading.open({
        container: this.isFullPage ? null : this.$refs.element.$el,
      });
      if (this.$store.state.isBusy) {
        setTimeout(() => loadingComponent.close(), 3 * 1000);
      }
    },
  },
};
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
