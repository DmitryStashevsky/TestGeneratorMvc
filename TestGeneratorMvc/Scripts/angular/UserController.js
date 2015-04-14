/// <reference path="../_references.js" />

adminApplication.controller('UserController', ['$scope', 'webApiFactory', 'Notification', function ($scope, webApiFactory, Notification) {
    $scope.getUsersWithInfo = function () {
        webApiFactory.getUsersWithInfo(function (data) {
            $scope.users = data
        });
    };

    $scope.getUsersCount = function () {
        webApiFactory.getUsersCount(function (data) {
            $scope.usersCount = data;
        });
    };

    $scope.getUsersWithInfo();
    $scope.getUsersCount();
}]);
