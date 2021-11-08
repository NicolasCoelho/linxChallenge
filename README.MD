# Desafio Linx - Nicolas Coelho Mansan
![Linx Logo](https://images.gupy.io/unsafe/50x50/https://s3.amazonaws.com/gupy5/production/companies/2006/career/3382/images/2021-01-28_13-08_logo.jpg)

## Contextualização do desafio
Imagine que você está no Projeto “XPTO” e na Sprint atual uma das suas tarefas é criar uma tela que gerencie os dados de um produto. O analista em questão levanta os seguintes requisitos:
 - A tela deve realizar as operações de consulta, inclusão, alteração e exclusão
 - Os campos da tela serão: Produto, Preço, Código de Barras e Imagem
 - A consulta deve permitir filtros por Código de Barras e por Nome do Produto, sendo que estes não são obrigatórios
 - Realizar a integração com a [“Fake Store”](https://fakestoreapi.com/docs) - Empresa terceirizada que armazena todos os produtos do sistema em um Data Lake. 
 
Portanto, para cada produto cadastrado na tela deve existir uma replicação na Fake Store API
Na listagem de produtos, deve existir a opção de ordenar por preço do produto

## Restrições:
 - Deve existir uma separação entre interface do usuário (Client-side ou Front-End) e Regra de Negócio (Server-side ou Back-End)
 - A tecnologia usada para o Front-End deverá ser em Vue.js
 - A tecnologia usada para o Back-End deverá ser em .NET Core API
 - O banco de dados deve ser SQL Server
 - A entrega do projeto deve ser disponibilizada num repositório do GITHUB, sendo que no e-mail para o tiago.rudek@linx.com.br deverá constar apenas o link do repositório!

## Dicas
 - Utilize o padrão RestFul para a API, por isso pense na utilização dos verbos, nomenclatura de rotas, tipos de retorno HTTP ( HTTP: Status Code ([devmedia.com.br](https://www.devmedia.com.br/http-status-code/41222)) por exemplo!
 - Use o SWAGGER para a documentação da sua API – Imagine que um cliente poderá querer integrar com essa API
 - Pense em segurança de dados, como evitar um SQL Injection por exemplo!
 - Pense na usabilidade das telas
 - Pense em performance no retorno das informações, como paginação de dados por exemplo!

### Reflexão

 - Na inclusão de produtos na API da “Fake Store” o campo “Categoria” é solicitado no payload do método. O que você irá fazer já que no contexto da tarefa, o campo “Categoria” não existe e não faz sentido para a nossa regra de negócio (Pense como se esse campo fosse de preenchimento obrigatório)?

 - Na inclusão de produtos na API da “Fake Store” o campo “Imagem” é solicitado no payload do método. O que você irá fazer já que no nosso caso a URL da imagem não existirá, pois salvamos os bytes da imagem e não uma URL?