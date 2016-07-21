shop = (function () {
    var products = [],
        nameSortDirection = 1,
        priceSortDirection = 1;
    

    function _addNewProduct (productName, productPrice, productDescription) {
        var product = { productName: productName, productPrice: productPrice, productDescription: productDescription };
        products.push(product);
    };

    function _getProducts () {
        return products;
    };

    function _getProduct(productNum) {
        return products[productNum];
    };

    function _sortByPrice() {
        products.sort(function(item1, item2) {
            return (item1.productPrice - item2.productPrice) * priceSortDirection;
        });

        priceSortDirection *= -1;
    };

    function _sortByName() {
        products.sort(function(item1, item2) {
            if (item1.productName > item2.productName) {
                return 1 * nameSortDirection;
            }
            if (item1.productName < item2.productName) {
                return -1 * nameSortDirection;
            }
            return 0;
        });

        nameSortDirection *= -1;
    };

    function _changeProduct(productNum, _productName, _productPrice, _productDescription) {
        products[productNum].productName = _productName;
        products[productNum].productPrice = _productPrice;
        products[productNum].productDescription = _productDescription;
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
        getProduct: _getProduct,
        sortByName: _sortByName,
        sortByPrice: _sortByPrice,
        changeProduct: _changeProduct,
        deleteProduct: _deleteProduct,
        getProductsAmount: _getProductsAmount
    }
})();