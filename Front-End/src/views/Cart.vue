<template>
  <Banner />
  <div v-if="!created" class="container">
    <div v-for="product in products" :key="product.id">
      <div class="products">
        <ProductCart
          :nome="product.nome"
          :preco="product.preco"
          :caminhoImagem="product.caminhoImagem"
          :descricao="product.descricao"
          :onRemove="() => removeItem(product)"
        />
      </div>
    </div>
    <button v-if="products" class="button" @click="createOrder">
      Finalizar pedido {{ `$ ${calculateTotal()}` }}
    </button>
    <div class="container" v-else>
      <span id="created">"Seu carrinho esta vazio"</span>
      <button @click="goToHome" class="button">Voltar para Home</button>
    </div>
  </div>
  <div class="container" v-else>
    <span id="created"
      >Pedido criado com sucesso!
      <button @click="goToHome" class="button">Voltar para Home</button>
    </span>
  </div>
</template>

<script setup>
import { ref } from "vue";
import Banner from "../components/Banner.vue";
import ProductCart from "../components/ProductCart.vue";
import { BASEURL } from "../../env";
import VueToast from "vue-toast-notification";
import "vue-toast-notification/dist/theme-sugar.css";
import { useRouter } from "vue-router";

const router = useRouter();

const products = ref(JSON.parse(localStorage.getItem("carrinho")));

const created = ref(false);

function removeItem(itemToRemove) {
  const index = products.value.findIndex((product) => product.id === itemToRemove.id);

  if (index !== -1) {
    products.value.splice(index, 1);
  }
  localStorage.setItem("carrinho", JSON.stringify(products.value));
}

async function createOrder() {
  const body = {
    produtos: products.value,
    total: calculateTotal(),
  };
  try {
    const response = await fetch(`${BASEURL}/api/Pedido`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: localStorage.getItem("token"),
      },
      body: JSON.stringify(body),
    });

    if (response.ok) {
      created.value = true;
      localStorage.removeItem("carrinho");
    } else {
      console.error("Erro na solicitação POST. Código de status:", response.status);
    }
  } catch (error) {
    console.error("Erro na solicitação POST:", error);
  }
}

function calculateTotal() {
  return products?.value?.reduce((total, product) => total + product.preco, 0);
}

function goToHome() {
  created.value = false;
  router.push("/products");
}
</script>

<style scoped>
#container {
  display: flex;
  flex-direction: column;
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

#created {
  font-size: 25px;
  color: #9758a6;
  text-align: center;
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
