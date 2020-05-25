<template>
  <div class="m-3">
    <div class="card" style="width: 18rem;">
      <!-- <h1>HEY YOu</h1> -->
      <img style="width: 18rem;" class="img" :src="keepData.img" alt="#" />
      <h5>name: {{keepData.name}}</h5>
      <p>{{keepData.description}}</p>
      <button class="btn btn-warning" @click="deleteKeep()">delete</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "KCard",
  props: ["keepData"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  methods: {
    deleteKeep() {
      console.log("your keep is no longer with you");
      this.$store.dispatch("deleteKeep", this.keepData.id);
    }
  }
};
</script>

<style>
.img {
  height: 40vh;
}
</style>