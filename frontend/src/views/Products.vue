<template>
    <section class="container-fluid p-4">
        <div class="row">
            <div class="col-12 col-lg-10 d-flex">
                <input placeholder="Pesquisar" v-model="searchModel.target" v-on:keyup="search()" class="w-75 form-control">
                <select class="form-select w-25" v-model="searchModel.type" v-on:change="search()">
                    <option value="name">Nome</option>
                    <option value="code">Código</option>
                </select>
            </div>
            <div class="col-12 col-lg-2">
                <router-link class="btn btn-primary w-100" to="/produtos/novo">Adicionar <i class="fas fa-plus"></i> </router-link>
            </div>
        </div>
        <div class="row py-3">
            <div class="col-12">
                <div v-if="products.length == 0">
                    <h4 class="center">Nenhum produto cadastrado</h4>
                </div>
                <div class="table-responsive" v-if="products.items.length > 0">
                    <table class="table table-borderless table-hover table-striped">
                        <thead>
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Nome</th>
                                <th scope="col">Preço</th>
                                <th scope="col">Código</th>
                                <th scope="col">Ação</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="product in products.items" v-bind:key="product.id">
                                <th scope="row">{{ product.id }}</th>
                                <td>{{ product.name }}</td>
                                <td>{{ product.price }}</td>
                                <td>{{ product.code }}</td>
                                <td><i class="far fa-edit" title="Editar" v-on:click="edit(product.id)"></i>&nbsp;<i class="far fa-trash-alt" title="Excluir" v-on:click="remove(product.id)"></i></td>
                            </tr>
                        </tbody>
                    </table>
                    <nav aria-label="Page navigation example">
                        <ul class="pagination justify-content-end">
                            <li class="page-item" :class="{ disabled: searchModel.page <= 1 }">
                                <a class="page-link" v-on:click="previus()">Anterior</a>
                            </li>
                            <li class="page-item disabled"><a class="page-link" href="#">{{ searchModel.page }}</a></li>
                            <li class="page-item" :class="{ disabled: searchModel.page >= products.totalPages }">
                                <a class="page-link" href="#" v-on:click="next()">Próxima</a>
                            </li>
                        </ul>
                    </nav>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
import ws from '../services/ws'

export default {
    data() {
        return {
            products: {
                totalPages: 0,
                items: []
            },
            searchModel: {
                page: 1,
                target: "",
                type: "name",
                priceOrder: ""
            },
            searchTimer: null
        }
    },
    methods: {
        search: function () {
            if (this.searchTimer !== null) {
                clearTimeout(this.searchTimer)
            } 
            let model = this.searchModel
            var productsRef = this.products
            this.searchTimer = setTimeout(async function () {
                const queryString = serializeQueryString(model)
                try {
                    const response = await ws.getProducts(queryString)
                    productsRef.totalPages = response.totalPages
                    productsRef.items.splice(0,productsRef.items.length)
                    Object.assign(productsRef.items, response.items)
                } catch (error) {
                    console.error(error)
                    alert("Erro inesperado! Tente novamente mais tarde!")
                }
            },500)

            function serializeQueryString(model) {
                let query = "";
                Object.keys(model).forEach( (item,index) => {
                    if(model[item] !== "" ) {
                        query += `${index > 0 ? '&' : ''}${item}=${model[item]}`
                    }
                })
                return query;
            }
        },
        edit: function(id) {
            this.$router.push({name: 'EditProduct', params: {id}})
        },
        remove: async function(id) {
            try {
                await ws.removeProduct(id)
                this.products = await ws.getProducts()
                alert("Produto excluído com sucesso!")
            } catch (error) {
                alert("Erro inesperado. Tente novamente mais tarde!")
            }
        },
        next: function () {
            this.searchModel.page++
            this.search()
        },
        previus: function () {
            
        }
    },
    beforeMount: async function (params) {
        this.products = await ws.getProducts()
    }
}
</script>

<style scoped>
    .center {
        text-align: center;
    }
</style>