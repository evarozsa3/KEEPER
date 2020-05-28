<template>
  <div class="m-5">
    <!-- <H1>HELLO THERE</H1> -->
    <form class="addform p-3" @submit.prevent="createKeep()">
      <h1 class="text-center text-info">+Keep</h1>
      <div class="form-group">
        <label for="name">Name:</label>
        <input
          type="text"
          name="name"
          class="form-control"
          placeholder="Enter name...."
          v-model="newKeep.name"
        />
      </div>
      <div class="form-group">
        <label for="description">Description:</label>
        <input
          type="text"
          name="description"
          class="form-control"
          placeholder="Describe...."
          v-model="newKeep.description"
        />
      </div>
      <div class="form-group">
        <label for="img">ImgUrl:</label>
        <input
          type="text"
          name="img"
          class="form-control"
          placeholder="paste img url...."
          v-model="newKeep.img"
        />
      </div>
      <div class="form-group ml-3">
        <!-- <label for="checkbox">Make public</label>
        <input class="ml-1" type="checkbox" id="checkbox" v-model="newKeep.isPrivate" />-->
        <button class="btn btn-info ml-4 px-5" type="submit">Create Keep</button>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "addkeeps",
  data() {
    return {
      newKeep: {}
    };
  },
  mounted() {},
  computed: {},
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
      this.newKeep = {};
      console.log("A NEW KEEP WAS BORN");
    }
  },
  components: {}
};
</script>

<style>
.addform {
  width: 30vw;
  border: 2px black solid;
}
</style>