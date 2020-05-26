<template>
  <div class="m-3">
    <div class="card mt-5" style="width: 19rem;">
      <!-- <h1>HEY YOu</h1> -->

      <img class="img m-1" style="width: 18.3rem; height: 18rem;" :src="keepData.img" alt="#" />
      <div class="p-2 text-center">
        <h3>{{keepData.name}}</h3>
        <p>{{keepData.description}}</p>
      </div>
      <button class="btn btn-success kbtn m-1 pb-0 pt-0">Add to Vault</button>
      <button class="btn btn-warning kbtn m-1 pb-0 pt-0" @click="deleteKeep()">delete</button>
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