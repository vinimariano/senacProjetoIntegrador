<template>
  <div class="burger-card">
    <div class="burger-image">
      <img :src="caminhoImagem" alt="Burger Image" />
    </div>
    <div class="burger-details">
      <h2>{{ nome }}</h2>
      <h4>Preço: R$: {{ preco }},00</h4>
      <Button @click="removeProduct(props)">Excluir Produto</Button>
    </div>
  </div>
</template>

<script setup>
import { ref, defineProps } from 'vue';
import Swal from 'sweetalert2';
import Button from './Button.vue';
import { BASEURL } from "../../env";

const props = defineProps(['id', 'nome', 'preco', 'caminhoImagem', 'descricao']);

const nome = ref(props.nome);
const preco = ref(props.preco);
const caminhoImagem = ref(props.caminhoImagem);
const descricao = ref(props.descricao);

const removeProduct = async (product) => {
  Swal.fire({
    title: 'Você tem certeza que deseja excluir o produto do seu cardápio?',
    showCancelButton: true,
    confirmButtonText: 'Sim',
    cancelButtonText: 'Voltar',
  }).then(async (result) => {
    if (result.isConfirmed) {
      const response = await fetch(`${BASEURL}/api/Produto/Delete?id=${product.id}`, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
          Authorization: localStorage.getItem("token"),
        }
      });

      if (response.status === 200) {
        Swal.fire('Produto excluído com sucesso!', '', 'success');
        setTimeout(() => {
          window.location.reload()
        }, 1500);
      } else {
        Swal.fire('Erro ao excluir o produto.', '', 'error');
      }
    } else if (result.dismiss === 'cancel') {
      router.push('/cart');
    }
  });
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
    min-width: 20vw;
    max-width: 20vw;
  }
}

@media (max-width: 750px) {
  .burger-card {
    min-width: 80vw;
    max-width: 80vw;
  }
}
</style>
