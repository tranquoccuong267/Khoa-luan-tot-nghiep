(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);



    productCategoryAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function productCategoryAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
        }

        $scope.AddProductCategory = AddProductCategory;
        //$scope.productCategory.Name = '';
        //$scope.$watch('productCategory.Name', function (newValue) {
        //    if (newValue.length === 0) {
        //        console.log('Empty');
        //    } else {
        //        console.log('Has content');
        //    }
        //});
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }


        function AddProductCategory() {
            apiService.post('api/productcategory/create', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess('Danh mục ' + result.data.Name + ' đã được thêm mới.');
                    $state.go('product_categories');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        function loadParentCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadParentCategory();
    }

})(angular.module('BeautyCosmetic.product_categories'));