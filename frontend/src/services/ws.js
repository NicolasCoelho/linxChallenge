const ws = {
    baseUrl: 'http://localhost:5000/api',
    isMock: false,
    headers: new Headers({
        "accept": "text/plain",
        "accept-language": "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7",
        "content-type": "application/json",
        "sec-fetch-dest": "empty",
        "sec-fetch-mode": "cors",
        "sec-fetch-site": "same-origin",
        "sec-gpc": "1"
    }),
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
            return await fetch(`${this.baseUrl}/products/${id}`, {
                headers: this.headers
            })
            .then(r => r.json())
            .then(response => response)
        }
    },
    postProduct: async function(payload) {
        if (this.isMock) {
            return await this.mockProducts()[0]
        } else {
            return await fetch(`${this.baseUrl}/products`, {
                headers: this.headers,
                method: "POST", 
                body: JSON.stringify(payload),
            })
            .then(r => r.json())
            .then(response => response)
        }
    },
    changeProduct: async function(id, payload) {
        if (this.isMock) {
            return await this.mockProducts()[0]
        } else {
            return await fetch(`${this.baseUrl}/products/${id}`, {
                headers: this.headers, 
                method: "PUT", 
                body: JSON.stringify(payload)
            })
            .then(r => r.json())
            .then(response => response)
        }
    },
    removeProduct: async function (id) {
        if (this.isMock) {
            return await this.mockProducts()[0]
        } else {
            return await fetch(`${this.baseUrl}/products/${id}`, {method: "DELETE"})
            .then(r => r.text())
            .then(response => response)
        }
    },
    mockProducts: async function () {
        const products = [
            { id: 1, name: 'Relógio', price: '49,90',code: '985719847102', image: '', createdAt }
        ]
        return await new Promise((resolve,reject)=>{
            setTimeout(() => {
                resolve(products)
            }, 500)
        })
    }
}

export default ws
