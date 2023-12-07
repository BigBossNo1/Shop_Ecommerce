(function (app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['$scope', '$location'];
    function rootController($scope, $location) {
        $scope.logout = function () {
            $location.path('login')
        }
    }
})(angular.module('shopEcommerce'));