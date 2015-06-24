var AdminClassController = function ($scope, $window, $http, $cookies, $timeout) {
    // INIT FUNCTIONS
    $scope.GetBlankClass = function () {
        return {
            Id: 0,
            Name: '',
            Role: '',
            FlavorText: '',
            Description: ''
        };
    };


    // VARIABLES
    $scope.userCookie = $cookies.getObject(SACRED_COOKIE);
    $scope.ButtonText = "Add";
    $scope.ClassTab = 0;

    $scope.Class = $scope.GetBlankClass();
    $scope.ShowClassSuccess = false;
    $scope.ClassList = [];
    $scope.ClassesLoading = true;


    // INIT WEB CALLS
    var apiURL = $window.API_URL + "Class/GetAll?userToken=" + $scope.userCookie.UserToken;
    $http.get(apiURL).success(function (data) {
        $scope.ClassList = data;
        $scope.ClassesLoading = false;
    });


    // FUNCTIONS
    $scope.AddClass = function () {
        var apiUrl = $window.API_URL + "Class/AddClass";
        if ($scope.ButtonText === "Save") {
            apiUrl = $window.API_URL + "Class/EditClass";
        }

        var data = {
            UserToken: $scope.userCookie.UserToken,
            Class: $scope.Class
        }

        $http.post(apiUrl, data).success(function (data) {
            $scope.ShowClassSuccess = true;

            if ($scope.ButtonText === "Add") {
                $scope.Class.Id = data;
                $scope.ClassList.push($scope.Class);
                $scope.Class = $scope.GetBlankClass();
            }

            // Auto hide success alert
            $timeout(function () {
                $scope.ShowClassSuccess = false;
            }, 2000);
        });
    };

    $scope.SelectClass = function (inClass) {
        $scope.Class = inClass;
        $scope.ClassTab = inClass.Id;

        if (inClass.Id > 0) {
            $scope.ButtonText = "Save";
        }
        else {
            $scope.ButtonText = "Add";
        }
    };

    $scope.isSelected = function (value) {
        return $scope.ClassTab === value;
    };

    $scope.showDeleteButton = function () {
        return $scope.Class.Id > 0;
    };

    $scope.deleteClass = function () {
        var apiUrl = $window.API_URL + "Class/DeleteClassById?userToken=" + $scope.userCookie.UserToken + "&id=" + $scope.Class.Id;
        $http.get(apiUrl).success(function (data) {
            // Handle delete
            $scope.ClassList.splice($scope.ClassList.indexOf($scope.Class), 1);
            $scope.SelectClass($scope.GetBlankClass());
        });
    };
};

AdminClassController.$inject = ['$scope', '$window', '$http', '$cookies', '$timeout'];