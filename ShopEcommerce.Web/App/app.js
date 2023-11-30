/// <reference path="../bower_install/angular/angular.js" />
(function () {
    angular.module("shopEcommerce",
        ['shop.product'
        , 'shop.common'
        , 'shop.product_category'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('home', {
                url: "/admin",
                templateUrl: "/App/Home/HomeView.html",
                controller: "HomeController"
            });
        $urlRouterProvider.otherwise('/admin');
    }
})();