<template>
  <Banner />
  <div class="container">
    <div class="header-page">
      <h1 id="title">PEDIDOS</h1>
    </div>
    <div class="orders">
      <Orders v-for="order in orders" :order="order" />
    </div>
  </div>
</template>

<script setup>
import Banner from "../components/Banner.vue";
import { BASEURL } from "../../env";
import { onBeforeMount, ref } from "vue";
import Orders from "../components/Orders.vue"

const orders = ref([]);

onBeforeMount(async () => {
  orders.value = await getBurgers();
});

async function getBurgers() {
  try {
    const response = await fetch(`${BASEURL}/api/Pedido/List`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: localStorage.getItem("token"),
      },
    });

    if (response.ok) {
      const orders = await response.json();
      return orders;
    } else {
      console.error("Erro na solicitação GET. Código de status:", response.status);
      return [];
    }
  } catch (error) {
    console.error("Erro na solicitação GET:", error);
    return [];
  }
}

</script>

<style scoped>
.loading-overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(255, 255, 255, 0.8);
  display: flex;
  justify-content: center;
  align-items: center;
}

.orders {
  margin-top: -1em;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
}

.header-page {
  display: flex;
  width: 100%;
  flex-direction: row;
  justify-content: center;
  align-items: center;
}

#title {
  -webkit-text-stroke: 2px #9758a6;
  color: transparent;
  padding-top: 1em;
}

/* Estilos do spinner de loading */
.loading-spinner {
  border: 4px solid rgba(0, 0, 0, 0.1);
  border-left-color: #333;
  border-radius: 50%;
  width: 50px;
  height: 50px;
  animation: spin 1s linear infinite;
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }

  100% {
    transform: rotate(360deg);
  }
}

@media (max-width: 650px) {
  .header-page {
    display: flex;
    width: 100%;
    flex-direction: column;
  }

  #title {
    margin-bottom: -.2em;
  }

  .orders {
    margin-top: 1em;
  }
}
</style>
