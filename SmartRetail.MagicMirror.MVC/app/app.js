var MagicMirrorApp = angular.module('MagicMirrorApp', []);

MagicMirrorApp.controller('magicMirrorController', function ($scope) {
    $scope.title = "Verano 2016/2017";
});

MagicMirrorApp.factory('productService', function ($http) {

    var productService = {};
    productService.getProduct = function (id) {
        return $http.get('/api/Product/Get/' + id);
    };

    return productService;
});