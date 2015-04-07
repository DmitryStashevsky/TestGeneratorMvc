
var adminApplication = angular.module('adminApplication', ['ui-notification', 'ang-drag-drop']);

adminApplication.factory('webApiFactory', function ($http) {
    var webApiFactory = {};

    webApiFactory.addQuestion = function (question, callback) {
        return $http.post("/api/Question/AddQuestion", question)
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getQuestions = function (callback) {
        return $http.get("/api/Question/GetQuestions")
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getQuestionsCount = function (callback) {
        return $http.get("/api/Question/GetQuestionsCount")
            .success(function (data) {
                callback(data);
            }) 
    }; 

    webApiFactory.GetAnswersForQuestionWithRightValues = function (questionId, callback) {
        return $http({
            url: "/api/Question/GetAnswersForQuestionWithRightValues",
            method: "GET",
            params: { questionId: questionId }
        }).success(function (data) {
            callback(data);
        })
    };

    return webApiFactory;
});