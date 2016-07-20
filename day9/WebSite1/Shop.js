shop = (function () {
    var products = [];

    function _addNewProduct (productName, productPrice, productDescription) {
        var product = { productName: productName, productPrice: productPrice, productDescription: productDescription };
        products.push(product);
    };

    function _getProducts () {
        return products;
    };

    function _sortByPrice() {
        products.sort(function(item1, item2) {
            return item1.productPrice - item2.productPrice;
        });
    };

    function _sortByName() {
        products.sort(function(item1, item2) {
            if (item1.productName > item2.productName) {
                return 1;
            }
            if (item1.productName < item2.productName) {
                return -1;
            }
            return 0;
        });
    };

    function _deleteProduct (productNum) {
        products.splice(productNum, 1);
    };

    function _getProductsAmount() {
        return products.length;
    };

    return {
        addNewProduct: _addNewProduct,
        getProducts: _getProducts,
        sortByName: _sortByName,
        sortByPrice: _sortByPrice,
        deleteProduct: _deleteProduct,
        getProductsAmount: _getProductsAmount
    }
})();