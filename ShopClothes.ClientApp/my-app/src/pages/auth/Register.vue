<template>
  <div id="register">
    <div class="background-register"></div>
    <div class="background-opacity"></div>
    <div
      class="main-register d-flex justify-content-evenly align-items-center"
    >
      <v-card
        class="form-register text-white mx-auto"
        title="Vui lòng đăng ký tài khoản"
        style="margin: 80px 0"
      >
        <v-container class="set-index">
          <v-label class="input-label">Tài khoản</v-label>
          <v-text-field
            v-model="inputRegister.userName"
            color="primary"
            placeholder="Tài khoản"
            variant="underlined"
          ></v-text-field>
          <v-label class="input-label">Họ và tên</v-label>
          <v-text-field
            v-model="inputRegister.fullName"
            placeholder="Họ và tên"
            color="primary"
            variant="underlined"
          ></v-text-field>
          <v-label class="input-label">Email</v-label>
          <v-text-field
            v-model="inputRegister.email"
            placeholder="Email"
            color="primary"
            variant="underlined"
          ></v-text-field>
          <v-label class="input-label">Mật khẩu</v-label>
          <v-text-field
            v-model="inputRegister.password"
            :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
            :type="visible ? 'text' : 'password'"
            color="primary"
            placeholder="Mật khẩu"
            variant="underlined"
            @click:append-inner="visible = !visible"
          ></v-text-field>
          <v-label class="input-label">Số điện thoại</v-label>
          <v-text-field
            v-model="inputRegister.phoneNumber"
            color="primary"
            placeholder="Số điện thoại"
            variant="underlined"
          ></v-text-field>
          <v-label class="input-label" style="margin-bottom: 10px"
            >Giới tính</v-label
          >
          <v-select
            v-model="inputRegister.gender"
            label="Chọn giới tính"
            :items="['Male', 'Female']"
          ></v-select>
          <v-checkbox
            v-model="terms"
            color="primary"
            label="Bạn có đồng ý với điều khoản của chúng tôi?"
          />
        </v-container>

        <v-card-actions class="card-action-item">
          <v-btn color="success" @click="registerAccount">
            Đăng ký
            <v-icon icon="mdi-chevron-right" end></v-icon>
          </v-btn>
        </v-card-actions>

        <v-card-text class="text-center">
          <span class="mr-3">Bạn đã có tài khoản?</span>
          <v-btn
            color="success"
            @click="
              () => {
                router.push({ path: '/login' });
              }
            "
            >Đăng nhập</v-btn
          >
        </v-card-text>
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
      visible: false,
      isConfirm: false,
      confirmCode: "",
      authenticateApi: authApi(),
      router: useRouter(),
      loading: false,
      inputRegister: {
        userName: "",
        fullName: "",
        email: "",
        phoneNumber: "",
        password: "",
        gender: null,
      },
      terms: false,
    };
  },
  methods: {
    async registerAccount() {
      this.loading = true;
      const result = await this.authenticateApi.register(this.inputRegister);
      console.log(result)
      this.router.push({path: '/authenticate-user'})
    },

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
  top: 0;
}
.form-register {
  width: 30%;
  border-radius: 40px;
  padding: 20px;
  background-color: rgba(0, 0, 0, 0.75);
  box-shadow: 0 0 10px rgba(255, 255, 255, 0.5);
  height: 80%;
}
.set-index {
}
.card-action-item{
  justify-content: space-evenly;
}
</style>



