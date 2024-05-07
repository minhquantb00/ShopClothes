<template>
  <div>
    <home-header style="position: fixed; top: 0; right: 0; left: 0; z-index: 10;" />
    <home-body/>
    <!-- <home-description/> -->
    <home-footer/>
  </div>
</template>

<script>
import HomeHeader from "../../views/homeItem/HomeHeader.vue";
import HomeFooter from "@/views/homeItem/HomeFooter.vue";
import HomeBody from '../../views/homeItem/HomeBody.vue'
// import HomeDescription from '../../views/homeItem/homeDescription/HomeDescription.vue'
export default {
  components: { HomeHeader, HomeFooter, HomeBody },
};
</script>

<style></style>
