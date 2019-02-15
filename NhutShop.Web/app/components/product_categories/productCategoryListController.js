(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.selectAll = selectAll;
        $scope.deleteMultiple = deleteMultiple;

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            })
            var config = {
                params:{
                    checkedProductCategories: JSON.stringify(listId)
                }
            }
            apiService.del('/API/productcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công' + result.data + 'bản ghi');
                search();
            }, function (error) {
                notificationService.displayError('Xóa thất bại');
            });
        }
        //function selectAll() {
        //    if ($scope.isAll === false) {
        //        angular.forEach($scope.productCategories, function (item) {
        //            item.checked = true;
        //        });
        //        $scope.isAll = true;
        //    } else {
        //        angular.forEach($scope.productCategories, function (item) {
        //            item.checked = false;
        //        });
        //        $scope.isAll = false;
        //    }
        //}
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteProductCategory(id) {
            debugger
            $ngBootbox.confirm('Bạn có chắc muốn xóa').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/API/productcategory/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa thất bại');
                })
            });
        }
        function search() {
            getProductCategories();
        }
        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('/API/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy bản ghi');
                }
               // else {
               //     notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount+ ' bản ghi');
               // }
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load ProductCategory failed');
            });
        }

        $scope.getProductCategories();
    }
})(angular.module('nhutshop.product_categories'))