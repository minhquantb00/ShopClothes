<template>
  <div>
    <home-header
      style="position: fixed; top: 0; right: 0; left: 0; z-index: 10"
    />
    <div id="register">
      <v-card
          class="form-register text-white mx-auto"
          title="Vui lòng đăng nhập tại đây!"
        >
          <v-container class="set-index">
            <v-label class="input-label">Tài khoản</v-label>
            <v-text-field
              v-model="inputLogin.userName"
              :rules="taiKhoanRules"
              color="primary"
              placeholder="Tài khoản"
              variant="underlined"
            ></v-text-field>
            <v-label class="input-label">Mật khẩu</v-label>
            <v-text-field
              v-model="inputLogin.password"
              color="primary"
              :rules="passwordRules"
              placeholder="Mật khẩu"
              :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
              :type="visible ? 'text' : 'password'"
              @click:append-inner="visible = !visible"
              @keydown.enter="login"
              variant="underlined"
            ></v-text-field>
            <v-checkbox v-model="terms" color="primary" label="Nhớ mật khẩu" />
          </v-container>

          <v-card-actions class="card-action-item">
            <v-btn color="success" :loading="loading" @click="login">
              Đăng nhập
              <v-icon icon="mdi-chevron-right" end></v-icon>
            </v-btn>
          </v-card-actions>

          <v-card-text class="text-center">
            <span class="mr-3">Bạn chưa có tài khoản?</span>
            <v-btn
              color="success"
              @click="
                () => {
                  router.push({ path: '/register' });
                }
              "
              >Đăng ký</v-btn
            >
          </v-card-text>
        </v-card>
    </div>
    <home-footer style="margin-top: 40px; position:absolute; bottom: 0; right: 0; left: 0" />
  </div>
</template>
<script>
import { useRouter } from "vue-router";
import { authApi } from "../../apis/Auth/authApi";
import mitt from "mitt";
import HomeHeader from "@/views/homeItem/HomeHeader.vue";
import HomeFooter from "@/views/homeItem/HomeFooter.vue";
export default {
  components: { HomeHeader, HomeFooter },
  data() {
    return {
      visible: false,
      inputLogin: {
        userName: "",
        password: "",
      },
      emitter: mitt(),
      error: {
        errorCheck: false,
        errorMessage: "",
      },
      terms: false,
      authenticateApi: authApi(),
      router: useRouter(),
      loading: false,
      taiKhoanRules: [
        (value) => {
          if (value) return true;
          return "Bạn phải điền tên tài khoản";
        },
      ],
      passwordRules: [
        (value) => {
          if (value) return true;

          return "Mật khẩu là bắt buộc!";
        },
      ],
    };
  },
  methods: {
    async login() {
      try {
        this.loading = true;
        const result = await this.authenticateApi.login(this.inputLogin);
        if (result.status === 200) {
          this.emitter.emit("showAlert", {
            type: "success",
            content: "Đăng nhập thành công",
          });
          if (!localStorage.getItem("accessToken")) {
            const resultToken = result.data;
            const resultEnd = resultToken.data
            localStorage.setItem("accessToken", resultEnd.accessToken);
            localStorage.setItem("refreshToken", resultEnd.refreshToken);
            const accessToken = localStorage.getItem("accessToken");
            let decoded = this.parseJwt(accessToken);

            localStorage.setItem("userInfo", JSON.stringify(decoded));
            const userInfo = JSON.parse(localStorage.getItem("userInfo"))
          }
          this.loading = true
          const userInfo = JSON.parse(localStorage.getItem("userInfo"))

          if(userInfo.Permission.includes("Admin")){
            this.router.push({ path: "/admin" });
          }
          else{
            this.router.push({ path: "/" });
          }

        } else {
          const alert = {
            type: "error",
            content: "Đăng nhập thất bại",
          };

          this.emitter.emit("showAlert", alert);
          this.loading = false
        }
      } catch {
        this.loading = false;
        const alert = {
          type: "error",
          content: "Lỗi server",
        };

        this.emitter.emit("showAlert", alert);
      }
    },
   parseJwt(token) {
      var base64Url = token.split(".")[1];
      var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
      var jsonPayload = decodeURIComponent(
        window
          .atob(base64)
          .split("")
          .map(function (c) {
            return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
          })
          .join("")
      );
      return JSON.parse(jsonPayload);
    },
  },
  mounted() {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("userInfo");
  },
};
</script>

<style scoped>
#register {
  width: 100%;
  height: 40%;
}
.main-register {
  width: 100%;
  height: 100%;
  z-index: 3;
  align-items: center;
  position: absolute;
  top: 0;
}
.form-register {
  width: 30%;
  border-radius: 40px;
  padding: 20px;
  background-color: black;
  box-shadow: 0 0 10px rgba(255, 255, 255, 0.5);
  height: 100%;
  margin-top: 200px;
}
.card-action-item {
  justify-content: space-evenly;
}
</style>
