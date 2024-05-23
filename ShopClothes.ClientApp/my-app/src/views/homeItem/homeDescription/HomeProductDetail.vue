<template>
  <div style="margin-top: 150px">
    <home-header
      style="position: fixed; top: 0; right: 0; left: 0; z-index: 10"
    />
    <div class="product-detail">
      <div class="product-detail-item">
        <div class="list-image">
          <div v-for="item in listImage" :key="item.id">
            <v-img
              width="90"
              height="auto"
              style="margin-bottom: 10px"
              cover
              :src="item.imageUrl"
            />
          </div>
        </div>

        <div class="big-image">
          <v-img width="100%" height="auto" :src="productDetail.imageUrl" />
        </div>

        <div class="description-product">
          <h1>{{ productDetail.productName }}</h1>
          <div class="description d-flex">
            <span style="margin-right: 10px">Thương hiệu: MyBugsShop</span>
            <span>Mã sản phẩm: 2403WTS4106S</span>
          </div>
          <div class="price-product">
            <VCardText
              style="padding: 0; font-weight: bold; font-size: 18px; color: red"
            >
              Giá: {{ formatCurrency(productDetail.priceAfterDiscount) }}
              <div
                style="
                  padding: 4px 8px;
                  border-radius: 10px;
                  color: white;
                  background-color: red;
                  display: inline;
                  font-size: 16px;
                  margin-left: 10px;
                "
              >
                -0%
              </div>
            </VCardText>
            <VCardText style="padding: 10px 0"
              >Giá gốc:
              <p class="compare-price">
                {{ formatCurrency(productDetail.price) }}
              </p>
            </VCardText>
          </div>
          <div class="product-promotion">
            <h3
              class="product-promotion__heading rounded-sm d-inline-flex align-items-center"
            >
              <img
                class="mr-2"
                width="22"
                height="22"
                src="https://theme.hstatic.net/1000341902/1001140246/14/icon-product-promotion.png?v=782"
                alt=""
              />
              Ưu đãi
            </h3>
            <ul>
              <li>Freeship cho đơn hàng từ 499K</li>
              <li>Giảm 15% cho khách hàng lần đầu mua hàng</li>
              <li>
                Khách hàng được quyền đổi trong vòng 7 ngày từ lúc nhận hàng
                (Không áp dụng cho hàng khuyến mãi)
              </li>
              <li>Và thêm các mã khuyến mãi bên dưới</li>
            </ul>
          </div>
          <div class="select-color">
            <h4>Màu sắc sản phẩm</h4>
            <div class="d-flex">
              <div
                class="list-color d-flex"
                v-for="item in listColor"
                :key="item"
              >
                <div>
                  <div class="color-item mr-2">
                    <input
                      type="radio"
                      name="option-0"
                      checked=""
                      :style="{ backgroundColor: item }"
                      data-gtm-form-interact-field-id="1"
                    />
                    <label></label>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="select-size mt-8">
            <h4>Kích thước</h4>
            <div class="d-flex">
              <div
                class="list-size d-flex mt-2"
                v-for="item in listSize"
                :key="item"
              >
                <div>
                  <div class="size-item">
                    <div class="item mr-2">
                      {{ item }}
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="add-cart d-flex mt-8">
            <div class="change-quantity d-flex">
              <div class="decrease" @click="handleDecreaseBuyQuantity()">-</div>
              <div class="quantity">
                {{ quantityCart }}
              </div>
              <div class="increase" @click="handleIncreaseBuyQuantity()">+</div>
            </div>
            <div
              class="button-add-cart"
              style="cursor: pointer"
              @click="addToCart()"
            >
              Thêm vào giỏ
            </div>
          </div>
          <div class="buy-product text-center">MUA NGAY</div>
          <hr style="margin-top: 40px; color: grey" />
          <div class="description-content">
            <h4>Mô tả sản phẩm</h4>
          </div>
        </div>
      </div>

      <div class="set-alert" v-if="isSuccess">
        <v-alert
          type="success"
          closable
          title="Thêm sản phẩm vào giỏ hàng thành công"
          v-model="showAlert"
        ></v-alert>
      </div>
      <div class="set-alert" v-else>
        <v-alert
          type="error"
          closable
          title="Vui lòng chọn số lượng sản phẩm muốn thêm vào giỏ hàng"
          v-model="showAlert"
          color="red"
        ></v-alert>
      </div>
    </div>

    <home-footer style="margin-top: 40px" />
  </div>
</template>

<script>
import HomeHeader from "./../HomeHeader.vue";
import HomeFooter from "../HomeFooter.vue";
import { productApi } from "../../../apis/Product/productApi";
import eventBus from "../../../plugins/eventBus";
import { useRouter } from "vue-router";
export default {
  components: { HomeHeader, HomeFooter },
  data() {
    return {
      productDetail: {},
      productApi: productApi(),
      userInfo: localStorage.getItem("userInfo")
        ? JSON.parse(localStorage.getItem("userInfo"))
        : null,
      listImage: [],
      listProductDetail: [],
      quantityCart: 0,
      isSuccess: false,
      showAlert: false,
      listSize: [],
      listColor: [],
      selectColor: null,
      selectSize: null,
      router: useRouter()
    };
  },
  methods: {
    formatCurrency(value) {
      const intValue = parseInt(value);
      return intValue.toLocaleString("vi-VN", {
        style: "currency",
        currency: "VND",
      });
    },
    handleIncreaseBuyQuantity() {
      this.quantityCart++;
    },
    handleDecreaseBuyQuantity() {
      if (this.quantityCart === 0) {
        this.quantityCart = 0;
      } else {
        this.quantityCart--;
      }
    },
    addToCart() {
      if(!this.userInfo){
        this.router.push({path: '/login'})
      }
      else{
        if (!eventBus.quantityCart) {
        eventBus.quantityCart = 0;
        this.isSuccess = false;
        this.showAlert = true;
        setTimeout(() => {
          this.showAlert = false;
        }, 1500);
      }
      if (this.quantityCart !== 0) {
        eventBus.quantityCart += this.quantityCart;
        this.isSuccess = true;
        this.showAlert = true;
        setTimeout(() => {
          this.showAlert = false;
        }, 1500);
      }
      else{
        this.isSuccess = false;
        this.showAlert = true
        setTimeout(() => {
          this.showAlert = false;
        }, 1500);
      }
      }
    },
  },
  async mounted() {
    const id = this.$route.params.id;
    console.log(id);
    try {
      const valueReturn = await this.productApi.getProductById(id);
      const result = valueReturn.data;
      this.productDetail = result.dataResponseProduct;
      this.listImage = result.dataResponseProduct.productImages;

      this.listProductDetail = result.dataResponseProduct.productDetails;
      this.listColor = this.listProductDetail.map((record) => record.colorCode);
      this.listSize = this.listProductDetail.map((record) => record.sizeName);
      console.log(result.dataResponseProduct);
    } catch (error) {
      console.error("Đã xảy ra lỗi khi gọi API:", error);
    }
  },
};
</script>

<style scoped>
input[type="radio"] {
  -webkit-appearance: none; /* Xóa style mặc định của browser */
  -moz-appearance: none;
  appearance: none;
  display: inline-block;
  width: 40px; /* Kích thước chiều rộng */
  height: 40px; /* Kích thước chiều cao */
  border-radius: 50%; /* Bán kính bo tròn */
  border: 1px solid #000; /* Viền và màu viền */
  vertical-align: middle;
  cursor: pointer;
  margin-right: 5px; /* Khoảng cách giữa radio và text */
}

/* Style khi hover */
input[type="radio"]:hover {
  border-color: #666; /* Màu viền khi hover */
}
.product-detail {
  min-height: 900px;
  padding: 0 420px;
  position: relative;
}
.product-detail-item {
  display: flex;
}
.big-image {
  margin-left: 30px;
}
.description-product {
  margin-left: 60px;
}
.compare-price {
  color: var(--text-secondary-color);
  text-decoration: line-through;
  font-size: 14px;
  display: inline-block;
  margin-right: 5px;
}
.price-product {
  margin-top: 20px;
}
.product-promotion {
  padding: 10px;
  margin-bottom: 10px;
  border: 2px dashed #b00002;
  margin-top: 30px;
  position: relative;
}
.product-promotion__heading {
  margin-bottom: 8px;
  font-size: 14px;
  font-weight: 700;
  padding: 5px 10px;
  color: #b00002;
  background: #fff;
  position: absolute;
  top: -20px;
}
.product-promotion > ul {
  margin-bottom: 0;
  border-radius: 4px;
  padding: 8px 8px 8px 15px;
  list-style-position: inside;
  background: #fff;
  font-size: 14px;
}
.list-size .size-item .item {
  border: 1px solid grey;
  padding: 8px 12px;
  border-radius: 10px;
}

.list-size .size-item:hover {
  cursor: pointer;
}
.change-quantity {
  padding: 12px 0;
  border: 1px grey solid;
  border-radius: 4px;
  margin-right: 20px;
}
.decrease,
.increase,
.quantity {
  padding: 0 20px;
  font-size: 20px;
}
.decrease,
.increase,
.quantity:hover {
  cursor: pointer;
}
.button-add-cart {
  padding: 12px 300px;
  border: 1px red solid;
  border-radius: 4px;
  font-size: 20px;
  text-transform: uppercase;
  color: red;
}
.buy-product {
  padding: 12px 300px;
  border: 1px red solid;
  margin-top: 30px;
  border-radius: 4px;
  font-size: 20px;
  color: white;
  text-transform: uppercase;
  background-color: red;
}
.buy-product:hover {
  cursor: pointer;
}
.set-alert {
  width: 400px;
  position: absolute;
  right: 20px;
  z-index: 10;
  bottom: 20px;
}
</style>
