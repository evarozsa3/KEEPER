<template>
  <div>
    <a href>
      <span @click.prevent="createVK(vaultData)">{{vaultData.name}}</span>
    </a>
  </div>
</template>

<script>
export default {
  name: "VaultList",
  props: ["vaultData", "keepData"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getMyVaults");
  },
  methods: {
    createVK(vaultData) {
      let vaultId = this.vaultData.id;
      let keepId = this.keepData.id;
      let payload = {
        vaultId,
        keepId
      };
      this.$store.dispatch("createVaultKeep", payload);
    }
  }
};
</script>

<style>
.vbtn {
  height: 4vh;
}
</style>