/// <reference path="../Plugins/angular-1.7.6/angular.js" />

var myApp = angular.module('myModule', []);
myApp.controller("studentmyController", studentmyController);
myApp.controller("teachermyController", teachermyController);
myApp.controller("schoolController", schoolController)
myController.$inject = ['$scope'];

function studentmyController($scope) {
  //  $scope.message = "HELLO YOU";
}

function teachermyController($scope) {
  //  $scope.message = "HELLO TEACHER";
}

function schoolController($scope) {
    $scope.message = "ANNONCE EVERY ONE";
}

