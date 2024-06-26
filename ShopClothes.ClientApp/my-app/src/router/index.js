import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: '/register',
    name: 'register',
    component: () => import('../pages/auth/Register.vue')
  },
  {
    path: '/authenticate-user',
    name: 'authenticate-user',
    component: () => import('../pages/auth/AuthenticateUser.vue')
  },
  {
    path: '/login',
    name: 'login',
    component: () => import('../pages/auth/Login.vue')
  },
  {
    path: '/',
    name: 'home',
    component: () => import('../pages/home/Home.vue')
  },
  {
    path: '/product-detail/:id',
    name: 'product-detail',
    component: () => import('../views/homeItem/homeDescription/HomeProductDetail.vue')
  },
  {
    path: '/admin',
    name: 'admin',
    component: () => import('../pages/manager/HomeManager.vue')
  },
  {
    path: '/product-management',
    name: 'product-management',
    component:() => import('../pages/manager/productManagement/ProductManagement.vue')
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
