<template>
  <div class="my-5">
    <!-- <H1>HELLO THERE</H1> -->
    <form class="addform p-3" @submit.prevent="createKeep()">
      <h1 class="text-center text-info">+Keep</h1>
      <div class="form-group text-warning">
        <label for="name">Name:</label>
        <input
          type="text"
          name="name"
          class="form-control"
          placeholder="Enter name...."
          v-model="newKeep.name"
        />
      </div>
      <div class="form-group text-warning">
        <label for="description">Description:</label>
        <input
          type="text"
          name="description"
          class="form-control"
          placeholder="Describe...."
          v-model="newKeep.description"
        />
      </div>
      <div class="form-group text-warning">
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
        <!-- <label for="checkbox">Make public</label>
        <input class="ml-1" type="checkbox" id="checkbox" v-model="newKeep.isPrivate" />-->
        <button class="btn btnadd btn-info px-5 p-0" type="submit">
          <h5>+</h5>
        </button>
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
  width: 23vw;
  border: 2px rgb(24, 23, 23) solid;
  background-color: rgb(75, 74, 74);
  box-shadow: rgb(93, 102, 9) 2px 2px 5px;
  border-radius: 10px;
}

.btnadd {
  height: 30px;
}
</style>