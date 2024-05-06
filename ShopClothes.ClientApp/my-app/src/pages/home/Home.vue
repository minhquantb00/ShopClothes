<template>
  <div>
    <home-header style="min-height: 100vh" />
    <home-footer />
  </div>
</template>

<script>
import HomeHeader from "../../views/homeItem/HomeHeader.vue";
import HomeFooter from "@/views/homeItem/HomeFooter.vue";
export default {
  components: { HomeHeader, HomeFooter, HomeFooter },
};
</script>

<style></style>
