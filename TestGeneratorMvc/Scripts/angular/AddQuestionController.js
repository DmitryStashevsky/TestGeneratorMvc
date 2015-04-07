/// <reference path="../_references.js" />

adminApplication.controller('AddQuestionController', ['$scope', 'webApiFactory', function ($scope, webApiFactory, Notification) {
    $scope.addQuestion = function (question) {
        webApiFactory.addQuestion(question, function (data) {
            Notification.success(data);
        });
    };

    $scope.addAnswer = function () {
        $scope.question.answers.push({ text: "", isCorrect: false });
    };

    $scope.deleteAnswer = function (index) {
        $scope.question.answers.splice(index, 1);
    };

    $scope.question = {};
    $scope.question.answers =
        [{ text: "", isCorrect: false },
        { text: "", isCorrect: false },
        { text: "", isCorrect: false }];
}]);