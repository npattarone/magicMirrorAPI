
MagicMirrorApp.controller('productController', function ($scope, productService) {

    // Lo va a proveer el Tag RFID
    $scope.IdProduct = '75603';
    $scope.myInterval = 3000;

    getProduct($scope.IdProduct);

    function getProduct(id) {

        productService.getProduct(id)
            .then(function (response) {
                $scope.product  = response.data;

                console.log(response);
            })
            .catch(function (data) {
                console.log(data);
            });
    };
});