
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

    webApiFactory.addTest = function (test, callback) {
        return $http.post("/api/Test/AddTest", test)
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getTests = function (callback) {
        return $http.get("/api/Test/GetTests")
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getTestsCount = function (callback) {
        return $http.get("/api/Test/GetTestsCount")
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getQuestionsForTest = function (GetQuestionsForTest, callback) {
        return $http({
            url: "/api/Test/ПetQuestionsForTest",
            method: "GET",
            params: { testId: testId }
        }).success(function (data) {
            callback(data);
        })
    };

    webApiFactory.getQuestionsForTestCreate = function (callback) {
        return $http.get("/api/Test/GetQuestionsForTestCreate")
            .success(function (data) {
                callback(data);
            })
    };

    return webApiFactory;
});