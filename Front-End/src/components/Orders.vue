<template>
  <div class="order-card">
    <div class="header">
      <h3>Pedido {{ order.id }}</h3>
    </div>
    <div class="header">
      <h3>Feito por: {{ order.loginUsuario }}</h3>
    </div>
    <div class="header">
      <h3>Data: {{ formatdate(order.dataPedido) }}</h3>
    </div>
    <ul class="products" v-for="product in order.produtos">
      <li>{{ product.produto.nome }} - R$:{{ product.produto.preco }},00</li>
    </ul>
    <div class="total">
      <h2>Total: R$:{{ order.total }},00</h2>
    </div>
  </div>
</template>

<script setup>
import { ref, defineProps } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const props = defineProps(['order']);

function formatdate(dataString) {
  const data = new Date(dataString);

  const dia = String(data.getDate()).padStart(2, '0');
  const mes = String(data.getMonth() + 1).padStart(2, '0');
  const ano = data.getFullYear();

  const dataFormatada = `${dia}/${mes}/${ano}`;

  return dataFormatada
}

</script>

<style scoped>
.order-card {
  background-color: white;
  flex: 1;
  border: 1px solid #ccc;
  border-radius: 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
  margin: 1em 0.5em;
  padding: 1em 10px;
  min-width: 300px;
  max-width: 22vw;
}

.header {
  margin-bottom: 1em;
}

.total {
  border-top: 1px solid grey;
  margin-top: 1em;
  color: #9758a6;
  padding: 1em;
}

.products {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  text-align: center;
}



@media (max-width: 1500px) {
  .order-card {
    min-width: 20vw;
    max-width: 20vw;
  }
}

@media (max-width: 1000px) {
  .order-card {
    min-width: 35vw;
    max-width: 35vw;
  }
}

@media (max-width: 600px) {
  .order-card {
    min-width: 80vw;
    max-width: 80vw;
  }
}
</style>
