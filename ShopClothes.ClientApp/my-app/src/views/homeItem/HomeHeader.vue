<template>
  <v-card style="border-radius: 0;" color="grey-lighten-3" max-width="100%">
    <v-layout >
      <v-app-bar class="set-app-bar" color="white">
        <template v-slot:prepend>
          <v-app-bar-nav-icon></v-app-bar-nav-icon>
        </template>

        <div>
          <img src="../../assets/image-removebg-preview (1).png" style="width: 180px;"/>
        </div>

        <v-spacer></v-spacer>
        <div class="d-flex" style="margin-right: 50px;">
          <v-btn text class="menu-item" style="padding-left: 0;">
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
          <div class="search d-flex" style="font-size: 16px;">
            <v-btn  >
              <v-icon style="font-size: 16px;">mdi-magnify</v-icon>

            </v-btn>
            <input
                class="search-input-item"
                type="text"
                placeholder="Tìm kiếm từ khóa"
                style="font-size: 16px;"
              />
          </div>

          <div v-if="userInfo" style="width: 100%; margin-right: 400px;" >
            <v-btn style="margin-right: 20px; font-size: 16px;">
              <v-icon>mdi-heart</v-icon>
              <p style="margin-left: 10px; text-transform:capitalize;">Giỏ hàng</p>
            </v-btn>

            <v-btn icon>
              <!-- <v-icon>mdi-dots-vertical</v-icon> -->
              <div style="width: 40px; height: 40px; border-radius: 50%;">
                <!-- <img style="width: 100%; height: 100%; border-radius: 50%;" src="https://miro.medium.com/v2/resize:fit:1400/1*rKl56ixsC55cMAsO2aQhGQ@2x.jpeg"/> -->
                <v-avatar size="40" image="https://miro.medium.com/v2/resize:fit:1400/1*rKl56ixsC55cMAsO2aQhGQ@2x.jpeg"/>
              </div>
            </v-btn>
          </div>
          <div v-else class="d-flex align-items-center mt-2 ml-7">
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
export default {
  data() {
    return {
      dialogVisible: false,
      userInfo: localStorage.getItem("userInfo")
        ? JSON.parse(localStorage.getItem("userInfo"))
        : null,
    };
  },
};
</script>

<style lang="css" scoped>
.set-app-bar{
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
.menu-item{
  padding: 0 30px;
  font-size: 16px;
}
.menu-item .item{
  margin-right: 14px;
}
.account-link {
  color: black;
}
</style>
