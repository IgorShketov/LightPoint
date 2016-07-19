shop = (function () {
    var products = [];

    return {
        addNewProduct: function (productName, productPrice, productDescription) {
            var product = { productName: productName, productPrice: productPrice, productDescription: productDescription };
            products.push(product);
        },

        listProducts: function () {
            products.forEach(function (item, i, arr) {
                alert((i + 1) + ": " + item.productName + " " + item.productPrice + " " + item.productDescription);
            });
        },

        deleteProduct: function (productNum) {
            products.splice(productNum, 1);
        }
    }
})();