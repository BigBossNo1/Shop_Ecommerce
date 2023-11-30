﻿(function () {
    angular.module("shop.product_category", ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('product_category', {
                url: "/product_category",
                templateUrl: "/App/Components/Product_Category/productCategoryListView.html",
                controller: "productCategoryListController"
            })
            .state('product_category_add', {
                url: "/product_category_add",
                templateUrl: "/App/Components/Product_Category/productCategoryAddView.html",
                controller: "productCategoryAddController"
            })
            .state('product_category_edit', {
                url: "/product_category_edit/:id",
                templateUrl: "/App/Components/Product_Category/productCategoryUpdateView.html",
                controller: "productCategoryUpdateController"
            });
    }
})();