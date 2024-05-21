import axiosIns from "../../plugins/axios";
import { defineStore } from "pinia";


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
    getProductById(id){
      return new Promise((resolve, reject) => {
        axiosIns
          .get(`User/GetProductById/${id}`)
          .then((res) => {
            resolve(res);
          })
          .catch((error) => {
            reject(error)
          })
      })
    }
  },
});
