/// <reference path="../_references.js" />

adminApplication.controller('TestExportController', ['$scope', 'webApiFactory', 'Notification', function ($scope, webApiFactory, Notification) {
    $scope.getTestExportsWithTestInfo = function () {
        webApiFactory.getTestExportsWithTestInfo(function (data) {
            $scope.testExports = data
        });
    };

    $scope.deleteTestExport = function (index) {
        webApiFactory.deleteTestExport({ Id: $scope.testExports[index].Id }, function (data) {
            if (data) {
                Notification.success("Test export was deleted");
                $scope.testExports.splice(index, 1);
            }
            else {
                Notification.error("Problem with deleting");
            }
        });
    }

    $scope.getTestExportsCount = function () {
        webApiFactory.getTestExportsCount(function (data) {
            $scope.testExportsCount = data;
        });
    };

    $scope.getTestExportsWithTestInfo();
    $scope.getTestExportsCount();
}]);
