<template>
  <div class="container">
    <div class="burger">
      <img id="image" :src="props.image" alt="Burger Image" />
      <div class="name-price">
        <h1 id="title">{{ props.name }}</h1>
        <h1 id="price">R$: {{ props.price }}</h1>
      </div>
    </div>
    <button class="button" @click="login">Remover</button>
  </div>
</template>

<script>
import burger from "@/assets/burger.jpg";
export default {
  name: "productCart",
  props: {
    name: String,
    price: Number,
    image: String,
  },
  data(props) {
    return {
      burger: burger,
      props,
    };
  },
};
</script>

<style scoped>
.container {
  border-radius: 20px;
  width: 90vw;
  margin: 1em;
  background-color: #f7f7f7;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.button {
  margin-right: 2em;
  margin-top: 1em;
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
}

#price {
  color: grey;
}

#image {
  padding: 1em;
}

@media (max-width: 660px) {
  #image {
    width: 150px;
  }

  #title,
  #price {
    font-size: 20px;
  }
}

@media (max-width: 500px) {
  #title,
  #price {
    font-size: 12px;
  }
  .button {
    margin-top: 1em;
    font-size: 12px;
    padding: 5px;
    cursor: pointer;
    margin-left: -1em;
  }
}
</style>
