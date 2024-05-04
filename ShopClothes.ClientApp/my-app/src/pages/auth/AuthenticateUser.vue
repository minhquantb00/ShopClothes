<template>
  <div id="register">
    <div class="background-register"></div>
    <div class="background-opacity"></div>
    <div
      class="main-register d-flex justify-content-evenly align-items-center"
    >
      <v-card
        class="form-register text-white mx-auto"
        title="Vui lòng nhập mã xác nhận tại đây"
        style="margin: 80px 0"
      >
        <v-container class="set-index">
          <v-label class="input-label">Mã xác nhận</v-label>
          <v-text-field
            v-model="confirmCode"
            color="primary"
            placeholder="Mã xác nhận"
            variant="underlined"
          ></v-text-field>
        </v-container>

        <v-card-actions class="card-action-item">
          <v-btn color="success" @click="onConfirm">
            Xác nhận
            <v-icon icon="mdi-chevron-right" end></v-icon>
          </v-btn>
        </v-card-actions>
      </v-card>
    </div>
  </div>
</template>

<script>
import { useRouter } from "vue-router";
import { authApi } from "../../apis/Auth/authApi";
export default {
  data() {
    return {
      isConfirm: false,
      confirmCode: "",
      authenticateApi: authApi(),
      router: useRouter(),
      loading: false,
      terms: false,
    };
  },
  methods: {

    async onConfirm() {
      const params = {
        confirmCode: this.confirmCode,
      };
      await this.authenticateApi.authenticateUser(params);
      this.router.push({ path: "/login" });
    },
  },
};
</script>

<style scoped>
#register {
  width: 100%;
  height: 100%;
}
.background-register {
  background-image: url(https://www.freecodecamp.org/news/content/images/2022/09/jonatan-pie-3l3RwQdHRHg-unsplash.jpg);
  background-size: cover;
  background-repeat: no-repeat;
  width: 100%;
  height: 100%;
  position: relative;
  z-index: 1;
}
.background-opacity {
  background-color: black;
  width: 100%;
  height: 100%;
  opacity: 0.8;
  position: absolute;
  top: 0;
  z-index: 2;
}
.main-register {
  width: 100%;
  height: 100%;
  z-index: 3;
  position: absolute;
  align-items: center;
  top: 0;
}
.form-register {
  width: 30%;
  border-radius: 40px;
  padding: 20px;
  background-color: rgba(0, 0, 0, 0.75);
  box-shadow: 0 0 10px rgba(255, 255, 255, 0.5);
  height: 30%;
  margin: auto 0;
}
.set-index {
}
.card-action-item{
  justify-content: space-evenly;
}
</style>



