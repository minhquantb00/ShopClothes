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
              :src="item.image"
            />
          </div>
        </div>

        <div class="big-image">
          <v-img
            width="100%"
            height="auto"
            src="https://product.hstatic.net/1000341902/product/2403wts41_black___2403wb42_white__2__6b2e562aa0094a959f2beabd89ebf194.jpg"
          />
        </div>

        <div class="description-product">
          <h1>Áo ôm thun bogen trễ vai</h1>
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
              <p class="compare-price">{{ formatCurrency(productDetail.price) }}</p>
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
          <div class="select-color" >
            <h4>Màu sắc sản phẩm</h4>
            <div class="list-color d-flex" >
              <div v-for="color in listColor" :key="color.id" >
                <div class="color-item mr-2" >
                  <input type="radio" name="option-0" checked="" :style="{backgroundColor: color.code}" data-gtm-form-interact-field-id="1">
                  <label ></label>
                </div>
              </div>
            </div>
          </div>
          <div class="select-size mt-8">
            <h4>Kích thước</h4>
            <div class="list-size d-flex mt-8">
              <div v-for="size in listSize" :key="size.id">
                <div class="size-item">
                  <div class="item mr-2">
                    {{ size.name }}
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="add-cart d-flex mt-8">
            <div class="change-quantity d-flex">
              <div class="decrease">
                -
              </div>
              <div class="quantity">
                0
              </div>
              <div class="increase">
                +
              </div>
            </div>
            <div class="button-add-cart">
              Thêm vào giỏ
            </div>
          </div>
          <div class="buy-product text-center">
            MUA NGAY
          </div>
          <hr style="margin-top: 40px; color:grey"/>
          <div class="description-content">
            <h4>Mô tả sản phẩm </h4>
          </div>
        </div>
      </div>
    </div>
    <home-footer style="margin-top: 40px" />
  </div>
</template>

<script>
import HomeHeader from "./../HomeHeader.vue";
import HomeFooter from "../HomeFooter.vue";
import { productApi } from '../../../apis/Product/productApi';

export default {
  components: { HomeHeader, HomeFooter },
  data() {
    return {
      productDetail: {},
      productApi: productApi(),
      listImage: [
        {
          id: 1,
          image: "https://product.hstatic.net/1000341902/product/2403wts41_black___2403wb42_white__2__6b2e562aa0094a959f2beabd89ebf194_compact.jpg",
        },
        {
          id: 2,
          image: "https://product.hstatic.net/1000341902/product/2403wts41_black___2403wb42_white__1__5a893e8ed31e4aabba79c510a725befa_compact.jpg",
        },
        {
          id: 3,
          image: "https://product.hstatic.net/1000341902/product/2403wts41_white_b5bedbd57fb14cb1b045d7685415fa92_compact.jpg",
        },
        {
          id: 4,
          image: "https://product.hstatic.net/1000341902/product/2403wts41_white___2403wb42_navy__8f37f4a26b3f43f2a7a3bbe9e0e896af_compact.jpg",
        },
        {
          id: 5,
          image: "https://product.hstatic.net/1000341902/product/2403wts41_white__1__434d893709cc4d3ca896c7aecad32ce7_compact.jpg",
        },
      ],
      listColor: [
        {
          id: 1,
          code: 'black',
          name: 'đen'
        },
        {
          id: 2,
          code: 'white',
          name: 'trắng'
        }
      ],
      listSize: [
        {
          id: 1,
          name: 'S'
        },
        {
          id: 2,
          name: 'M'
        },
        {
          id: 3,
          name: 'L'
        },
        {
          id: 4,
          name: 'XL'
        }
      ]
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
  },
  async mounted() {
    const id = this.$route.params.id;
    console.log(id)
    try {
      const valueReturn = await this.productApi.getProductById(id);
      const result = valueReturn.data;
      this.productDetail = result.dataResponseProduct;
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
.list-size .size-item .item{
  border: 1px solid black;
  padding: 8px 12px;
  border-radius: 10px;
}

.list-size .size-item:hover{
  cursor: pointer;
}
.change-quantity{
  padding: 12px 0;
  border: 1px grey solid;
  border-radius: 4px;
  margin-right: 20px;
}
.decrease, .increase, .quantity{
  padding: 0 20px;
  font-size: 20px;
}
.decrease, .increase, .quantity:hover{
  cursor: pointer;
}
.button-add-cart{
  padding: 12px 300px;
  border: 1px red solid;
  border-radius: 4px;
  font-size: 20px;
  text-transform: uppercase;
  color: red;
}
.buy-product{
  padding: 12px 300px;
  border: 1px red solid;
  margin-top: 30px;
  border-radius: 4px;
  font-size: 20px;
  color: white;
  text-transform: uppercase;
  background-color: red;
}
.buy-product:hover{
  cursor: pointer;
}
</style>
