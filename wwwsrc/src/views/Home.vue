<template>
  <div class="home">
    <!-- <h1>Welcome Home</h1> -->
    <keeps></keeps>
  </div>
</template>

<script>
import Keeps from "../components/Keeps.vue";
export default {
  name: "home",
  computed: {
    keeps() {
      console.log(this.$store.state.publicKeeps);
      return this.$store.state.publicKeeps;
    }
    // user() {
    //   return this.$store.state.user;
    // }
  },
  mounted() {
    this.$store.commit("getKeeps");
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
    // deleteKeep(id) {
    //   console.log("deleteKeep", id);
    //   this.$store.dispatch("deleteKeep", id);
    // },
    // addKeep() {
    //   this.newKeep.isPrivate = this.newKeep.isPrivate == "0";
    //   this.$store.dispatch("addKeep", this.newKeep);
    //   this.newKeep = {};
    // }
  },
  components: {
    Keeps
  }
};
</script>
