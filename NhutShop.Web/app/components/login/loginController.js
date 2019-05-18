(function (app) {
    
    app.controller('loginController', ['$scope', 'loginService', '$injector', 'notificationService',
        function ($scope, loginService, $injector, notificationService) {

            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.loginSubmit = function () {
                debugger
                
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                    if (response != null && response.error != undefined) {
                        notificationService.displayError("Đăng nhập không đúng.");
                    }
                    else {
                        var stateService = $injector.get('$state');
                       notificationService.hides();
                        stateService.go('home');
                        
                    }
                });
                             
                    notificationService.displayError("Đăng nhập không đúng.");                             
            }

        
        }]);
    app.config(['$qProvider', function ($qProvider) {
        $qProvider.errorOnUnhandledRejections(false);
    }]);
})(angular.module('nhutshop'));