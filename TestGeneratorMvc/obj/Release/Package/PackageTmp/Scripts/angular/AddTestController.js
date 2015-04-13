/// <reference path="../_references.js" />

adminApplication.controller('AddTestController', ['$scope', 'webApiFactory', 'Notification', function ($scope, webApiFactory, Notification) {
    $scope.addTest = function (test) {
        test.Questions = $.map($scope.selectedQuestions, function (elem) {
            return elem.Id;
        })
        webApiFactory.addTest(test, function (data) {
            Notification.success(data);
        });
    };

    $scope.getQuestionsForTestCreate = function () {
        webApiFactory.getQuestionsForTestCreate(function (data) {
            $scope.questions = data;
        });
    };

    $scope.dropSuccessHandler = function ($event, index, array) {
        array.splice(index, 1);
    };

    $scope.onDrop = function ($event, $data, array) {
        array.push($data);
    };

    $scope.test = {};
    $scope.selectedQuestions = [];

    $scope.getQuestionsForTestCreate();
}]);