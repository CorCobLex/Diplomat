<template>
  <div id="app">
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
html,
body {
  height: 100vh;
  width: 100vw;
  background: #f1f1f1;
  overflow-y: hidden;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  overflow-y: hidden;
}
</style>
