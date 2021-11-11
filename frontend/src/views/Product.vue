<template>
    <section class="py-4 px-5">
        <div class="row" v-if="isEdit">
            <b class="text-center">{{ $route.params.id }}</b>
        </div>
        <div class="row justify-content-center">
            <div class="col-12 col-lg-5">
                <form>
                    <div class="input-group mb-3">
                        <label id="name">Nome:</label>
                        <input type="text" required class="form-control" v-model="product.name" id="name" maxlength="100">
                    </div>
                    <div class="input-group mb-3">
                        <label id="name">Código:</label>
                        <input type="text" required class="form-control" v-model="product.code" id="code" maxlength="100">
                    </div>
                    <div class="input-group mb-3">
                        <label id="name">Preço:</label>
                        <input type="text" required class="form-control" v-model="product.price" id="price" maxlength="100">
                    </div>
                    <div class="input-group mb-3">
                        <label for="image">Imagem:</label>
                        <input type="file" required v-on:change="setImage($event)" class="form-control" id="image" accept=".png, .jpeg, .jpg, .jpe, .jfif, .jif">
                    </div>
                    <div class="text-center w-100 py-4">
                        <button type="button" class="btn btn-success" v-on:click="save()">Salvar</button>
                    </div>
                </form>
            </div>
        </div>
    </section>
</template>

<script>
import ws from '../services/ws'
import imageConverter from '../providers/imageConvertet'

export default {
    data() {
        return {
            isEdit: this.$route.params.id !== undefined,
            product: {
                id: 0,
                name: '',
                code: '',
                price: '',
                image: 'https://',
                createdAt: ''
            }
        }
    },
    beforeMount: async function() {
        if (this.isEdit) {
            this.product = await ws.getProduct(this.$route.params.id);
        }   
    },
    methods: {
        save: async function() {
            try {
                let payload = new Object()
                Object.assign(payload, this.product)
                delete payload.id
                delete payload.createdAt
                if (this.isEdit) {
                    await ws.changeProduct(this.product.id, payload)
                    alert("Produto Alterado com sucesso")
                } else {
                    await ws.postProduct(payload)
                    alert("Produto criado com sucesso")
                    this.$router.push({name: 'Products'})
                }  
            } catch (error) {
                console.error(error)
                alert("Erro inesperado. Tente novamente mais tarde!")
            }
        },
        setImage: async function(event) {
            const file = event.target.files[0];
            if (file) {
                if (file.size > 4098) {
                    alert("Arquivo grande demais!")
                    event.target.value = ""
                    return
                }
                const imageString = await imageConverter.imageToBase64(file)
                this.product.image = imageString
            }
        }
    }
}
</script>

<style scoped>
    label {
        width: 100%;
        font-weight: 500;
    }
</style>