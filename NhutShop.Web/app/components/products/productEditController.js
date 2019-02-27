﻿(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService','$stateParams'];
    function productEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.product = {};
        
        // $scope.parentCategories = [];
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }
        $scope.UpdateProduct = UpdateProduct;
        $scope.moreImages = [];
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function loadProductDetail() {
            apiService.get('/API/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImages);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function UpdateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages)
            apiService.post('/API/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + 'đã được cập nhật');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Cập nhật thất bại');
            });
        }
        function loadProductCategory() {
            apiService.get('/API/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Can not load parent');

            });
        }

        //function loadProductCategory() {
        //    apiService.get('/API/product/getallparents', null, function (result) {
        //        $scope.productCategories = result.data;
        //    }, function () {
        //        console.log('Can not load parent');
        //    });
        //}
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })                
            }
            finder.popup();
        }

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }      
        loadProductCategory();
        loadProductDetail();
    }
})(angular.module('nhutshop.products'))