<template>
    <section class="container-fluid p-4">
        <div class="row">
            <div class="col-12 col-lg-10 d-flex">
                <input placeholder="Pesquisar" class="w-75 form-control">
                <select class="form-select w-25">
                    <option>Nome</option>
                    <option>Código</option>
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
                <div class="table-responsive" v-if="products.length > 0">
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
                            <tr v-for="product in products" v-bind:key="product.id">
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
                            <li class="page-item disabled">
                            <a class="page-link">Anterior</a>
                            </li>
                            <li class="page-item"><a class="page-link" href="#">1</a></li>
                            <li class="page-item page-item disabled">
                            <a class="page-link" href="#">Próxima</a>
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
            products: []
        }
    },
    methods: {
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