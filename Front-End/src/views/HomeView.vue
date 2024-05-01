<template>
  <Banner />
  <div class="container">
    <h1 id="title">RECOMENDAÇÕES</h1>
    <div class="burgers">
      <Card v-for="burger in sugestions" :id="burger.id" :nome="burger.nome" :preco="burger.preco"
        :caminhoImagem="burger.caminhoImagem" :descricao="burger.descricao" />
    </div>
    <h1 id="title">CARDÁPIO</h1>
    <div class="burgers">
      <Card v-for="burger in hamburgers" :id="burger.id" :nome="burger.nome" :preco="burger.preco"
        :caminhoImagem="burger.caminhoImagem" :descricao="burger.descricao" />
    </div>
  </div>
</template>

<script setup>
import Banner from "../components/Banner.vue";
import Card from "../components/Card.vue";
import { BASEURL } from "../../env";
import { onBeforeMount, ref } from "vue";

const hamburgers = ref([]);
const sugestions = ref([])

onBeforeMount(async () => {
  hamburgers.value = await getBurgers();
  sugestions.value = await getSugestions()
});

async function getBurgers() {
  try {
    const response = await fetch(`${BASEURL}/api/Produto/List`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: localStorage.getItem("token"),
      },
    });

    if (response.ok) {
      const hamburgersData = await response.json();
      return hamburgersData;
    } else {
      console.error("Erro na solicitação GET. Código de status:", response.status);
      return [];
    }
  } catch (error) {
    console.error("Erro na solicitação GET:", error);
    return [];
  }
}
async function getSugestions() {
  try {
    const response = await fetch(`${BASEURL}/api/Produto/ListSuggestions`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: localStorage.getItem("token"),
      },
    });

    if (response.ok) {
      const sugestions = await response.json();
      return sugestions;
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

<style>
.burgers {
  margin-top: -1em;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
}

#title {
  -webkit-text-stroke: 2px #9758a6;
  color: transparent;
}

.container {
  margin-top: 5em;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

@media (max-width: 750px) {
  .burgers {
    justify-content: center;
  }
}
</style>
