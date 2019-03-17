(function (app) {
    'use strict';

    app.controller('applicationUserListController', applicationUserListController);

    applicationUserListController.$inject = ['$scope', 'apiService', 'notificationService', '$window'];

    function applicationUserListController($scope, apiService, notificationService, $window) {
        $scope.loading = true;
        $scope.data = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.search = search;
        $scope.clearSearch = clearSearch;
        $scope.ShowConfirm3 = ShowConfirm3;
        $scope.deleteItem = deleteItem;
        function ShowConfirm3(id) {
            if ($window.confirm("Bạn có muốn xóa danh mục này??")) {
                $scope.deleteItem(id)
            } else {
                $scope.Message = "You clicked NO.";
            }
        }
        function deleteItem(id) {
                    var config = {
                        params: {
                            id: id
                        }
                    }
                    apiService.del('/api/applicationUser/delete', config, function () {
                        notificationService.displaySuccess('Đã xóa thành công.');
                        search();
                    },
                    function () {
                        notificationService.displayError('Xóa không thành công.');
                    });
        }
        function search(page) {
            page = page || 0;

            $scope.loading = true;
            var config = {
                params: {
                    page: page,
                    pageSize: 10,
                    filter: $scope.filterExpression
                }
            }

            apiService.get('api/applicationUser/getlistpaging', config, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {
            $scope.data = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.loading = false;

            if ($scope.filterExpression && $scope.filterExpression.length) {
                notificationService.displayInfo(result.data.Items.length + ' items found');
            }
        }
        function dataLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.filterExpression = '';
            search();
        }

        $scope.search();
    }
})(angular.module('BeautyCosmetic.application_users'));