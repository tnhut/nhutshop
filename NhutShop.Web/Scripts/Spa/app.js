/// <reference path="../Plugins/angular-1.7.6/angular.js" />

var app = angular.module('myModule', []);
app.controller('schoolController', schoolController);
app.service('Validation', Validation);

schoolController.$inject = ['$scope', 'Validation'];

function schoolController($scope, Validation) {
    debugger
    $scope.num = 1;
    $scope.checkNumber = function () {
        $scope.message = Validation.checkNumber($scope.num);
    }
}

function Validation($window) {
    debugger
    return {
        checkNumber: checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0) {
           return 'so chan';
        }
        else {
            return 'so le';
        }
    }
}





//app.service('Validation', function () {
//    this.val = function (input) {
//        return input;
//    }
//});
//app.controller('schoolController', function ($scope, Validation) {
//    $scope.input = Validation.val(56);
//});


//function schoolController($scope, Validation) {
//    debugger
//    $scope.input = Validation.val(2);
//}



