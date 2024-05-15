<template>
  <v-footer class="bg-grey-lighten-1" style="min-height: 400px">
    <v-container>
      <div class="footer-item">
        <div style="text-align: left">
          <div>
            <router-link to="/">
              <img
                src="../../assets/image-removebg-preview (1).png"
                style="width: 300px"
              />
            </router-link>
          </div>
          <div class="address d-flex">
            <v-icon style="margin-right: 10px; margin-left: 38px"
              >mdi-map-marker</v-icon
            >
            <p>Địa chỉ: Yên Tập Bắc - Yên Lư - Yên Dũng - Bắc Giang</p>
          </div>
          <div class="address d-flex" style="margin: 20px 0">
            <v-icon style="margin-right: 10px; margin-left: 38px"
              >mdi-cellphone</v-icon
            >
            <p>Số điện thoại: 0339245240</p>
          </div>
          <div class="address d-flex">
            <v-icon style="margin-right: 10px; margin-left: 38px"
              >mdi-email</v-icon
            >
            <p>Email: minhquantb00@gmail.com</p>
          </div>
        </div>

        <div style="display: inline; text-align: center">
          <v-card-title> Thông tin liên hệ </v-card-title>
          <p style="margin-top: 30px">Thông tin liên hệ</p>
          <p style="margin: 20px 0">Tuyển dụng</p>
          <p>Về MyBugsShop</p>
        </div>

        <div style="display: inline; text-align: center">
          <v-card-title style="margin-bottom: 20px; margin-top: 80px">
            Chính sách
          </v-card-title>
          <p>Chính sách đổi trả</p>
          <p style="margin: 20px 0">Khách hàng thân thiện</p>
          <p style="margin: 20px 0">Giao hàng - thanh toán</p>
          <p style="margin: 20px 0">Bảo mật thông tin</p>
          <p>Chính sách nhượng quyền thương hiệu</p>
        </div>

        <div style="display: inline; text-align: center">
          <v-card-title style="margin-bottom: 20px;"> Đăng ký thành viên để nhận ưu đãi </v-card-title>
          <div class="d-flex" style="align-items: center">
            <v-text-field
              hide-details="auto"
              label="Nhập email đăng ký"
              style="background-color: white; border: none"
            ></v-text-field>
            <v-btn
              class="d-flex text-white"
              style="padding: 28px; margin-left: 10px; background-color: black"
              >Đăng ký</v-btn
            >
          </div>
          <ul
            class="follow_option d-flex flex-wrap align-items-center list-unstyled mt-4"
            style="list-style: none;"
          >
            <li style="margin-right: 20px">
              <a
                class="facebook link"
                href="https://www.facebook.com/maybi.official"
                target="_blank"
                title="Theo dõi Facebook MyBugsShop - Thời trang nữ thiết kế - Chất lượng vượt trội - Giá cả hợp lý"
              >
                <img
                  src="//theme.hstatic.net/1000341902/1001140246/14/facebook.png?v=755"
                  width="32"
                  height="32"
                  alt="facebook"
                />
              </a>
            </li>

            <li style="margin-right: 20px">
              <a
                class="instgram link"
                href="https://www.instagram.com/maybi_official/"
                target="_blank"
                title="Theo dõi instgram MyBugsShop - Thời trang nữ thiết kế - Chất lượng vượt trội - Giá cả hợp lý"
              >
                <img
                  src="//theme.hstatic.net/1000341902/1001140246/14/instagram.png?v=755"
                  width="32"
                  height="32"
                  alt="instgram"
                />
              </a>
            </li>

            <li style="margin-right: 20px">
              <a
                class="youtube link"
                href="https://www.youtube.com/@thoitrangmaybi4893"
                target="_blank"
                title="Theo dõi youtube MyBugsShop - Thời trang nữ thiết kế - Chất lượng vượt trội - Giá cả hợp lý"
              >
                <img
                  src="//theme.hstatic.net/1000341902/1001140246/14/youtube.png?v=755"
                  width="36"
                  height="36"
                  alt="youtube"
                />
              </a>
            </li>
          </ul>
        </div>
      </div>
    </v-container>
  </v-footer>
</template>

<script>
export default {
  data() {
    return {
      links: ["Home", "About", "Contact", "Product", "Introduction"],
    };
  },
};
</script>

<style scoped>
.footer-item {
  display: flex;
  justify-content: space-evenly;
  align-items: center;
}
</style>
