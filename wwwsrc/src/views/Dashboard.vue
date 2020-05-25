<template>
  <div class="dashboard">
    <!-- <h1>WELCOME TO THE DASHBOARD</h1> -->
    public {{ publicKeeps }} user {{ userKeeps }}
    <add-keeps></add-keeps>
  </div>
</template>

<script>
import AddKeeps from "../components/AddKeeps.vue";
export default {
  mounted() {},
  computed: {},
  components: { AddKeeps }
};
</script>

<style></style>
