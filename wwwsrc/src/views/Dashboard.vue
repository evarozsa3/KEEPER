<template>
  <div class="dashboard container-fluid mt-5">
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
    <div class="row justify-content-center">
      <add-keeps></add-keeps>
      <add-vaults></add-vaults>
      <div class>
        <div class="col-12 vaultlist mt-5" id="vaultscroll">
          <v-card v-for="myVault in myVaults" :vaultData="myVault" :key="myVault.id"></v-card>
        </div>
      </div>
    </div>
    <div class="row m-1">
      <k-card class="ml-5" v-for="myKeep in myKeeps" :keepData="myKeep" :key="myKeep.id"></k-card>
    </div>
    <!-- <v-card></v-card> -->
  </div>
</template>

<script>
import AddKeeps from "../components/AddKeeps.vue";
import AddVaults from "../components/AddVaults.vue";
import VCard from "../components/VCard.vue";
import KCard from "../components/KCard.vue";
export default {
  mounted() {
    this.$store.dispatch("getMyVaults");
    this.$store.dispatch("getMyKeeps");
  },
  computed: {
    myVaults() {
      return this.$store.state.myVaults;
    },
    user() {
      return this.$store.state.user;
    },
    myKeeps() {
      console.log(this.$store.state.myKeeps);
      return this.$store.state.myKeeps;
    }
    // publicKeeps() {
    //   return this.$store.state.publicKeeps;
    // }
  },
  components: { AddKeeps, AddVaults, VCard, KCard }
};
</script>

<style>
.vaultlist {
  overflow-y: scroll;
  overflow-x: hidden;
  height: 55vh;
}

::-webkit-scrollbar {
  width: 1em;
}

::-webkit-scrollbar-track {
  box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
}

::-webkit-scrollbar-thumb {
  background-color: darkgrey;
  outline: 1px solid slategrey;
}
</style>
