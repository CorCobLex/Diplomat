<template>
  <div>
    <LineChartGenerator
      :chart-options="chartOptions"
      :chart-data="chartData"
      :chart-id="chartId"
      :dataset-id-key="datasetIdKey"
      :plugins="plugins"
      :css-classes="cssClasses"
      :styles="styles"
      :width="width"
      :height="height"
    />
  </div>
</template>

<script>
import { Line as LineChartGenerator } from "vue-chartjs/legacy";
import DatasService from "@/services/DatasService";

import {
  Chart as ChartJS,
  Title,
  Tooltip,
  Legend,
  LineElement,
  LinearScale,
  CategoryScale,
  PointElement,
  Filler,
} from "chart.js";

ChartJS.register(
  Title,
  Tooltip,
  Legend,
  LineElement,
  LinearScale,
  CategoryScale,
  PointElement,
  Filler
);

export default {
  name: "LineChart",
  components: {
    LineChartGenerator,
  },
  props: {
    chartId: {
      type: String,
      default: "line-chart",
    },
    datasetIdKey: {
      type: String,
      default: "label",
    },
    width: {
      type: Number,
      default: 100,
    },
    height: {
      type: Number,
      default: 700,
    },
    cssClasses: {
      default: "",
      type: String,
    },
    styles: {
      type: Object,
      default: () => {},
    },

    plugins: {
      type: Array,
      default: () => [],
    },
  },

  data() {
    return {
      chartData: {
        labels: [],
        datasets: [],
      },
      chartOptions: {
        responsive: true,
        legend: {
          labels: {
            font: {
              size: 12,
              lineHeight: 2,
            },
          },
        },
        maintainAspectRatio: false,
      },
    };
  },

  methods: {
    async fetchDatas() {
      const result = await DatasService.getDatas();

      this.chartData.labels = result.data.data
        .reverse()
        .map((x) => new Date(x.time).toLocaleTimeString());

      const data = result.data.data.reverse().map((x) => parseFloat(x.data));
      console.log(data);
      this.chartData.datasets = [
        {
          fill: true,
          type: "line",
          pointBackgroundColor: "black",
          pointBorderColor: "white",
          backgroundColor: (ctx) => {
            const canvas = ctx.chart.ctx;
            const gradient = canvas.createLinearGradient(0, 0, 0, 700);

            gradient.addColorStop(0.5, "#056C1B");
            gradient.addColorStop(1, "rgba(54, 49, 49, 0.62)");

            return gradient;
          },
          label: "Дебит Нефти",
          tension: 0.2,
          data: data,
        },
      ];
    },
  },

  async mounted() {
    await new Promise((r) => setTimeout(r, 200));
    await this.fetchDatas();
  },
};
</script>
