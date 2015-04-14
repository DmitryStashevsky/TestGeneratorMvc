/// <reference path="../_references.js" />

adminApplication.controller('QuestionController', ['$scope', 'webApiFactory', 'Notification', function ($scope, webApiFactory, Notification) {
    $scope.getQuestionsWithUser = function () {
        webApiFactory.getQuestionsWithUser(function (data) {
            $scope.questions = data});
    };

    $scope.getQuestionsCount = function () {
        webApiFactory.getQuestionsCount(function (data) {
            $scope.questionsCount = data;
        });
    };

    $scope.getAnswersForQuestion = function (index) {
        var question = $scope.questions[index];
        if (!question.answers) {
            webApiFactory.getAnswersForQuestionWithRightValues(question.Id, function (data) {
                question.answers = data;
            });
        }
    };

    $scope.getQuestionsWithUser();
    $scope.getQuestionsCount();
}]);
