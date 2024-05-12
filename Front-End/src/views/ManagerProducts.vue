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
const loading = ref(false);

onBeforeMount(async () => {
  hamburgers.value = await getBurgers();
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

const showAddProductModal = () => {
  Swal.fire({
    title: 'Adicionar Produto',
    html:
      `<input id="nome" class="swal2-input" placeholder="Nome do produto">
     <input id="preco" class="swal2-input" type="number" placeholder="Preço do produto">
     <textarea id="descricao" class="swal2-textarea" placeholder="Descrição do produto"></textarea>
     <input id="palavraChave" class="swal2-input" placeholder="Palavra chave de recomendação">
     <p style="margin: .5em 2em">Selecione a Imagem:</p>
     <div id="opcoesImagem" style="display: flex; justify-content: space-between; flex-wrap: wrap; margin: 35px">
      <label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/aipim_frito.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/aipim_frito.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/polenta_frita.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/polenta_frita.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/onion_rings.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/onion_rings.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/ketchup.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/ketchup.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/agua_sem_gas.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/agua_sem_gas.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/guarana_lata.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/guarana_lata.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/maionese.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/maionese.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/mostarda.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/aperitivos/mostarda.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/agua_com_gas.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/agua_com_gas.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/coca_lata_diet.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/coca_lata_diet.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/fanta_uva.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/fanta_uva.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/coca_2litros.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/bebidas/coca_2litros.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/cachorro_quente_normal.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/cachorro_quente_normal.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/cachorro_quente_prensado.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/cachorro_quente_prensado.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/hamburguer_frango.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/hamburguer_frango.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/xis_coracao.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/xis_coracao.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/hamburguer_duplo.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/hamburguer_duplo.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/xis_frango.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/xis_frango.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/xis_calabresa.PNG?raw=true">
  <img src="https://github.com/vinimariano/senacProjetoIntegrador/blob/main/Banco-de-Dados/lanches/xis_calabresa.PNG?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/ruanwillians/senacProjeto/blob/main/Front-End/src/assets/burger6.png?raw=true">
  <img src="https://github.com/ruanwillians/senacProjeto/blob/main/Front-End/src/assets/burger6.png?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>

<label style="display: flex; flex-direction: column; align-items: center;">
  <input type="radio" name="imagem" value="https://github.com/ruanwillians/senacProjeto/blob/main/Front-End/src/assets/burger2.png?raw=true">
  <img src="https://github.com/ruanwillians/senacProjeto/blob/main/Front-End/src/assets/burger2.png?raw=true" style="object-fit: cover; width: 100px; height: 100px">
</label>
     </div>`,
    showCancelButton: true,
    cancelButtonText: 'Cancelar',
    confirmButtonText: 'Cadastrar',
    focusConfirm: false,
    preConfirm: () => {
      const nome = Swal.getPopup().querySelector('#nome').value;
      const preco = Swal.getPopup().querySelector('#preco').value;
      const descricao = Swal.getPopup().querySelector('#descricao').value;
      const palavraChave = Swal.getPopup().querySelector('#palavraChave').value;
      const imagemSelecionada = Swal.getPopup().querySelector('input[name="imagem"]:checked');

      let imagemSrc;
      if (imagemSelecionada) {
        imagemSrc = imagemSelecionada.value;
      }

      return { nome, preco, imagemSrc, descricao, palavraChave };
    },
    didOpen: () => {
      const modalContent = document.querySelector('.swal2-html-container');
      modalContent.style.display = 'flex';
      modalContent.style.flexDirection = 'column';
      const opcoesImagem = document.getElementById('opcoesImagem');
      opcoesImagem.addEventListener('change', () => {
        const imagemSelecionada = opcoesImagem.querySelector('input[name="imagem"]:checked');
        const previewImagem = document.getElementById('previewImagem');
        if (imagemSelecionada) {
          const imagemSrc = imagemSelecionada.value;
          previewImagem.innerHTML = `<img src="${imagemSrc}" style="max-width: 100%; max-height: 200px;">`;
        } else {
          previewImagem.innerHTML = '';
        }
      });
    }
  }).then((result) => {
    if (result.isConfirmed) {
      const { nome, preco, imagemSrc, descricao, palavraChave } = result.value;
      criarProduto(nome, preco, imagemSrc, descricao, palavraChave);
    }
  });
}
const criarProduto = async (nome, preco, imagem, descricao, palavraChave) => {
  const body = {
    "id": Math.floor(Math.random() * 1000),
    "nome": nome,
    "descricao": descricao,
    "preco": preco,
    "caminhoImagem": imagem,
    "palavrasChave": palavraChave
  }

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: localStorage.getItem("token"),
    },
    body: JSON.stringify(body),
  };

  const response = await fetch(`${BASEURL}/api/Produto/Create`, requestOptions);
  loading.value = true;

  try {
    if (response.ok) {
      loading.value = false;
      Swal.fire('Sucesso!', 'Produto cadastrado com sucesso!', 'success');
      hamburgers.value = await getBurgers();
    } else {
      console.error("Erro ao criar produto. Código de status:", response.status);
      loading.value = false;
      Swal.fire('Erro!', 'Ocorreu um erro ao cadastrar o produto.', 'error');
    }
  } catch (error) {
    console.error("Erro ao criar produto:", error);
    loading.value = false;
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

@media (max-width: 650px) {
  .header-page {
    display: flex;
    width: 100%;
    flex-direction: column;
  }

  #title {
    margin-bottom: -.2em;
  }

  .burgers {
    margin-top: 1em;
  }
}
</style>
