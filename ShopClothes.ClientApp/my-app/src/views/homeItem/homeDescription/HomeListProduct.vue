<template>
  <div>
    <VRow>
      <VCol
        cols="12"
        sm="2"
        md="2"
        v-for="(product, index) in paginatedData"
        :key="index"
      >
        <VCard style="border: none; box-shadow: none; cursor: pointer;">
          <VImg :src="product.image" cover height="30em" />

          <VCardTitle style="margin: 10px 0; padding: 0">{{ product.productName }}</VCardTitle>
          <VCardText style="padding: 0"> Giá: {{ product.priceAfterDiscount }} </VCardText>
          <VCardText
          style="padding: 10px 0"
            >Giá gốc:
            <p class="compare-price">{{ product.price }}</p>
            </VCardText
          >
        </VCard>
      </VCol>
    </VRow>
    <div class="text-center mt-4">
      <v-pagination
        v-model="currentPage"
        :length="totalPages"
        rounded="circle"
      ></v-pagination>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      currentPage: 1,
      perPage: 12,
      dataProduct: [
        {
          id: 1,
          image:
            "https://product.hstatic.net/1000341902/product/2404wo23_red__5__4d1d063b96b840b9807e276c3927878e_large.jpg",
          productName: "Áo khoác chống nắng chống UV làm mát",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
        {
          id: 2,
          image:
            "https://product.hstatic.net/1000341902/product/2311wd22__navy__2__copy_a8a17b30efee4b378a06077af4afcec3_large.jpg",
          productName: "Đầm mini voan hoa",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
        {
          id: 3,
          image:
            "https://product.hstatic.net/1000341902/product/2311wd20_black__3__copy_c582b0bd9c2e4e18a25cb466c7472c2d_large.jpg",
          productName: "Đầm dài ôm voan hoa",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
        {
          id: 4,
          image:
            "https://product.hstatic.net/1000341902/product/2311wd51_black__1__copy_a9d6899023fe4d2db6ba2c73a8f6b76c_large.jpg",
          productName: "Đầm mini xòe họa tiết",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
        {
          id: 5,
          image:
            "https://product.hstatic.net/1000341902/product/2312wd08__red__2__copy_051bd2635fa24033b8d7691518d63462_large.jpg",
          productName: "Đầm midi ôm voan cát phối nhún trang trí",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
        {
          id: 6,
          image:
            "https://product.hstatic.net/1000341902/product/2311wd13_white__1__copy_bfd3571fdbc149629d40757b901c013b_large.jpg",
          productName: "Đầm dài rút nhún voan hoa",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),

        },
        {
          id: 7,
          image:
            "https://product.hstatic.net/1000341902/product/2311wd23_red__2__copy_51ee1969cecc4b4596a8590413d44b8f_large.jpg",
          productName: "Đầm mini xòe voan nhún",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
        {
          id: 8,
          image:
            "https://product.hstatic.net/1000341902/product/2311wd19__purple__4__copy_59049cfd262947c1b0e79f67f9796e6a_large.jpg",
          productName: "Áo dài ôm voan hoa tay phồng",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
        {
          id: 9,
          image:
            "https://product.hstatic.net/1000341902/product/2310wa42_12-_xanh__4__f7e79cd3edf44b86a74fad057d6ba238_large.jpg",
          productName: "Áo dài suông lụa sóng phối tay voan họa tiết",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
        {
          id: 10,
          image:
            "https://product.hstatic.net/1000341902/product/2310wa40_15_-_hong__1__42b4ce248c7a4aceb9036f870f04a319_large.jpg",
          productName: "Áo dài suông",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
        {
          id: 11,
          image:
            "https://product.hstatic.net/1000341902/product/2310wa42_12-_xanh__4__f7e79cd3edf44b86a74fad057d6ba238_large.jpg",
          productName: "Áo dài ôm lụa",
          priceAfterDiscount: 2000 + "$",
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
        {
          id: 12,
          image:
            "https://product.hstatic.net/1000341902/product/2310wa40_15_-_hong__1__42b4ce248c7a4aceb9036f870f04a319_large.jpg",
          productName: "Áo dài ôm voan hoa tay cánh tiên",
          priceAfterDiscount: 2000,
          price: 3000 + "$",
          createTime: new Date("2024-01-01"),
        },
      ],
      page: 1,
    };
  },
  methods: {
    formatDate(dateString) {
      const date = new Date(dateString);
      const day = date.getDate();
      const month = date.getMonth() + 1;
      const year = date.getFullYear();
      const hours = date.getHours();
      const minutes = date.getMinutes();
      const seconds = date.getSeconds();
      const formattedDay = day < 10 ? "0" + day : day;
      const formattedMonth = month < 10 ? "0" + month : month;
      const formattedHours = hours < 10 ? "0" + hours : hours;
      const formattedMinutes = minutes < 10 ? "0" + minutes : minutes;
      const formattedSeconds = seconds < 10 ? "0" + seconds : seconds;

      return `${formattedDay}/${formattedMonth}/${year}`;
    },
  },
  computed: {
    paginatedData() {
      const start = (this.currentPage - 1) * this.perPage;
      const end = start + this.perPage;
      return this.dataProduct.slice(start, end);
    },
    totalPages() {
      return Math.ceil(this.dataProduct.length / this.perPage);
    },
  },
};
</script>

<style scoped>
.compare-price {
  color: var(--text-secondary-color);
  text-decoration: line-through;
  font-size: 14px;
  display: inline-block;
  margin-right: 5px;
}
</style>
