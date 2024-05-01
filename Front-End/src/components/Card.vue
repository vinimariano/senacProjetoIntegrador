<template>
  <div class="burger-card">
    <div class="burger-image">
      <img :src="caminhoImagem" alt="Burger Image" />
    </div>
    <div class="burger-details">
      <h3>{{ nome }}</h3>
      <h4>Preço: R$: {{ preco }},00</h4>
      <button class="button" @click="addCart">Adicionar ao carrinho</button>
    </div>
  </div>
</template>

<script setup>
import { ref, defineProps } from 'vue';
import Swal from 'sweetalert2';
import { useRouter } from 'vue-router';
import Button from './Button.vue';

const router = useRouter();
const props = defineProps(['id', 'nome', 'preco', 'caminhoImagem', 'descricao']);

const nome = ref(props.nome);
const preco = ref(props.preco);
const caminhoImagem = ref(props.caminhoImagem);
const descricao = ref(props.descricao);

const addCart = () => {
  const item = {
    id: props.id,
    nome: nome.value,
    preco: preco.value,
    caminhoImagem: caminhoImagem.value,
    descricao: descricao.value,
  };


  let carrinho = JSON.parse(localStorage.getItem('carrinho')) || [];
  carrinho.push(item);
  localStorage.setItem('carrinho', JSON.stringify(carrinho));

  Swal.fire({
    title: 'Produto adicionado com sucesso ao carrinho',
    showCancelButton: true,
    confirmButtonText: 'Continuar comprando',
    cancelButtonText: 'Ver carrinho',
  }).then((result) => {
    if (result.isConfirmed) {
      // Continuar comprando
    } else if (result.dismiss === 'cancel') {
      router.push('/cart');
    }
  });
};
</script>

<style scoped>
.burger-card {
  background-color: white;
  flex: 1;
  border: 1px solid #ccc;
  border-radius: 20px;
  display: flex;
  flex-direction: column;
  margin: 1em 0.5em;
  padding: 1em 10px;
  min-width: 300px;
  max-width: 22vw;
}

.burger-image img {
  width: 100%;
  height: 275px;
  object-fit: cover;
  margin-bottom: 10px;
  border-radius: 11px;
}

.burger-details {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: center;
  text-align: center;
}

.button {
  margin-right: 2em;
  margin-top: 1em;
  font-size: 15px;
  background-color: #9758a6;
  width: 100%;
  color: white;
  border: none;
  border-radius: 5px;
  padding: 15px;
  cursor: pointer;
}

.button:hover {
  background-color: #8c4d9f;
}



@media (max-width: 1500px) {
  .burger-card {
    min-width: 20vw;
    max-width: 20vw;
  }
}

@media (max-width: 1000px) {
  .burger-card {
    min-width: 35vw;
    max-width: 35vw;
  }
}

@media (max-width: 600px) {
  .burger-card {
    min-width: 80vw;
    max-width: 80vw;
  }
}
</style>
