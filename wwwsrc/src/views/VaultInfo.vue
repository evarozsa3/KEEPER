<template>
  <div class="home container-fluid">
    <h1>Vault Details</h1>

    <div class="row">
      <div class="row m-1">
        <k-card class="ml-5" v-for="myKeep in myKeeps" :keepData="myKeep" :key="myKeep.id"></k-card>
      </div>
    </div>
  </div>
</template>

<script>
import KCard from "../components/KCard.vue";
export default {
  name: "vaultInfo",
  mounted() {
    this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId);
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    myKeeps() {
      console.log(this.$store.state.myKeeps);
      return this.$store.state.myKeeps;
    }
  },
  methods: {},
  components: { KCard }
};
</script>