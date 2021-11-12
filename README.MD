# Desafio Linx - Nicolas Coelho Mansan
![Linx Logo](https://images.gupy.io/unsafe/50x50/https://s3.amazonaws.com/gupy5/production/companies/2006/career/3382/images/2021-01-28_13-08_logo.jpg)

## Detalhes da resolução
Alguns itens não foram levados em consideração devido aos requisitos do desafio.
Em uma aplicação real os seguintes itens devem ser implementados

 - Autenticação e autorização de usuário. Exemplo: Utilizar JWT nas requisições
 - Alterar credencias sensíveis para variáveis de ambiente
 - Usar Urls reais para origens (CORS)

Utilizando um banco de dados sem relevância somente para entrega do desafio.
Mudar string de conexão no arquivo appsettings.json caso queira utilizar DB local.  
 

## Contextualização do desafio
Imagine que você está no Projeto “XPTO” e na Sprint atual uma das suas tarefas é criar uma tela que gerencie os dados de um produto. O analista em questão levanta os seguintes requisitos:
 - [x] A tela deve realizar as operações de consulta, inclusão, alteração e exclusão
 - [x] Os campos da tela serão: Produto, Preço, Código de Barras e Imagem
 - [x] A consulta deve permitir filtros por Código de Barras e por Nome do Produto, sendo que estes não são obrigatórios
 - [x] Realizar a integração com a [“Fake Store”](https://fakestoreapi.com/docs) - Empresa terceirizada que armazena todos os produtos do sistema em um Data Lake. 
 
Portanto, para cada produto cadastrado na tela deve existir uma replicação na Fake Store API
Na listagem de produtos, deve existir a opção de ordenar por preço do produto

## Restrições:
 - [x] Deve existir uma separação entre interface do usuário (Client-side ou Front-End) e Regra de Negócio (Server-side ou Back-End)
 - [x] A tecnologia usada para o Front-End deverá ser em Vue.js
 - [x] A tecnologia usada para o Back-End deverá ser em .NET Core API
 - [x] O banco de dados deve ser SQL Server
 - [x] A entrega do projeto deve ser disponibilizada num repositório do GITHUB, sendo que no e-mail deverá constar apenas o link do repositório!

## Dicas
 - [x] Utilize o padrão RestFul para a API, por isso pense na utilização dos verbos, nomenclatura de rotas, tipos de retorno HTTP ( HTTP: Status Code ([devmedia.com.br](https://www.devmedia.com.br/http-status-code/41222)) por exemplo!
 - [x] Use o SWAGGER para a documentação da sua API – Imagine que um cliente poderá querer integrar com essa API
 - [x] Pense em segurança de dados, como evitar um SQL Injection por exemplo!
 - [x] Pense na usabilidade das telas
 - [x] Pense em performance no retorno das informações, como paginação de dados por exemplo!

### Reflexão

 - [x] Na inclusão de produtos na API da “Fake Store” o campo “Categoria” é solicitado no payload do método. O que você irá fazer já que no contexto da tarefa, o campo “Categoria” não existe e não faz sentido para a nossa regra de negócio (Pense como se esse campo fosse de preenchimento obrigatório)?

 - [x] Na inclusão de produtos na API da “Fake Store” o campo “Imagem” é solicitado no payload do método. O que você irá fazer já que no nosso caso a URL da imagem não existirá, pois salvamos os bytes da imagem e não uma URL?
