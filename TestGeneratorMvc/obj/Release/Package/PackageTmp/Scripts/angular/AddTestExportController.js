/// <reference path="../_references.js" />

adminApplication.controller('AddTestExportController', ['$scope', 'webApiFactory', 'Notification', function ($scope, webApiFactory, Notification) {
    $scope.addTestExport = function (testExport) {
        webApiFactory.addTestExport(testExport, function (data) {
            if (data) {
                $scope.link = data;
                Notification.success("Test export was added");
            }
            else {
                Notification.error("Problem with creating");
            }
        });
    };

    $scope.getTestsForTestExportCreate = function () {
        webApiFactory.getTestsForTestExportCreate(function (data) {
            $scope.tests = data;
        });
    }

    $scope.getTestsForTestExportCreate();
}]);