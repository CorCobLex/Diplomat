import axios from "axios";

export default {
  async getDatas() {
    return await axios.get("/api/Datas");
  },
};
