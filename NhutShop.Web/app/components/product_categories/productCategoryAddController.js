(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['apiService', '$scope', 'notificationService','$state'];
    function productCategoryAddController(apiService, $scope, notificationService, $state) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status:true
        }
       // $scope.parentCategories = [];

        $scope.AddProductCategory = AddProductCategory;

        function AddProductCategory() {
            apiService.post('/API/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + 'đã thêm mới');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('thêm mới thất bại');
            });
        }
        function loadParentCategory() {
            apiService.get('/API/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function(){
                console.log('Can not load parent');
            });
        }

        loadParentCategory();
    }
})(angular.module('nhutshop.product_categories'))