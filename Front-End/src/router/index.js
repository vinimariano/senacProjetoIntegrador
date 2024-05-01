import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import Cart from "../views/Cart.vue";
import Login from "../views/Login.vue";
import Manager from "../views/ManagerProducts.vue";
import ManagerOrders from "../views/ManagerOrders.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/products",
      name: "home",
      beforeEnter: (to, from, next) => {
        const userToken = localStorage.getItem("token");
        if (userToken) {
          next();
        } else {
          next({ name: "login" });
        }
      },
      component: HomeView,
    },
    {
      path: "/",
      name: "login",
      component: Login,
    },
    {
      path: "/cart",
      name: "cart",
      beforeEnter: (to, from, next) => {
        const userToken = localStorage.getItem("token");
        if (userToken) {
          next();
        } else {
          next({ name: "login" });
        }
      },
      beforeEnter: (to, from, next) => {
        const userToken = localStorage.getItem("token");
        if (userToken) {
          next();
        } else {
          next({ name: "login" });
        }
      },
      component: Cart,
    },
    {
      path: "/manager",
      name: "manager",
      beforeEnter: (to, from, next) => {
        const userToken = localStorage.getItem("token");
        if (userToken) {
          next();
        } else {
          next({ name: "manager" });
        }
      },
      beforeEnter: (to, from, next) => {
        const userToken = localStorage.getItem("token");
        if (userToken) {
          next();
        } else {
          next({ name: "login" });
        }
      },
      component: Manager,
    },
    {
      path: "/manager/orders",
      name: "managerOrders",
      beforeEnter: (to, from, next) => {
        const userToken = localStorage.getItem("token");
        if (userToken) {
          next();
        } else {
          next({ name: "manager" });
        }
      },
      beforeEnter: (to, from, next) => {
        const userToken = localStorage.getItem("token");
        if (userToken) {
          next();
        } else {
          next({ name: "login" });
        }
      },
      component: ManagerOrders,
    },
  ],
});

export default router;
