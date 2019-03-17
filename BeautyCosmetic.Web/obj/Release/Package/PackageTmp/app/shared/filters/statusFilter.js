(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true)
                return 'active';
            else
                return 'lock';
        }
    });
})(angular.module('BeautyCosmetic.common'));