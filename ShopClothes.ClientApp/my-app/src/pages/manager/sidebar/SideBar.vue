<template>
  <v-card
    style="height: 100%; border-radius: 0"
    color="grey-lighten-3"
    max-width="100%"
  >
    <v-layout style="height: 100%; justify-content: space-between">
      <v-app-bar prominent>
        <div
          style="
            display: flex;
            justify-content: space-between !important;
            align-items: center;
            width: 100%;
          "
        >
          <div class="d-flex">
            <v-app-bar-nav-icon
              variant="text"
              style="height: 63px"
              @click.stop="drawer = !drawer"
            ></v-app-bar-nav-icon>

            <v-toolbar-title>
              <router-link to="/admin">
                <img
                  src="../../../../src/assets/image-removebg-preview (1).png"
                  style="width: 200px; margin-right: 100px"
                />
              </router-link>
            </v-toolbar-title>
          </div>

          <div>
            <div
              v-if="userInfo"
              style="width: 100%; margin-right: 200px; margin-bottom: 4px"
            >
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
                      <v-avatar size="50" :image="user.avatarUrl"></v-avatar>
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

                    <v-list-item style="cursor: pointer">
                      <v-title> Thông báo </v-title>
                      <template v-slot:append>
                        <v-badge color="purple" content="0" inline></v-badge>
                      </template>
                    </v-list-item>
                    <v-list-item style="cursor: pointer">
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
          </div>
        </div>
      </v-app-bar>

      <v-navigation-drawer
        v-model="drawer"
        :location="$vuetify.display.mobile ? 'bottom' : undefined"
        temporary
        style="height: 100%"
      >
        <!-- <v-list :items="items"></v-list> -->
        <v-list style="padding: 0" v-for="item in items" :key="item">
          <div class="item-nav">
            <v-list-item>
              <div class="d-flex align-items-center;" style="cursor:pointer">
                <v-icon class="mr-4">{{ item.icon }}</v-icon>
                <h5 style="margin-bottom: 0">{{ item.title }}</h5>
              </div>
            </v-list-item>
          </div>
        </v-list>
      </v-navigation-drawer>

      <v-main style="height: 100%"> </v-main>
    </v-layout>
  </v-card>
</template>

<script>
import { authApi } from "../../../apis/Auth/authApi";
export default {
  data: () => ({
    drawer: false,
    group: null,
    user: {},
    menu: false,
    authenticationApi: authApi(),
    userInfo: localStorage.getItem("userInfo")
      ? JSON.parse(localStorage.getItem("userInfo"))
      : null,
    items: [
      {
        icon: "mdi-warehouse",
        title: "Quản lý kho hàng",
        value: "foo",
      },
      {
        icon: "mdi-tshirt-crew",
        title: "Quản lý sản phẩm",
        value: "bar",
      },
      {
        icon: "mdi-truck-delivery",
        title: "Quản lý giao hàng",
        value: "fizz",
      },
      {
        icon: "mdi-account-settings",
        title: "Quản lý nhân viên",
        value: "buzz",
      },
    ],
  }),
  methods: {
    logout() {
      localStorage.removeItem("accessToken");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("userInfo");
    },
  },
  async mounted() {
    console.log(this.userInfo);
    const valueReturn = await this.authenticationApi.getUserById(
      this.userInfo.Id
    );
    const result = valueReturn.data;
    this.user = result.dataResponseUser;
    if (this.userInfo) {
      setTimeout(() => {
        localStorage.removeItem("accessToken");
        localStorage.removeItem("refreshToken");
        localStorage.removeItem("userInfo");
        location.reload();
      }, 3600000);
    }
  },

  watch: {
    group() {
      this.drawer = false;
    },
  },
};
</script>

<style scoped>
.item-nav{
  padding: 12px 4px;
}
.item-nav:hover{
  background-color: rgb(185, 184, 184);
}
</style>
