<template>
  <v-app style="background-color: white">
    <side-bar style="z-index: 1; position: relative; background-color: white;" />
    <div class="list-product">
      <v-row style="">
        <v-col
          cols="12"
          sm="2"
          md="2"
          v-for="product in paginatedData"
          :key="product.id"
        >
          <router-link
            :to="`/product-detail/${product.id}`"
            @click="handleRouterLinkClick(product.id)"
            style="text-decoration: none"
          >
            <v-card style="border: none; box-shadow: none; cursor: pointer">
              <v-img :src="product.imageUrl" cover height="20em" width="auto" />
              <v-card-title style="margin: 10px 0; padding: 0">{{
                product.productName
              }}</v-card-title>
              <v-card-text
                style="
                  padding: 0;
                  font-weight: bold;
                  font-size: 18px;
                  color: red;
                "
              >
                Giá: {{ formatCurrency(product.priceAfterDiscount) }}
              </v-card-text>
              <v-card-text style="padding: 10px 0">
                Giá gốc:
                <p class="compare-price">{{ formatCurrency(product.price) }}</p>
              </v-card-text>
            </v-card>
          </router-link>
        </v-col>
      </v-row>
      <div class="set-pagination text-center mt-4" >
        <v-pagination
          v-model="currentPage"
          :length="totalPages"
          rounded="circle"
          style="margin-right: 50px;"

        ></v-pagination>
      </div>
    </div>

  </v-app>
</template>

<script>
import { productApi } from "@/apis/Product/productApi";
import SideBar from "@/pages/manager/sidebar/SideBar.vue";
export default {
  components: { SideBar },
  data() {
    return {
      currentPage: 1,
      drawer: true,
      perPage: 8,
      listProduct: [],
      productApi: productApi(),
      dataProduct: [],
      page: 1,
      loading: false,
      changeColor: false
    };
  },
  async mounted() {
    setTimeout(() => {
      this.loading = false;
    }, 2000);
    const params = {
      keyword: "",
      productTypeId: 0,
      priceTo: 0,
      priceForm: 0,
    };
    const valueReturn = await this.productApi.getAllProducts(params);
    const result = valueReturn.data;
    this.dataProduct = result.dataResponseProducts;
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
    formatCurrency(value) {
      // Chuyển đổi giá trị sang kiểu số nguyên
      const intValue = parseInt(value);

      // Sử dụng hàm toLocaleString để định dạng giá tiền theo tiêu chuẩn của quốc gia
      return intValue.toLocaleString("vi-VN", {
        style: "currency",
        currency: "VND",
      });
    },
    async handleRouterLinkClick(id) {
      try {
        const response = await this.productApi.getProductById(id);
        this.changeColor = true
      } catch (error) {
        console.error("Đã xảy ra lỗi khi gọi API:", error);
      }
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
  watch: {
    group() {
      this.drawer = true;
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
.list-product {
  margin: 65px 0px 0px 257px;
  position: absolute;
  z-index: 2;
  background-color: white;
  padding: 80px 0px 100px 40px;
  right: 0;
  left: 0;
  height: 100%;
  width: 90%;
}

</style>
