<template>
  <div class="m-3">
    <div class="card" style="width: 18rem;">
      <!-- <h1>HEY YOu</h1> -->
      <img style="width: 18rem;" class="img" :src="keepData.img" alt="#" />
      <h5>name: {{keepData.name}}</h5>
      <p>{{keepData.description}}</p>
      <button class="btn btn-warning">delete</button>
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
  }
};
</script>

<style>
.img {
  height: 40vh;
}
</style>