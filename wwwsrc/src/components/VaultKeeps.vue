<template>
  <div class="m-3">
    <div class="card mt-5" style="width: 19rem;">
      <!-- <h1>HEY YOu</h1> -->

      <img class="img m-1" style="width: 18.3rem; height: 18rem;" :src="vkImg" alt="#" />
      <div class="p-2 text-center">
        <h3>{{vaultKeepData.name}}</h3>
        <p>{{vaultKeepData.description}}</p>
      </div>
      <!-- <button class="btn btn-success kbtn m-1 pb-0 pt-0">Add to Vault</button> -->
      <button class="btn btn-warning kbtn m-1 pb-0 pt-0" @click="deleteVaultKeep()">delete</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "VaultKeeps",
  props: ["vaultKeepData", "keepData"],
  data() {
    return {};
  },
  computed: {
    vkImg() {
      let vkImg = this.vaultKeepData.img;
    }
    // getKeepData(id) {
    //   this.$store.dispatch(getKeeps);
    // }
  },
  mounted() {
    // this.$store.dispatch("getKeeps");
  },
  methods: {
    deleteVaultKeep() {
      this.$store.dispatch("deleteVaultKeep", this.vaultKeepData.vaultKeepId);
    }
  }
};
</script>

<style>
.img {
  height: 40vh;
  border-top-left-radius: 2%;
  border-top-right-radius: 2%;
}
.kbtn {
  height: 4vh;
}
.card {
  border-radius: 2%;
  border: black solid 2px;
}
</style>