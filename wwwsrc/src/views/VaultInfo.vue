<template>
  <div class="home container-fluid">
    <!-- <h1>Vault Details</h1> -->

    <div class="row">
      <div class="row m-1">
        <vault-keeps
          class="ml-5"
          v-for="vaultKeep in vaultKeeps"
          :vaultKeepData="vaultKeep"
          :key="vaultKeep.id"
        ></vault-keeps>
      </div>
      <vault-keeps></vault-keeps>
    </div>
  </div>
</template>

<script>
import VaultKeeps from "../components/VaultKeeps.vue";
export default {
  name: "vaultInfo",
  mounted() {
    this.$store.dispatch("getMyVaultKeeps", this.$route.params.vaultId);
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vaultKeeps() {
      console.log(this.$store.state.vaultKeeps, "Hello my name is VaultKeep");
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {},
  components: { VaultKeeps }
};
</script>