var ProfileController = function ($scope, $window, $http, $cookies, $location) {
    $scope.User = null;
    $scope.CanEdit = false;

    var userCookie = $cookies.getObject(SACRED_COOKIE);
    var queryArray = $location.url().split("/");
    var queryUserId = parseInt(queryArray[queryArray.length - 1]);

    var getUrl = $window.API_URL + "User/GetUserById?userToken=" + userCookie.UserToken + "&userId=" + queryUserId;
    $http.get(getUrl).success(function (data) {
        $scope.User = data;
        console.log(data);
        //if (data == undefined || data == null) {
        //    if (userCookie.UserId === queryUserId) {
        //        $window.location = $window.SITE_URL + 'Account/Logout';
        //    }
        //    $window.location = $window.SITE_URL + "User/Profile/" + 
        //}
    });
};

ProfileController.$inject = ['$scope', '$window', '$http', '$cookies', '$location'];