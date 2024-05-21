<template>
  <div>
    <h1 style="margin-bottom: 20px;">NEW ARRIVAL - MyBugsShop</h1>
    <VRow>
      <VCol
        cols="12"
        sm="2"
        md="2"
        v-for="(product, index) in paginatedData"
        :key="index"
      >
        <VCard style="border: none; box-shadow: none; cursor: pointer;">
          <VImg :src="product.imageUrl" cover height="30em" />

          <VCardTitle style="margin: 10px 0; padding: 0">{{ product.productName }}</VCardTitle>
          <VCardText style="padding: 0; font-weight:bold; font-size:18px; color: red"> Giá: {{ formatCurrency(product.priceAfterDiscount) }}</VCardText>
          <VCardText
          style="padding: 10px 0"
            >Giá gốc:
            <p class="compare-price">{{ formatCurrency(product.price) }}</p>
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
import  { productApi } from '../../../apis/Product/productApi'
export default {
  data() {
    return {
      currentPage: 1,
      perPage: 12,
      listProduct: [],
      productApi: productApi(),
      dataProduct: [],
      page: 1,
      loading:  false
    };
  },
  async mounted() {
    setTimeout(() => {
      this.loading = false;
    }, 2000)
    const params = {
      keyword: '',
      productTypeId: 0,
      priceTo: 0,
      priceForm: 0
    }
    const valueReturn = await this.productApi.getAllProducts(params);
    const result = valueReturn.data
    console.log(result.dataResponseProducts)
    this.dataProduct = result.dataResponseProducts
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
    async handleRouterClick(id){
      try {
        const response = await this.productApi.getProductById(id);
      } catch (error) {
        console.error("Đã xảy ra lỗi khi gọi API:", error);
        // this.$router.push("/error");
      }
    }
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
