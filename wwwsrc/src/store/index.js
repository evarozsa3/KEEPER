import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 10000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    // keeps: [],
    publicKeeps: []
  },
  mutations: {
    setKeeps(state, publicKeeps) {
      state.publicKeeps = publicKeeps
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    // I need to fix this.. but not quite sure how
    async getKeeps({ commit }) {
      try {
        let res = await api.get('keeps')
        commit("setKeeps", res.data)
      } catch (err) {
        alert(JSON.stringify(err));
      }
    },
    async createKeep({
      dispatch
    }, newKeep) {
      try {
        let res = await api.post('keeps', newKeep)
        dispatch('getKeeps')
      } catch (error) {
        console.error(error)
      }
    },

    async deleteKeep({ commit, dispatch }, id) {
      try {
        let res = await api.delete("keeps/" + id);
        this.dispatch("getKeeps")
      } catch (err) {
        alert(JSON.stringify(err));
      }
    },
  },
});
