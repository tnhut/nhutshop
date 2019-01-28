/// <reference path="G:\LAPTOP\DUAN\Git\NhutShop.Web\Assets/Admin/libs/angular/angular.js" />

(function () {
    angular.module('nhutshop.product_categories', ['nhutshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider']
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/components/product_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        });
    }
})();