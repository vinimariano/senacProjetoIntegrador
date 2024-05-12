<template>
  <div>
    <div id="nav">
      <router-link id="logo-url" :to="{ name: 'home' }">
        <img id="logo" :src="logo" />
      </router-link>
      <div v-if="permission === 'administrador'">
        <router-link to="/manager">Produtos</router-link>
        <router-link to="/manager/orders">Pedidos</router-link>
      </div>
      <div v-else-if="permission === 'atendente'">
        <router-link to="/attendant/home">Produtos</router-link>
        <router-link to="/attendant/cart">Carrinho</router-link>
        <router-link to="/attendant/orders">Pedidos</router-link>
      </div>
      <div v-else>
        <router-link to="/cart">Carrinho</router-link>
        <router-link to="/products">Produtos</router-link>
        <router-link to="/orders">Pedidos</router-link>
      </div>
      <router-link @click="logout" to="/">Sair</router-link>
    </div>
  </div>
</template>

<script setup>
import { computed } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const permission = localStorage.getItem("permission");

const logo = permission === "administrador" || permission === 'atendente' ? "../src/assets/logo.png" : "src/assets/logo.png"

const logout = () => {
  localStorage.clear();
};
</script>

<style scoped>
#nav {
  background-color: #9758a6;
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
  color: white;
  text-decoration: none;
  margin: 12px;
  transition: 0.5s;
}

#nav a:hover {
  color: #ba95ed;
}
</style>
