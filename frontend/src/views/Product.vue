<template>
    <section class="py-4 px-5">
        <div class="row justify-content-center">
            <div class="col-12 col-lg-5">
                <form>
                    <div class="input-group mb-3">
                        <label id="name">Nome:</label>
                        <input type="text" class="form-control" id="name" maxlength="100">
                    </div>
                    <div class="input-group mb-3">
                        <label id="name">Código:</label>
                        <input type="text" class="form-control" id="code" maxlength="100">
                    </div>
                    <div class="input-group mb-3">
                        <label id="name">Preço:</label>
                        <input type="text" class="form-control" id="price" maxlength="100">
                    </div>
                    <div class="input-group mb-3">
                        <label for="image">Imagem:</label>
                        <input type="file" class="form-control" id="image">
                    </div>
                    <div class="text-center w-100 py-4">
                        <button type="button" class="btn btn-success">Salvar</button>
                    </div>
                </form>
            </div>
        </div>
    </section>
</template>

<script>
export default {
    data() {
        return {

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