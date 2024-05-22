<template>
  <v-card style="border-radius: 0;" color="grey-lighten-3" max-width="100%">
    <v-layout>
      <v-app-bar class="set-app-bar" color="white">
        <!-- <template v-slot:prepend>
          <v-app-bar-nav-icon></v-app-bar-nav-icon>
        </template> -->

        <div>
          <router-link to="/">
            <img
            src="../../assets/image-removebg-preview (1).png"
            style="width: 200px"
          />
          </router-link>
        </div>

        <v-spacer></v-spacer>
        <div class="d-flex" style="margin-right: 50px">
          <v-btn text class="menu-item" style="padding-left: 0">
            <v-icon left class="item">mdi-home</v-icon>
            Mới Về
          </v-btn>
          <v-btn text class="menu-item">
            <v-icon left class="item">mdi-heart</v-icon>
            Mother's Day
          </v-btn>
          <v-btn text class="menu-item">
            <v-icon left class="item">mdi-alert-circle</v-icon>
            Last Chance
          </v-btn>
          <v-btn text class="menu-item">
            <v-icon left class="item">mdi-fire</v-icon>
            Bán Chạy
          </v-btn>
        </div>
        <div style="margin-right: 100px; display: flex">
          <div class="search d-flex" style="font-size: 16px">
            <v-btn>
              <v-icon style="font-size: 16px">mdi-magnify</v-icon>
            </v-btn>
            <input
              class="search-input-item"
              type="text"
              placeholder="Tìm kiếm từ khóa"
              style="font-size: 16px"
            />
          </div>

          <div v-if="userInfo" style="width: 100%; margin-right: 400px; margin-bottom: 4px;">
            <v-btn style="margin-right: 20px; font-size: 16px; position:relative">
              <v-icon>mdi-heart</v-icon>
              <p style="margin-left: 10px; margin-top: 10px; text-transform: capitalize">
                Giỏ hàng
              </p>
              <span class="number-cart">{{ quantityCart }}</span>
            </v-btn>

            <v-btn icon>
              <v-menu
                v-model="menu"
                :close-on-content-click="false"
                location="bottom"
              >
                <template v-slot:activator="{ props }">
                  <v-btn
                    color="black"
                    variant="text"
                    icon
                    class="text-none"
                    v-bind="props"
                  >
                    <v-avatar
                      size="50"
                      :image="user.avatarUrl"
                    ></v-avatar>
                  </v-btn>
                </template>

                <v-card min-width="300" style="margin-top: 8px">
                  <v-list>
                    <v-list-item
                      class="user-list-item"
                      :prepend-avatar="user.avatarUrl"
                      :subtitle="userInfo.Email"
                      :title="userInfo.FullName"
                    >
                    </v-list-item>
                  </v-list>

                  <v-list>
                    <v-list-item style="cursor:pointer">
                      <v-title> Giỏ hàng của tôi </v-title>
                      <template v-slot:append>
                        <v-badge color="purple" content="0" inline></v-badge>
                      </template>
                    </v-list-item>
                  </v-list>
                  <v-list-item style="cursor:pointer">
                    <v-title> Thông báo </v-title>
                    <template v-slot:append>
                      <v-badge color="purple" content="0" inline></v-badge>
                    </template>
                  </v-list-item>
                  <v-list-item style="cursor:pointer">
                    <v-title> Tin nhắn </v-title>
                    <template v-slot:append>
                      <v-badge color="purple" content="0" inline></v-badge>
                    </template>
                  </v-list-item>

                  <a href="/">
                    <v-btn
                      :disabled="loading"
                      :loading="loading"
                      size="x-large"
                      style="width: 100%"
                      @click="logout()"
                      ><v-icon> mdi-logout </v-icon>Đăng xuất</v-btn
                    >
                  </a>
                </v-card>
              </v-menu>
            </v-btn>
          </div>
          <div
            v-else
            class="d-flex mt-2 ml-7"
            style="align-items: center; margin-right: 400px; margin-bottom: 10px;"
          >
            <router-link to="/login" class="account-link">
              <v-btn variant="outlined" class="ma-2"> Đăng nhập </v-btn>
            </router-link>
            <router-link to="/register" class="account-link">
              <v-btn variant="flat" color="black"> Đăng ký </v-btn>
            </router-link>
          </div>
        </div>
      </v-app-bar>

      <v-main> </v-main>
    </v-layout>
  </v-card>
</template>

<script>
import { authApi } from '../../apis/Auth/authApi'
import { computed } from 'vue';
import eventBus from '../../plugins/eventBus'
export default {
  data() {
    return {
      dialogVisible: false,
      authenticationApi: authApi(),
      userInfo: localStorage.getItem("userInfo")
        ? JSON.parse(localStorage.getItem("userInfo"))
        : null,
      menu: false,
      user:{},
      quantityCart: 0,
    };
  },
  setup() {
    const quantityCart = computed(() => eventBus.quantityCart || 0);
    return { quantityCart };
  },
  methods: {
    logout() {
      localStorage.removeItem("accessToken");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("userInfo");
    },
  },
  async mounted() {
    const valueReturn = await this.authenticationApi.getUserById(this.userInfo.Id)
    console.log(this.userInfo)
    const result = valueReturn.data
    this.user = result.dataResponseUser
    if(this.userInfo){
      setTimeout(() => {
      localStorage.removeItem("accessToken");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("userInfo");
      location.reload()
    }, 3600000)
    }

  },
};
</script>

<style lang="css" scoped>
.set-app-bar {
  display: flex;
  justify-content: space-evenly;
  padding: 0 400px;
}
.search {
  align-items: center;
}
.search-input-item {
  border: none;
}

.search-input-item:focus {
  outline: none;
}
.menu-item {
  padding: 0 30px;
  font-size: 16px;
}
.menu-item .item {
  margin-right: 14px;
}
.user-header-link {
  text-decoration: none;
}
.user-list-item:hover {
  color: blueviolet;
}
.account-link {
  color: black;
}
#header-course {
  height: 72px;
  /* background-color: rgb(255, 255, 255); */
  background: transparent;
  backdrop-filter: blur(40px);
  box-shadow: rgba(50, 50, 93, 0.25) 0px 2px 5px -1px,
    rgba(0, 0, 0, 0.3) 0px 1px 3px -1px;
  padding: 0 40px;
  position: fixed;
  width: 100%;
  z-index: 999;
}
.logo-header {
  line-height: 72px;
  background-color: rgb(226, 226, 226);
  border: none;
}
.search-header {
  padding-left: 20px;

  border: 1px rgb(61, 60, 60) solid;
  margin: 0 40px;
  border-radius: 40px;
  line-height: 45px;
}
.search-header input {
  width: 420px;
  display: block;
}
.search-input-item {
  border: none;

  margin-left: 20px;
}
.search-input-item:focus {
  outline: none;
}
.header-left .my-course:hover {
  cursor: pointer;
}
.header-left .my-infor:hover {
  cursor: pointer;
}
.my-infor {
  margin-left: 40px;
}
.dropdownmenu li {
  display: block;
}
.dropdownmenu li a {
  text-decoration: none;
  color: black;
}
#submenu {
  /* left: 0; */
  opacity: 0;
  position: absolute;
  top: 0px;
  visibility: hidden;
  z-index: 1;
}
.dropdownmenu li:hover ul#submenu {
  opacity: 1;
  top: 40px;
  visibility: visible;
}
.type-menu {
  position: absolute;
}
.hover-course-me {
  padding: 10px;
  border: 1px solid rgb(196, 196, 196);
  margin-top: 24px;
  width: 300px;
  border-radius: 3px;
  display: none;
  color: black;
  z-index: 6;
  background: white;
  box-shadow: 1px 1px 4px 1px rgb(205, 205, 205);
}
.hover-teaching {
  padding: 10px;
  border: 1px solid rgb(196, 196, 196);
  margin-top: 24px;
  width: 300px;
  border-radius: 3px;
  color: black;
  display: none;
  z-index: 6;
  background: white;
  box-shadow: 1px 1px 4px 1px rgb(205, 205, 205);
}
.teaching-header:hover .hover-teaching {
  display: block;
}
.teaching-header:hover {
  color: blueviolet;
}
.teaching-header {
  position: absolute;
}
.course-me:hover {
  color: blueviolet;
}
.course-me:hover .hover-course-me {
  display: block;
}
.course-me {
  position: absolute;
}
.cart-header {
  position: absolute;
}
.hover-cart {
  padding: 10px;
  border: 1px solid rgb(196, 196, 196);
  margin-top: 12px;
  width: 300px;
  border-radius: 3px;
  left: 0;
  color: black;
  display: none;
  z-index: 6;
  background: white;
  box-shadow: 1px 1px 4px 1px rgb(205, 205, 205);
}
.cart-header:hover {
  color: blueviolet;
}
.cart-header:hover .hover-cart {
  display: block;
}
.text-type-link {
  text-decoration: none;
  color: black;
}
.text-type-link:hover {
  color: blueviolet;
}
.header-content-user-link {
  text-decoration: none;
  color: black;
}
.header-content-user-link:hover {
  color: blueviolet;
}
.number-cart{
  position: absolute;
  padding: 4px 8px;
  border-radius: 4px;
  background-color: red;
  color: white;
  right: -12px;
  top: -6px;
}
</style>
