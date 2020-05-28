<template>
  <div class="home container-fluid mt-5">
    <!-- <h1>Welcome Home</h1> -->
    <!-- <add-keeps></add-keeps> -->
    <!-- <k-card></k-card> -->
    <div class="row m-1">
      <my-k-card
        class="ml-5"
        v-for="publicKeep in publicKeeps"
        :keepData="publicKeep"
        :key="publicKeep.id"
      ></my-k-card>
    </div>
  </div>
</template>

<script>
import MyKCard from "../components/MyKCard.vue";
import AddKeeps from "../components/AddKeeps.vue";
export default {
  name: "home",
  computed: {
    keeps() {
      console.log(this.$store.state.publicKeeps);
      return this.$store.state.publicKeeps;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    user() {
      return this.$store.state.user;
    }
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    AddKeeps,
    MyKCard
  }
};
</script>
