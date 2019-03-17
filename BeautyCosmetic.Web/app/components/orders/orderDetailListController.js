(function (app) {
    app.controller('orderDetailListController', orderDetailListController);

    orderDetailListController.$inject = ['$scope', 'apiService', 'notificationService', '$window', '$filter'];

    function orderDetailListController($scope, apiService, notificationService, $window, $filter) {
        $scope.orderDetail = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getorderDetail = getorderDetail;
        $scope.keyword = '';

        //$scope.search = search;
        $scope.ShowConfirm = ShowConfirm;

        $scope.deleteOrderDetail = deleteOrderDetail;

        //$scope.selectAll = selectAll;

        //$scope.deleteMultiple = deleteMultiple;

        //function deleteMultiple() {
        //    var listId = [];
        //    $.each($scope.selected, function (i, item) {
        //        listId.push(item.ID);
        //    });
        //    var config = {
        //        params: {
        //            checkedorderDetail: JSON.stringify(listId)
        //        }
        //    }
        //    apiService.del('api/productcategory/deletemulti', config, function (result) {
        //        notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
        //        search();
        //    }, function (error) {
        //        notificationService.displayError('Xóa không thành công');
        //    });
        //}

        //$scope.isAll = false;
        //function selectAll() {
        //    if ($scope.isAll === false) {
        //        angular.forEach($scope.orderDetail, function (item) {
        //            item.checked = true;
        //        });
        //        $scope.isAll = true;
        //    } else {
        //        angular.forEach($scope.orderDetail, function (item) {
        //            item.checked = false;
        //        });
        //        $scope.isAll = false;
        //    }
        //}

        //$scope.$watch("orderDetail", function (n, o) {
        //    var checked = $filter("filter")(n, { checked: true });
        //    if (checked.length) {
        //        $scope.selected = checked;
        //        $('#btnDelete').removeAttr('disabled');
        //    } else {
        //        $('#btnDelete').attr('disabled', 'disabled');
        //    }
        //}, true);
    

        function ShowConfirm(id) {
            if ($window.confirm("Bạn có chắc muốn xác nhận đơn hàng này đã được thanh toán")) {
                $scope.deleteOrderDetail(id)
            } else {
                $scope.Message = "You clicked NO.";
            }
        }

        function deleteOrderDetail(id) {
            var config = {
                params: {
                    id: id
                }
            }
            apiService.put('api/orderdetail/updatebyid/' + id, null, function () {
                notificationService.displaySuccess('Xác nhận thành công');
                search();
            }, function () {
                notificationService.displayError('Xác nhận không thành công');
            })
        }

        function search() {
            getorderDetail();
        }

        function getorderDetail(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('api/orderdetail/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.orderDetail = result.data;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load orderdetail failed.');
            });
        }

        $scope.getorderDetail();
    }
})(angular.module('BeautyCosmetic.order_detail'));