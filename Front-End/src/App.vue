<template>
  <div class="body">
    <Navbar v-if="$route.path !== '/'" :logo="logo" :alt="app_name" />
    <div class="main-container">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import Navbar from "./components/Navbar.vue";
import logo from "@/assets/logo.png";
import { ref } from "vue";

export default {
  setup() {
    const app_name = "Code Burger";

    return {
      logo,
      app_name,
    };
  },
  components: {
    Navbar,
  },
};
</script>

<style>
* {
  font-family: Helvetica;
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

.body {
  background-color: #f7f7f7;
  min-height: 100vh;
}

.main-container {
  margin: 50px 50px 0 50px;
  min-height: 250px;
}

h1 {
  text-align: center;
  font-size: 42px;
  margin-bottom: 30px;
  color: #222;
}
</style>
