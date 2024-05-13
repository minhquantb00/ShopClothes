import axiosIns from "../../plugins/axios";
import { defineStore } from "pinia";

const CONTROLLER_NAME = "Product";

export const productApi = defineStore("productApi", {
  actions: {
    getAllProducts(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .get(`User/GetAllProducts`, { ...params })
          .then((res) => {
            resolve(res);
          })
          .catch((error) => {
            reject(error);
          });
      });
    },
  },
});
