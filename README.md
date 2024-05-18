# **PROJETO INTEGRADOR: ANÁLISE DE SOLUÇÕES INTEGRADAS PARA ORGANIZAÇÕES**
*Projeto Integrador - Grupo 31*

Essa é a versão final do nosso aplicativo **Codeclube**. 

O nosso produto é destinado para restaurantes e estabelecimentos alimentícios que queiram apresentar os seus produtos diretamente para os clientes locais.
  
  A nossa solução foi pensada para melhorar a experiência de consumidores em restaurantes. A versão que apresentamos agora foi entregue para disciplina do nosso curso de **Análise e Desenvolvimento de Sistemas**. 
  
  Tentamos desenvolver este projeto levando em consideração a metodologia ágil. Fizemos reuniões online, visto que todos os participantes do grupo são de locais distintos do país. 

  Essa nova versão, conta com algumas novas features. Primeiro, agora o produto foi direcionado para administradores de estabelecimentos de todos os tamanhos. Assim, acrescentamos a possibilidade dos donos de restaurantes customizar o produto. 

  Os administradores dos estabelecimentos, podem inserir ou excluir produtos que queiram. A aplicação já conta com alguns dos principais produtos de bebidas e lanches do setor cadastrados. 

  Também inserimos para os clientes do produto a possibilidade de receberem recomendações com base nas suas compras anteriores. Assim, depois de fazer o login, os clientes se deparam com recomendações de produtos e depois o cardápio. 

  Pensando em quem  está atendendo nos restaurantes, desenvolvemos o login para os atendentes. Esse login também conta com recomendação de produtos, que os atendentes podem informar para os clientes, bem como a possibilidade de acompanhar
  os pedidos que foram feitos. 

  **Administradores**,  **Clientes** e **Atendentes** são as três personas que buscamos atingir com essa nova versão do CodeClube. 
  
  ## A estrutura do projeto 
Organizamos a pasta do projeto em dois três grupos: Front-end, Back-End e Banco de dados. 
O trabalho é resultado dos esforços do grupo que foi dividido nesses dois pontos. 
As linguagens de programação utilizadas foram escolhidas com base nas experiências e conhecimentos dos membros. 

### Back-End
O Back-End foi feito em C# Web API .NET usando Clean Architecture.   
Usamos a biblioteca Dapper para comunicação com o Banco de Dados. Documentação via Swagger, Autenticação via JWT.    

  ### Front-End 
O front end da aplicação foi construído com o framework Vue.js na versão 3,  junto do vite. Para consumo das API's foi utilizado o módulo fetch e para genrenciamento do carrinho foi utilizado o localstorage do próprio navegador.
A estrutura de pastas seguiu o modelo de componentes, páginas e um arquivo para definição das rotas.

 ### Banco de dados

 Para esta etapa, foram construídas tabelas com base no modelo de entidade e relacionamento e a linguagem SQL. 
 Disponibilizamos o script para criação do banco de dados e tabelas, bem como o script de carga dos dados.
 Utilizamos um SQL Server , que está hospedado em uma nuvem da Microsoft Azure. 
  
  ## Execução do projeto 

Para acessar o aplicativo, basta entrar no link que foi encaminhado no trabalho na plataforma do **Senac** . 

  Com o login e a senha será possível ter uma ideia das funcionalidades que preparamos.
  Para visualizar a experiência de cada uma das personas (Administradodres, Atendentes e Clientes) é preciso fazer o login do usuário específico. 
  
  Nenhuma instalação adcional é necessária e o acesso pode ser feito de qualquer dispotivo que contenha um navegador. 


## O Grupo 
Atualemnte, o grupo que desenvolveu este projeto é formado por estudantes do quinto semestre do curso de **Análise e Desenvolvimento de Sistemas** do Senac. 

Ruan Willians Mira Nogueira  

Sandro Santos Marra  

Tiago Alexandre Leme Barbosa  

Valter Antônio dias Júnior  

Vinicius Gonçalves Mariano  

 
## Links com vídeos do projeto 

Para visualizar a evolução do nosso produto, é possível ver no vídeo abaixo o produto que foi entregue no semestre passado: https://youtu.be/SKwVWUxNO2Q 

A versão final do nosso projeto com as novas features pode ser conferida igualmente no YouTube. 

Para acessar, clicar no link: https://youtu.be/ieYeYO7IoqU



