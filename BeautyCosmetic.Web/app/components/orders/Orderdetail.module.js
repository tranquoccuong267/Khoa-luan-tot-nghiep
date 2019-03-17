/// <reference path="../../../assets/admin/libs/angular/angular.js" />


(function () {
    angular.module('BeautyCosmetic.order_detail', ['BeautyCosmetic.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('order_detail', {
            url: "/order_detail",
            templateUrl: "/app/components/orders/orderDetailListView.html",
            parent: 'base',
            controller: "orderDetailListController"
        })
    }
})();
