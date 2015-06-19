var HomeController = function ($scope, $http, $window) {
    $scope.LoginErrorMessage = '';
    $scope.ShowHeaderLogin = true;

    $scope.login = function (user) {
        var validateUrl = $window.API_URL + "User/ValidateUser?email=" + user.email + "&password=" + user.password;
        $http.get(validateUrl).success(function (data) {
            if (!data.Success) {
                // Bad login
                $scope.LoginErrorMessage = data.Message;
                
                // TODO show login box
            }
        });
    };
}