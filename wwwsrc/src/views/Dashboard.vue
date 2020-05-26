<template>
  <div class="dashboard container-fluid">
    <!-- <h1>WELCOME TO THE DASHBOARD</h1> -->
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
    <div class="row">
      <add-keeps></add-keeps>
      <add-vaults></add-vaults>
    </div>
    <!-- <v-card></v-card> -->
    <div class="row">
      <v-card v-for="myVault in myVaults" :vaultData="myVault" :key="myVault.id"></v-card>
    </div>
  </div>
</template>

<script>
import AddKeeps from "../components/AddKeeps.vue";
import AddVaults from "../components/AddVaults.vue";
import VCard from "../components/VCard.vue";
import KCard from "../components/KCard.vue";
export default {
  mounted() {},
  computed: {
    myVaults() {
      return this.$store.state.myVaults;
    },
    user() {
      return this.$store.state.user;
    }
  },
  components: { AddKeeps, AddVaults, VCard, KCard }
};
</script>

<style></style>
