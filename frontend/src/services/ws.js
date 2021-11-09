const ws = {
    baseUrl: "http://localhost:3000",
    isMock: true,
    getProducts: async function() {
        if (this.isMock) {
            return await this.mockProducts();
        } else {
            //TODO
        }
    },
    getProduct: async function(id){
        if (this.isMock) {
            return await this.mockProduct();
        } else {
            //TODO
        }
    },
    changeProduct: async function(product) {
        
    },
    removeProduct: async function (id) {

    },
    mockProducts: async function () {
        const products = [
            { id: 1, name: 'Relógio', price: '49,90',code: '985719847102' }
        ]
        return await new Promise((resolve,reject)=>{
            setTimeout(() => {
                resolve(products)
            }, 500);
        });
    },
    mockProduct: async function () {
        const product = { id: 1, name: 'Relógio', price: '49,90', code: '985719847102' }
        return await new Promise((resolve,reject)=>{
            setTimeout(() => {
                resolve(product)
            }, 500);
        });
    }
}

export default ws