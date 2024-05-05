<template>
  <v-card style="border-radius: 0" color="grey-lighten-3" max-width="100%">
    <v-layout >
      <v-app-bar class="set-app-bar" color="black">
        <template v-slot:prepend>
          <v-app-bar-nav-icon></v-app-bar-nav-icon>
        </template>

        <v-app-bar-title>MyBugsShop</v-app-bar-title>

        <v-spacer></v-spacer>
        <div class="d-flex" style="margin-right: 400px; padding: 0 80px">
          <v-btn text class="menu-item">
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
        <div style="margin-right: 300px;">
          <v-btn class="search" icon>
            <v-icon>mdi-magnify</v-icon>
            <input
              class="search-input-item"
              type="text"
              placeholder="Tìm kiếm từ khóa"
            />
          </v-btn>
  
          <v-btn icon>
            <v-icon>mdi-heart</v-icon>
          </v-btn>
  
          <v-btn icon>
            <v-icon>mdi-dots-vertical</v-icon>
          </v-btn>
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
  padding: 0 300px;
}
.search {
  margin-right: 40px;
}
.search-input-item {
  border: none;

  margin-left: 20px;
}

.search-input-item:focus {
  outline: none;
}
.menu-item{
  padding: 0 40px;
}
.menu-item .item{
  margin-right: 14px;
}
</style>
