<template>
  <div class="burger-card">
    <div class="burger-image">
      <img :src="image" alt="Burger Image" />
    </div>
    <div class="burger-details">
      <h2>{{ name }}</h2>
      <h4>Preço: R$ {{ price }}</h4>
      <button @click="addCart">Adicionar ao carrinho</button>
    </div>
  </div>
</template>

<script>
import VueToast from "vue-toast-notification";
import "vue-toast-notification/dist/theme-sugar.css";

export default {
  name: "Card",
  props: {
    name: String,
    price: Number,
    image: String,
  },

  methods: {
    addCart() {
      const item = {
        name: this.name,
        price: this.price,
        image: this.image,
      };

      let carrinho = JSON.parse(localStorage.getItem("carrinho")) || [];

      carrinho.push(item);

      localStorage.setItem("carrinho", JSON.stringify(carrinho));

      this.$swal({
        title: "Produto adicionado com sucesso ao carrinho",
        showCancelButton: true,
        confirmButtonText: "Continuar comprando",
        cancelButtonText: "Ver carrinho",
      }).then((result) => {
        if (result.isConfirmed) {
          // Lógica para continuar comprando
        } else if (result.dismiss === "cancel") {
          this.$router.push("/cart");
        }
      });
    },
  },
};
</script>

<style scoped>
.burger-card {
  background-color: #f7f7f7;
  flex: 1;
  border: 1px solid #ccc;
  border-radius: 5px;
  display: flex;
  flex-direction: column;
  margin: 1em 0.5em;
  padding: 1em 10px;
  min-width: 300px;
  max-width: 22vw;
}

.burger-image img {
  width: 100%;
  height: auto;
  margin-bottom: 10px;
}

.burger-details {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: center;
  text-align: center;
}

button {
  font-size: 17px;
  background-color: #9758a6;
  color: #fff;
  border: none;
  padding: 15px;
  border-radius: 5px;
  cursor: pointer;
  margin-top: 10px;
  width: 100%;
}

button:hover {
  background-color: #9758f1;
}

@media (max-width: 1500px) {
  .burger-card {
    min-width: 40vw;
    max-width: 40vw;
  }
}

@media (max-width: 750px) {
  .burger-card {
    min-width: 80vw;
    max-width: 80vw;
  }
}
</style>
