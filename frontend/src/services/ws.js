const ws = {
    baseUrl: 'http://localhost:5000/api',
    isMock: false,
    getProducts: async function() {
        if (this.isMock) {
            return await this.mockProducts()
        } else {
            return await fetch(`${this.baseUrl}/products/`)
            .then(r => r.json())
            .then(response => response)
        }
    },
    getProduct: async function(id){
        if (this.isMock) {
            return await this.mockProducts()[0]
        } else {
            return await fetch(`${this.baseUrl}/products/${id}`)
            .then(r => r.json())
            .then(response => response)
        }
    },
    changeProduct: async function(product) {
        if (this.isMock) {
            return await this.mockProducts()[0]
        } else {
            return await fetch(`${this.baseUrl}/products/${id}`, {method: "PUT"})
            .then(r => r.json())
            .then(response => response)
        }
    },
    removeProduct: async function (id) {
        if (this.isMock) {
            return await this.mockProducts()[0]
        } else {
            return await fetch(`${this.baseUrl}/products/${id}`, {method: "DELETE"})
            .then(r => r.json())
            .then(response => response)
        }
    },
    mockProducts: async function () {
        const products = [
            { id: 1, name: 'Relógio', price: '49,90',code: '985719847102', image: '' }
        ]
        return await new Promise((resolve,reject)=>{
            setTimeout(() => {
                resolve(products)
            }, 500)
        })
    }
}

export default ws
