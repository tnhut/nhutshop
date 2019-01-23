/// <reference path="../Plugins/angular-1.7.6/angular.js" />

var myApp = angular.module('myModule', []);
myApp.controller("myController", myController); 

myController.$inject = ['$scope'];
function myController($scope) {
    $scope.message = "HELLO YOU";
}

