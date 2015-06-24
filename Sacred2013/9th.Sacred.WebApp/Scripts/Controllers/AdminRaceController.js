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
    $scope.userCookie = $cookies.getObject(SACRED_COOKIE);
    $scope.ButtonText = "Add";
    $scope.RaceTab = 0;

    $scope.Race = $scope.GetBlankRace();
    $scope.ShowRaceSuccess = false;
    $scope.RaceList = [];
    $scope.RacesLoading = true;

    $scope.OriginChoices = ['Human', 'Fey', 'Fey/Human', 'Kar'];
    $scope.SocialStatusChoices = ['Very High', 'High', 'Medium', 'Low', 'Very Low', 'Extremely Low'];


    // INIT WEB CALLS
    var apiURL = $window.API_URL + "Race/GetAll?userToken=" + $scope.userCookie.UserToken;
    $http.get(apiURL).success(function (data) {
        $scope.RaceList = data;
        $scope.RacesLoading = false;
    });


    // FUNCTIONS
    $scope.AddRace = function () {
        var apiUrl = $window.API_URL + "Race/AddRace";
        if ($scope.ButtonText === "Edit") {
            apiUrl = $window.API_URL + "Race/EditRace";
        }

        var data = {
            UserToken: $scope.userCookie.UserToken,
            Race: $scope.Race
        }

        $http.post(apiUrl, data).success(function (data) {
            $scope.ShowRaceSuccess = true;

            if ($scope.ButtonText === "Add") {
                $scope.Race.Id = data;
                $scope.RaceList.push($scope.Race);
                $scope.Race = $scope.GetBlankRace();
            }

            // Auto hide success alert
            $timeout(function () {
                $scope.ShowRaceSuccess = false;
            }, 2000);
        });
    };

    $scope.SelectRace = function (race) {
        $scope.Race = race;
        $scope.RaceTab = race.Id;

        if (race.Id > 0) {
            $scope.ButtonText = "Edit";
        }
        else {
            $scope.ButtonText = "Add";
        }
    };

    $scope.isSelected = function (value) {
        return $scope.RaceTab === value;
    };

    $scope.showDeleteButton = function () {
        return $scope.Race.Id > 0;
    };

    $scope.deleteRace = function () {
        var apiUrl = $window.API_URL + "Race/DeleteRaceById?userToken=" + $scope.userCookie.UserToken + "&id=" + $scope.Race.Id;
        $http.get(apiUrl).success(function (data) {
            // Handle delete
            $scope.RaceList.splice($scope.RaceList.indexOf($scope.Race), 1);
            $scope.SelectRace($scope.GetBlankRace());
        });
    };
};

AdminRaceController.$inject = ['$scope', '$window', '$http', '$cookies', '$timeout'];