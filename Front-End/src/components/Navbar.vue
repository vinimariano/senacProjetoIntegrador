<template>
  <div>
    <div id="nav">
      <router-link id="logo-url" to="/">
        <img id="logo" :src="logo" />
      </router-link>
      <router-link v-if="$route.path !== '/cart'" to="/cart">Ver carrinho</router-link>
      <router-link v-if="$route.path !== '/products'" to="/products"
        >Ver produtos</router-link
      >
      <router-link @click="logout" to="/">Sair</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "Navbar",
  props: {
    logo: String,
  },
  methods: {
    logout() {
      localStorage.clear();
    },
  },
};
</script>

<style scoped>
#nav {
  background-color: #fff;
  border-bottom: 4px solid #111;
  padding: 15px 50px;
  display: flex;
  justify-content: flex-end;
  align-items: center;
}

#nav #logo-url {
  margin: auto;
  margin-left: 0;
}

#logo {
  width: 40px;
  height: 40px;
}

#nav a {
  color: #9758a6;
  text-decoration: none;
  margin: 12px;
  transition: 0.5s;
}

#nav a:hover {
  color: #9758f1;
}
</style>
