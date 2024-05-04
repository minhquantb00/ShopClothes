import axiosIns from "../../plugins/axios";
import { defineStore } from "pinia";

const CONTROLLER_NAME = "Auth";

export const authApi = defineStore("authApi", {
  actions: {
    register(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .post(`Auth/Register`,
                  {...params,},
                  {
                    headers: {
                      "Content-Type": "multipart/form-data",
                    },
                  }
                )
          .then((res) => {
            resolve(res.data.data);
          })
          .catch((err) => {
            reject(err);
          });
      });
    },

    login(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .post(`Auth/Login`, {
            ...params,
          })
          .then((res) => {
            resolve(res.data.data);
          })
          .catch((error) => {
            reject(error);
          });
      });
    },

    authenticateUser(params){
      return new Promise((resolve, reject) => {
        axiosIns.
            put(`Auth/AuthenticateUser`, {...params})
            .then((res) => {
              resolve(res.data.data)
            })
            .catch((error) => {
              reject(error)
            })
      })
    }
  },
});
