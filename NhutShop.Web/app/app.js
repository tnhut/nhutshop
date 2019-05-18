/// <reference path="G:\LAPTOP\DUAN\Git\NhutShop.Web\Assets/Admin/libs/angular/angular.js" />

(function () {
    angular.module('nhutshop',
        [   'nhutshop.products',
            'nhutshop.product_categories',        
            'nhutshop.common'])
        .config(config)
      //  .config($qProvider)
        .config(configAuthentication);
    config.$inject = ['$stateProvider', '$urlRouterProvider']
    function config($stateProvider, $urlRouterProvider) {
        debugger
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/views/baseView.html',
                abstract:true
            })
            .state('login', {
                url: "/login",              
                templateUrl: "/app/components/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/Admin",
                parent:'base',
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
        });
        $urlRouterProvider.otherwise('/login')
    }

    //function $qProvider($qProvider) {
    //    $qProvider.errorOnUnhandledRejections(false);
    //}

    function configAuthentication($httpProvider) {
        debugger
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {
                 
                    if (rejection.status == "401") {
                        $location.path('/login');
                       
                    }
                    return $q.reject(rejection);
                }
            };
        });
      
    }
    
})();







