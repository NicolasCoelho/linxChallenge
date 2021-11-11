const imageConverter = {
    imageToBase64: async function(file) {
        return await new Promise(function(resolve, reject) {
            let base64Image = ""
            const reader = new FileReader()
            reader.readAsDataURL(file)
            reader.onloadend = function () {
                base64Image = reader.result
                resolve(base64Image)
            }
            reader.onerror = function (err) {
                reject(err)
            }
        })
    }
}

export default imageConverter