(function (app) {
    app.filter('statusPay', function () {
        return function (input) {
            if (input == "yes")
                return 'Đã thanh toán';
            else
                return 'chưa thanh toán';
        }
    });
})(angular.module('BeautyCosmetic.common'));