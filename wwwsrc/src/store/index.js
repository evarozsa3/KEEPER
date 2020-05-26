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
    publicKeeps: [],
    myVaults: []
  },
  mutations: {
    setKeeps(state, publicKeeps) {
      state.publicKeeps = publicKeeps
    },
    setVaults(state, myVaults) {
      state.myVaults = myVaults
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

    async getVaults({ commit }) {
      try {
        let res = await api.get('vaults')
        commit("setVaults", res.data)
      } catch (err) {
        alert(JSON.stringify(err));
      }
    },
    async createVault({
      dispatch
    }, newVault) {
      try {
        let res = await api.post('vaults', newVault)
        dispatch('getVaults')
      } catch (error) {
        console.error(error)
      }
    },

    async deleteVault({ commit, dispatch }, id) {
      try {
        console.log("im a delete function")
        let res = await api.delete("vaults/" + id);
        this.dispatch("getVaults")
      } catch (err) {
        alert(JSON.stringify(err));
      }
    },
  },
});
