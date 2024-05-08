<template>
  <div class="containers">
    <div class="burger">
      <img id="image" :src="caminhoImagem" alt="Burger Image" />
      <div class="name-price">
        <h1 id="title">{{ nome }}</h1>
        <h6 id="description">{{ descricao }}</h6>
        <h1 id="price">R$:{{ preco }},00</h1>
      </div>
    </div>
    <button class="button" @click="removeItem(props)">Remover</button>
  </div>
</template>

<script setup>
import burger from "@/assets/burger.jpg";

const props = defineProps(["nome", "preco", "caminhoImagem", "descricao", "onRemove"]);

function removeItem(item) {
  props.onRemove(item);
}
</script>

<style scoped>
.containers {
  border-radius: 20px;
  width: 80vw;
  margin: 1em;
  background-color: white;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center
}

.button {
  margin-right: 2em;
  margin-top: 1em;
  height: 4em;
  font-size: 15px;
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

.name-price {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}

.burger {
  display: flex;
  flex-direction: row;
  align-items: center;
}

#title {
  color: #9758a6;
  margin-bottom: .3em;
}

#price {
  color: grey;
}

#description {
  color: grey;
  margin-top: .1em;
  margin-bottom: 1em;
  font-size: 12px;
}

#image {
  padding: 1em;
  height: 200px;
  width: 200px;
}

@media (max-width: 800px) {
  #image {
    width: 120px;
    margin: 1em;
  }

  #title,
  #price {
    font-size: 20px;
    margin-bottom: .5em;
  }
}

@media (max-width: 600px) {

  .burger {
    width: 100%;

  }

  .containers {
    border-radius: 20px;
    margin: 1em;
    background-color: white;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center
  }

  .name-price {
    margin-top: 1em;
    display: flex;
    align-items: flex-start;

  }

  #title,
  #price {
    font-size: 20px;
    margin: 0;
  }

  #image {
    margin: 0;
    width: 100px;
    height: 100px;
  }

  .button {
    padding: 0;
    width: 90%;
    margin-left: 2em;
    margin-bottom: 1em;
    height: 3em;
  }

}
</style>
