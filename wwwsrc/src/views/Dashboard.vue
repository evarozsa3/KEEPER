<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
    <keeps></keeps>
  </div>
</template>

<script>
import Keeps from "../components/Keeps.vue";
export default {
  mounted() {},
  computed: {},
  components: { Keeps }
};
</script>

<style></style>
