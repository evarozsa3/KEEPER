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
    myKeeps: [],
    publicKeeps: [],
    myVaults: []
  },
  mutations: {
    setKeeps(state, publicKeeps) {
      state.publicKeeps = publicKeeps
    },
    setMyKeeps(state, keeps) {
      state.myKeeps = keeps
    },
    setMyVaults(state, vaults) {
      state.myVaults = vaults
    },
    // setVaults(state, myVaults) {
    //   state.myVaults = myVaults
    // }
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
    async getMyKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps/user")
        commit("setMyKeeps", res.data)
      } catch (e) {
        alert(JSON.stringify(e));
      }
    },
    async createKeep({
      dispatch
    }, newKeep) {
      try {
        let res = await api.post('keeps', newKeep)
        dispatch('getKeeps')
        dispatch('getMyKeeps')
      } catch (error) {
        console.error(error)
      }
    },

    async deleteKeep({ commit, dispatch }, id) {
      try {
        let res = await api.delete("keeps/" + id);
        this.dispatch("getKeeps")
        this.dispatch('getMyKeeps')
      } catch (err) {
        alert(JSON.stringify(err));
      }
    },

    // async getVaults({ commit }) {
    //   try {
    //     let res = await api.get('vaults/user')
    //     commit("setVaults", res.data)
    //   } catch (err) {
    //     alert(JSON.stringify(err));
    //   }
    // },
    async getMyVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults/user")
        commit("setMyVaults", res.data)
      } catch (e) {
        alert(JSON.stringify(e));
      }
    },
    async createVault({
      dispatch
    }, newVault) {
      try {
        let res = await api.post('vaults', newVault)
        dispatch('getMyVaults')
      } catch (error) {
        console.error(error)
      }
    },

    async deleteVault({ commit, dispatch }, id) {
      try {
        console.log("im a delete function")
        let res = await api.delete("vaults/" + id);
        this.dispatch("getMyVaults")
      } catch (err) {
        alert(JSON.stringify(err));
      }
    },
  },
});
