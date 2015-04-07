
var adminApplication = angular.module('adminApplication', ['ui-notification', 'ang-drag-drop']);

adminApplication.factory('webApiFactory', function () {
    var webApiFactory = {};

    webApiFactory.addQuestion = function (question, callback) {
        return $http.post("/api/Question/AddQuestion", question)
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.detQuestions = function (callback) {
        return $http.get("/api/Question/GetQuestions")
            .success(function (data) {
                callback(data);
            })
    };

    return webApiFactory;
});