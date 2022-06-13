<template>
  <section>
    <time-select />
    <bar-chart-vue class="chart" />
  </section>
</template>
<script>
import BarChartVue from "@/components/BarChart.vue";
import TimeSelect from "@/components/ButtonsTime.vue";
export default {
  components: {
    BarChartVue,
    TimeSelect,
  },
  data() {
    return {};
  },

  mounted() {
    this.$store.state.isBusy = false;
  },
};
</script>
<style scoped>
.chart {
  margin: 2%;
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  text-decoration-color: blue;
}
</style>
