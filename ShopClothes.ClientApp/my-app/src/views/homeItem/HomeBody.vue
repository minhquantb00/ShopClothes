<template>
  <div id="content-course">
    <div class="slider">
      <v-carousel
        show-arrows="hover"
        hide-delimiters
        continuous="true"
        cycle
        interval="6000"
        style="height: 800px !important;"
      >
        <v-carousel-item
          v-for="b in listBanner"
          :key="b"
          :src="b.anhBanner"
          style="object-fit: fill; height: 500px"
          cover
        ></v-carousel-item>
      </v-carousel>
    </div>
    <div fluid  style="margin: 0 340px">
      <home-description style="margin-top: 40px;"/>
      <home-menu-category style="margin-top: 40px"/>
      <home-list-product style="margin: 40px 0"/>
    </div>
  </div>
</template>

<script>
import HomeDescription from '../../views/homeItem/homeDescription/HomeDescription.vue'
import HomeMenuCategory from'../../views/homeItem/homeDescription/HomeMenuCategory.vue'
import HomeListProduct from '../../views/homeItem/homeDescription/HomeListProduct.vue'
export default {
  components:{HomeDescription, HomeMenuCategory, HomeListProduct},
  data() {
    return {
      listBanner: [
        {
          anhBanner: 'https://theme.hstatic.net/1000341902/1001140246/14/slider_3.jpg?v=755'
        },
        {
          anhBanner: 'https://theme.hstatic.net/1000341902/1001140246/14/slider_3.jpg?v=755'
        }
      ]
    }
  },
}
</script>

<style>

</style>
