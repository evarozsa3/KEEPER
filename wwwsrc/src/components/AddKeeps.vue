<template>
  <div class="m-5">
    <!-- <H1>HELLO THERE</H1> -->
    <form @submit.prevent="createKeep()">
      <h3 class="text-center">Create a Keep</h3>
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
      <div class="form-group">
        <label for="checkbox">Mark as Public?</label>
        <input type="checkbox" id="checkbox" v-model="newKeep.isPrivate" />
      </div>
      <button class="btn btn-primary" type="submit">Create Keep</button>
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
      console.log("IM A POSTED GHOST");
    }
  },
  components: {}
};
</script>

<style>
</style>