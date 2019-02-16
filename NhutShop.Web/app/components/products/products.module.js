/// <reference path="G:\LAPTOP\DUAN\Git\NhutShop.Web\Assets/Admin/libs/angular/angular.js" />

(function () {
    angular.module('nhutshop.products', ['nhutshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider']
    function config($stateProvider, $urlRouterProvider) {
        debugger
        $stateProvider.state('products', {
            url: "/products",
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController"
        }).state('product_add', {
            url: "/product_add",
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController"
        });
    }
})();