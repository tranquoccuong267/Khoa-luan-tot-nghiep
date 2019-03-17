(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true)
                return 'active';
            else
                if (input == false) { return 'lock'; }
                else if (input == 'yes') { return 'đã thanh toán'; }
                else { return 'chưa thanh toán';}

                
        }
    });
})(angular.module('BeautyCosmetic.common'));