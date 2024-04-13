<template>
  <Banner />
  <div class="container">
    <div class="header-page">
      <h1 id="title">MEU CARDÁPIO</h1>
      <div>
        <Button @click="showAddProductModal">Adicionar produto</Button>
      </div>
    </div>
    <div class="burgers">
      <CardManager v-for="burger in hamburgers" :key="burger.id" :id="burger.id" :nome="burger.nome"
        :preco="burger.preco" :caminhoImagem="burger.caminhoImagem" :descricao="burger.descricao" />
    </div>
  </div>
</template>

<script setup>
import Banner from "../components/Banner.vue";
import CardManager from "../components/CardManager.vue";
import { BASEURL } from "../../env";
import { onBeforeMount, ref } from "vue";
import Button from "../components/Button.vue";
import Swal from 'sweetalert2';

const hamburgers = ref([]);
const loading = ref(false); // Variável para controlar o loading

onBeforeMount(async () => {
  hamburgers.value = await getBurgers();
});

async function getBurgers() {
  try {
    const response = await fetch(`${BASEURL}/api/Produto`, {
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

const showAddProductModal = () => {
  Swal.fire({
    title: 'Adicionar Produto',
    html:
      `<input id="nome" class="swal2-input" placeholder="Nome do produto">
       <input id="preco" class="swal2-input" type="number" placeholder="Preço do produto">
       <textarea id="descricao" class="swal2-textarea" placeholder="Descrição do produto"></textarea>
       <p>Selecione a Imagem:</p>
       <input id="imagem" class="swal2-file" type="file" accept="image/*" placeholder="Imagem do produto">`,
    showCancelButton: true,
    cancelButtonText: 'Cancelar',
    confirmButtonText: 'Cadastrar',
    focusConfirm: false,
    preConfirm: () => {
      const nome = Swal.getPopup().querySelector('#nome').value;
      const preco = Swal.getPopup().querySelector('#preco').value;
      const descricao = Swal.getPopup().querySelector('#descricao').value;
      const imagem = Swal.getPopup().querySelector('#imagem').files[0];

      return { nome, preco, imagem, descricao };
    }
  }).then((result) => {
    if (result.isConfirmed) {
      const { nome, preco, imagem, descricao } = result.value;
      criarProduto(nome, preco, imagem, descricao); // Chama a função para criar o produto
    }
  });
}

const criarProduto = async (nome, preco, imagem, descricao) => {
  // Mostra o loading ao criar o produto
  loading.value = true;

  try {
    const formData = new FormData();
    formData.append('nome', nome);
    formData.append('preco', preco);
    formData.append('imagem', imagem);
    formData.append('descricao', descricao);

    const response = await fetch(`${BASEURL}/api/Produto`, {
      method: "POST",
      headers: {
        Authorization: localStorage.getItem("token"),
      },
      body: formData,
    });

    if (response.ok) {
      // Produto criado com sucesso
      loading.value = false; // Oculta o loading
      Swal.fire('Sucesso!', 'Produto cadastrado com sucesso!', 'success');
      // Atualiza a lista de produtos após criar o novo produto
      hamburgers.value = await getBurgers();
    } else {
      console.error("Erro ao criar produto. Código de status:", response.status);
      loading.value = false; // Oculta o loading em caso de erro
      Swal.fire('Erro!', 'Ocorreu um erro ao cadastrar o produto.', 'error');
    }
  } catch (error) {
    console.error("Erro ao criar produto:", error);
    loading.value = false; // Oculta o loading em caso de erro
    Swal.fire('Erro!', 'Ocorreu um erro ao cadastrar o produto.', 'error');
  }
}
</script>

<style scoped>
/* Seus estilos existentes */

/* Estilos do overlay de loading */
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

.header-page {
  display: flex;
  width: 100%;
  flex-direction: row;
  justify-content: space-between;
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
</style>
