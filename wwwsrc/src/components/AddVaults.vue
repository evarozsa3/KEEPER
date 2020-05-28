<template>
  <div class="m-5">
    <!-- <H1>HELLO THERE</H1> -->
    <form class="addvform p-3" @submit.prevent="createVault()">
      <h1 class="text-center text-info">+Vault</h1>
      <div class="form-group">
        <label for="name">Name:</label>
        <input
          type="text"
          name="name"
          class="form-control"
          placeholder="Enter name...."
          v-model="newVault.name"
        />
      </div>
      <div class="form-group">
        <label for="description">Description:</label>
        <input
          type="text"
          name="description"
          class="form-control"
          placeholder="Describe...."
          v-model="newVault.description"
        />
      </div>
      <!-- <div class="form-group">
        <label for="img">ImgUrl:</label>
        <input
          type="text"
          name="img"
          class="form-control"
          placeholder="paste img url...."
          v-model="newKeep.img"
        />
      </div>-->
      <!-- <div class="form-group">
        <label for="checkbox">Make public</label>
        <input type="checkbox" id="checkbox" v-model="newKeep.isPrivate" />
      </div>-->
      <div class="ml-4 pl-3">
        <button class="btn btn-info px-5 ml-5" type="submit">Create Vault</button>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "addvaults",
  data() {
    return {
      newVault: {}
    };
  },
  mounted() {},
  computed: {},
  methods: {
    createVault() {
      this.$store.dispatch("createVault", this.newVault);
      this.newVault = {};
      console.log("A NEW VAULT WAS BORN");
    }
  },
  components: {}
};
</script>

<style>
.addvform {
  width: 30vw;
  border: 2px black solid;
}
</style>