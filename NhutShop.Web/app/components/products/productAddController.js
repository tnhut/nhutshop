(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];
    function productAddController(apiService, $scope, notificationService, $state) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }
        // $scope.parentCategories = [];
        $scope.ckeditorOptions = {
            language: 'vi',
            height:'200px'
        }
        $scope.AddProductCategory = AddProduct;

        function AddProduct() {
            apiService.post('/API/product/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + 'đã thêm mới');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('thêm mới thất bại');
            });
        }
        function loadProductCategory() {
            apiService.get('/API/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Can not load parent');
            });
        }

        loadProductCategory();
    }
})(angular.module('nhutshop.product_categories'))