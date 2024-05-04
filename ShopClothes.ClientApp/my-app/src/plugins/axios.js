import router from "../router/index";
import axios from "axios";

const axiosIns = axios.create({
  baseURL: 'https://localhost:7048/api/',
  headers: {
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
    },
})

axiosIns.interceptors.request.use(config => {
  const token =localStorage.getItem('accessToken')
  if(token){
      config.headers = config.headers || {}
      config.headers.Authorization = token ? `Bearer ${token}` : ''
  }

  return config
})

axiosIns.interceptors.response.use(response => {
  return response
}, error => {
  if(error.response?.status === 401){
      localStorage.removeItem('userData')
      localStorage.removeItem('accessToken')
      localStorage.removeItem('userAbilities')

      router.push('/login')
  }
  else{
      return Promise.reject(error)
  }
})
export default axiosIns
