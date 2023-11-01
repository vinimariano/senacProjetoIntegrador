<template>
  <Banner />
  <div class="container">
  <h1 id='title' >OFERTAS</h1>
    <div class="burgers">
    <span  v-for="burger in hamburgers">
       <Card :name="burger.name" :price="burger.price" :image="burger.img" />
    </span>
    </div>
  </div>
</template>

<script setup>
import Banner from "../components/Banner.vue";
import Card from "../components/Card.vue";

const hamburgers = [
  { name: "Classic Burger", price: 7.99, img:"/src/assets/burger5.png" },
  { name: "Cheeseburger", price: 8.99, img:"/src/assets/burger1.png" },
  { name: "Bacon Burger", price: 9.99, img:"/src/assets/burger2.png"  },
  { name: "Veggie Burger", price: 6.99, img:"/src/assets/burger6.png"  },
  { name: "Double Cheeseburger", price: 10.99, img:"/src/assets/burger4.png"  },
];

</script>

<style>
.burgers {
  margin-top: -1em;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between; 
}

#title {
  -webkit-text-stroke: 2px #9758A6; /* Define a largura e a cor do contorno */
  color: transparent; /* Torna o preenchimento do texto transparente */
}

.container {
  margin-top: 5em;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center
}

@media (max-width: 750px) {
  .burgers {
    justify-content: center
  }
}

</style>
