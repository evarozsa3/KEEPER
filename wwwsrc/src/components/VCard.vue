<template>
  <div class="m-3">
    <div class="card" style="width: 18rem;">
      <!-- <img style="width: 18rem;" class="img" :src="keepData.img" alt="#" /> -->
      <div class="m-1 text-center">
        <h1>{{vaultData.name}}</h1>
        <p>{{vaultData.description}}</p>
        <span>Keeps: 0</span>
      </div>
      <button class="btn btn-success vbtn m-1 pb-0 pt-0">View Vault</button>
      <button class="btn btn-warning vbtn m-1 pb-0 pt-0" @click="deleteVault()">delete</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "VCard",
  props: ["vaultData"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getMyVaults");
  },
  methods: {
    deleteVault() {
      console.log("your vault is no longer with you");
      this.$store.dispatch("deleteVault", this.vaultData.id);
    }
  }
};
</script>

<style>
.vbtn {
  height: 4vh;
}
</style>