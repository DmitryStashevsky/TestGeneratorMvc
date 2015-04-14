
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

    webApiFactory.getQuestionsWithUser = function (callback) {
        return $http.get("/api/Question/GetQuestionsWithUser")
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

    webApiFactory.getAnswersForQuestionWithRightValues = function (questionId, callback) {
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

    webApiFactory.getTestsWithOwner = function (callback) {
        return $http.get("/api/Test/GetTestsWithOwner")
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

    webApiFactory.getQuestionsForTest = function (testId, callback) {
        return $http({
            url: "/api/Test/GetQuestionsForTest",
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

    webApiFactory.addTestExport = function (testExport, callback) {
        return $http.post("/api/TestExport/AddTestExport", testExport)
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.deleteTestExport = function (testExport, callback) {
        return $http.post("/api/TestExport/DeleteTestExport", testExport)
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getTestExports = function (callback) {
        return $http.get("/api/TestExport/GetTestExports")
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getTestExportsCount = function (callback) {
        return $http.get("/api/TestExport/GetTestExportsCount")
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getTestsForTestExportCreate = function (callback) {
        return $http.get("/api/TestExport/GetTestsForTestExportCreate")
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getTestExportsWithTestInfo = function (callback) {
        return $http.get("/api/TestExport/GetTestExportsWithTestInfo")
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getUsersWithInfo = function (callback) {
        return $http.get("/api/User/GetUsersWitnInfo")
            .success(function (data) {
                callback(data);
            })
    };

    webApiFactory.getUsersCount = function (callback) {
        return $http.get("/api/User/GetUsersCount")
            .success(function (data) {
                callback(data);
            })
    };

    return webApiFactory;
});