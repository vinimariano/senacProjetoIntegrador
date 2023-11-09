import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Cart from "../views/Cart.vue"
import Login from "../views/Login.vue"

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/products',
      name: 'home',
      beforeEnter: (to, from, next) => {
        const userToken = localStorage.getItem('token');
        if (userToken) {
          next();
        } else {
          next({ name: 'login' });
        }
      },
      component: HomeView
    },
    {
      path: '/',
      name: 'login',
      component: Login
    },
    {
      path: '/cart',
      name: 'cart',
      beforeEnter: (to, from, next) => {
        const userToken = localStorage.getItem('token');
        if (userToken) {
          next();
        } else {
          next({ name: 'login' });
        }
      },      beforeEnter: (to, from, next) => {
        const userToken = localStorage.getItem('token');
        if (userToken) {
          next();
        } else {
          next({ name: 'login' });
        }
      },
      component: Cart
    }
  ]
})

export default router
