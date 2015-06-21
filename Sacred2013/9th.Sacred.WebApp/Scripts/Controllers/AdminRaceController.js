var AdminRaceController = function ($scope, $window, $http, $cookies, $timeout) {
    // INIT FUNCTIONS
    $scope.GetBlankRace = function () {
        return {
            Id: 0,
            Name: '',
            CommonName: '',
            Lifespan: '',
            Height: '',
            Origin: 'Human',
            SocialStatus: 'Very High',
            FlavorText: '',
            Description: ''
        };
    };


    // VARIABLES
    $scope.Race = $scope.GetBlankRace();
    $scope.ShowRaceSuccess = false;

    $scope.OriginChoices = ['Human', 'Fey', 'Fey/Human', 'Kar'];
    $scope.SocialStatusChoices = ['Very High', 'High', 'Medium', 'Low', 'Very Low', 'Extremely Low'];


    // FUNCTIONS
    $scope.AddRace = function () {
        var userCookie = $cookies.getObject(SACRED_COOKIE);
        var apiUrl = $window.API_URL + "Race/AddRace";
        var data = {
            UserToken: userCookie.UserToken,
            Race: $scope.Race
        }

        $http.post(apiUrl, data).success(function (data) {
            $scope.ShowRaceSuccess = true;
            $scope.Race = $scope.GetBlankRace();

            // Auto hide success alert
            $timeout(function () {
                $scope.ShowRaceSuccess = false;
            }, 2000);
        });
    };
};

AdminRaceController.$inject = ['$scope', '$window', '$http', '$cookies', '$timeout'];