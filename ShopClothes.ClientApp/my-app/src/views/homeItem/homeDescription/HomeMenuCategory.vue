<template>
  <!-- <v-slide-group v-model="model" center-active show-arrows>
    <v-slide-group-item v-for="n in listCategory" :key="n.id" class="">
        <v-card class="mb-5" style="border:none; box-shadow: none; margin-right: 50px;">
          <v-img height="250" :src="n.image" inherit></v-img>

          <v-card-title class="text-h6 text-center">{{
            n.name
          }}</v-card-title>

          <v-card-subtitle class="text-center">
            {{ n.quantity }} sản phẩm
          </v-card-subtitle>
        </v-card>
    </v-slide-group-item>
  </v-slide-group> -->
  <v-sheet
    class="mx-auto"
  >
    <v-slide-group
      v-model="model"
      class="pa-4"
      center-active
      show-arrows="hover"
    
    >
      <v-slide-group-item
        v-for="n in listCategory"
        :key="n.id"
      >
        <v-card
          class="ma-4"
          @click="toggle"
          style="border: none; box-shadow: none;"
        >
          <div class="d-flex fill-height align-center justify-center">
            <v-scale-transition style="border: none; box-shadow: none;">
              <v-card class="mb-5 mr-2" style="cursor: pointer;">
                <v-img height="250" :src="n.image" inherit></v-img>
      
                <v-card-title class="text-h6 text-center">{{
                  n.name
                }}</v-card-title>
      
                <v-card-subtitle class="text-center">
                  {{ n.quantity }} sản phẩm
                </v-card-subtitle>
              </v-card>
            </v-scale-transition>
          </div>
        </v-card>
      </v-slide-group-item>
    </v-slide-group>
  </v-sheet>
</template>

<script>
export default {
  data() {
    return {
      listCategory: [
        {
          id: 1,
          name: "NEW ARRIVAL - MAYBI",
          image:'https://theme.hstatic.net/1000341902/1001140246/14/season_coll_1_img_large.png?v=755',
          quantity: 150,
        },
        {
          id: 2,
          name: "BEST SELLER",
          image:'https://theme.hstatic.net/1000341902/1001140246/14/season_coll_2_img_large.png?v=755',
          quantity: 55,
        },
        {
          id: 3,
          name: "ĐẦM",
          image:'https://theme.hstatic.net/1000341902/1001140246/14/season_coll_3_img_large.png?v=755',
          quantity: 174,
        },
        {
          id: 4,
          name: "ÁO",
          image:'https://theme.hstatic.net/1000341902/1001140246/14/season_coll_4_img_large.png?v=755',
          quantity: 211,
        },
        {
          id: 5,
          name: "VÁY & QUẦN",
          image:'https://theme.hstatic.net/1000341902/1001140246/14/season_coll_5_img_large.png?v=755',
          quantity: 125,
        },
        {
          id: 6,
          name: "ĐỒ NGỦ",
          image:'https://theme.hstatic.net/1000341902/1001140246/14/season_coll_1_img_large.png?v=755',
          quantity: 11,
        },
        {
          id: 7,
          name: "NEW ARRIVAL - MAYBI",
          image:'https://theme.hstatic.net/1000341902/1001140246/14/season_coll_1_img_large.png?v=755',
          quantity: 150,
        },
        {
          id: 8,
          name: "NEW ARRIVAL - MAYBI",
          image:'https://theme.hstatic.net/1000341902/1001140246/14/season_coll_1_img_large.png?v=755',
          quantity: 150,
        },
        {
          id: 9,
          name: "NEW ARRIVAL - MAYBI",
          image:'https://theme.hstatic.net/1000341902/1001140246/14/season_coll_1_img_large.png?v=755',
          quantity: 150,
        },
        {
          id: 10,
          name: "NEW ARRIVAL - MAYBI",
          image:'https://theme.hstatic.net/1000341902/1001140246/14/season_coll_1_img_large.png?v=755',
          quantity: 150,
        },
      ],
    };
  },
};
</script>

<style></style>
