/// <reference path="G:\LAPTOP\DUAN\Git\NhutShop.Web\Assets/Admin/libs/angular/angular.js" />

(function () {
    angular.module('nhutshop', ['nhutshop.products','nhutshop.common']).config(config);

    config.$inject=['$stateProvider', '$urlRouterProvider']
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/Admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/Admin')
    }
})();