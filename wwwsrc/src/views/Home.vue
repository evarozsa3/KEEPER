<template>
  <div class="home container-fluid">
    <!-- <h1>Welcome Home</h1> -->
    <add-keeps></add-keeps>
    <k-card></k-card>
    <div class="row">
      <k-card v-for="publicKeep in publicKeeps" :keepData="publicKeep" :key="publicKeep.id"></k-card>
    </div>
  </div>
</template>

<script>
import KCard from "../components/KCard.vue";
import AddKeeps from "../components/AddKeeps.vue";
export default {
  name: "home",
  computed: {
    keeps() {
      console.log(this.$store.state.publicKeeps);
      return this.$store.state.publicKeeps;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    user() {
      return this.$store.state.user;
    }
  },
  mounted() {
    // this.$store.commit("getKeeps");
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
    AddKeeps,
    KCard
  }
};
</script>
