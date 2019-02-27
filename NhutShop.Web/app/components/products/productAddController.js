(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService'];
    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }
        // $scope.parentCategories = [];
        $scope.ckeditorOptions = {
            language: 'vi',
            height:'200px'
        }
        $scope.AddProduct = AddProduct;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function AddProduct() {
            apiService.post('/API/product/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + 'đã thêm mới');
                $state.go('products');
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
                $scope.product.Image = fileUrl;
            }
            finder.popup();
        }
        loadProductCategory();
    }
})(angular.module('nhutshop.products'))