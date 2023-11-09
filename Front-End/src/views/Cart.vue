<template>
  <Banner />
  <div class="container">
    <div v-for="product in products">
      <div class="products">
        <ProductCart :name="product.name" :price="product.price" :image="product.image" />
      </div>
    </div>
    <button class="button" @click="login">Finalizar pedido</button>
  </div>
</template>

<script setup>
import Banner from "../components/Banner.vue";
import ProductCart from "../components/ProductCart.vue";

const products = JSON.parse(localStorage.getItem("carrinho"));

console.log(products);
</script>

<style scoped>
#container {
  display: flex;
  justify-content: flex-end;
  align-items: flex-end;
  margin-top: 2em;
}

.button {
  margin-top: 0.5em;
  font-size: 20px;
  background-color: #9758a6;
  color: white;
  border: none;
  border-radius: 5px;
  padding: 15px;
  cursor: pointer;
}

.button:hover {
  background-color: #8c4d9f;
}

@media (max-width: 660px) {
  .button {
    font-size: 15px;
  }
}
</style>
