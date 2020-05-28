<template>
  <div class="m-3">
    <div class="card mt-5" style="width: 19rem;">
      <!-- <h1>HEY YOu</h1> -->

      <img class="img m-1" style="width: 18.3rem; height: 18rem;" :src="keepData.img" alt="#" />
      <div class="p-2 text-center">
        <h3>{{keepData.name}}</h3>
        <p>{{keepData.description}}</p>
      </div>
      <div class="dropdown">
        <button
          class="btn btn-primary dropdown-toggle kbtn m-1 pb-0 pt-0"
          type="button"
          data-toggle="dropdown"
        >
          +2Vault
          <span class="caret"></span>
        </button>
        <ul class="dropdown-menu">
          <li>
            <vault-list
              v-for="myVault in myVaults"
              :vaultData="myVault"
              :keepData="keepData"
              :key="myVault.id"
            ></vault-list>
          </li>
        </ul>
      </div>

      <!-- <button class="btn btn-success kbtn m-1 pb-0 pt-0">Add to Vault</button> -->
      <button class="btn btn-warning kbtn m-1 pb-0 pt-0" @click="deleteKeep()">delete</button>
    </div>
  </div>
</template>

<script>
import VaultList from "../components/VaultList.vue";
export default {
  name: "KCard",
  props: ["keepData"],
  data() {
    return {};
  },
  mounted() {
    // this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId);
    this.$store.dispatch("getKeeps");
  },
  methods: {
    deleteKeep() {
      console.log("your keep is no longer with you");
      this.$store.dispatch("deleteKeep", this.keepData.id);
    }

    // addVaultKeep() {
    //   this.$router.push({ name: "vault", params: { vaultId: this.selected } });
    //   this.$store.dispatch("getVaultKeeps", this.selected);
    // }
  },
  computed: {
    myVaults() {
      return this.$store.state.myVaults;
    }
  },
  components: { VaultList }
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
  border: rgb(32, 32, 32) solid 2px;
  box-shadow: rgb(145, 97, 43) 2px 2px 5px;
}
</style>