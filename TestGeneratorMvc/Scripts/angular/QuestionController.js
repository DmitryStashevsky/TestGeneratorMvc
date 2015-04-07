/// <reference path="../_references.js" />

adminApplication.controller('QuestionController', ['$scope', 'webApiFactory', 'Notification', function ($scope, webApiFactory, Notification) {
    $scope.getQuestions = function () {
        webApiFactory.getQuestions(function (data) {
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
            webApiFactory.GetAnswersForQuestionWithRightValues(question.Id, function (data) {
                question.answers = data;
            });
        }
    };

    $scope.getQuestions();
    $scope.getQuestionsCount();
}]);
