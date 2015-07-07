var AdminRaceController = function ($scope, $window, $http, $cookies, $timeout) {
    // VARIABLES
    $scope.userCookie = $cookies.getObject(SACRED_COOKIE);
    $scope.ButtonText = "Add";
    $scope.RaceTab = 0;

    $scope.Race = new $window.SacredRace();
    $scope.ShowRaceSuccess = false;

    $scope.OriginChoices = ['Human', 'Fey', 'Fey/Human', 'Kar'];
    $scope.SocialStatusChoices = ['Very High', 'High', 'Medium', 'Low', 'Very Low', 'Extremely Low'];


    // FUNCTIONS
    $scope.AddRace = function () {
        var apiUrl = $window.API_URL + "Race/AddRace";
        if ($scope.ButtonText === "Save") {
            apiUrl = $window.API_URL + "Race/EditRace";
        }

        var data = {
            UserToken: $scope.userCookie.UserToken,
            Race: $scope.Race
        }

        $http.post(apiUrl, data).success(function (data) {
            $scope.ShowRaceSuccess = true;
            $scope.Race = data;

            if ($scope.ButtonText === "Add") {
                $scope.$emit('RaceAddedEvent', $scope.Race);
                $scope.Race = new $window.SacredRace();
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
            $scope.ButtonText = "Save";
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
            $scope.$emit('RaceDeletedEvent', $scope.Race);
            $scope.SelectRace(new $window.SacredRace());
        });
    };

    $scope.ResetRace = function () {
        return new $window.SacredRace();
    };

    $scope.AddPower = function () {
        $scope.Race.RacePowers.push(new $window.SacredRacePower());
    };

    $scope.RemovePower = function (power) {
        var apiUrl = $window.API_URL + "Race/RemovePowerById?userToken=" + $scope.userCookie.UserToken + "&id=" + power.Id;
        $http.get(apiUrl).success(function (data) {
            // Remove power from array
            $scope.Race.RacePowers.splice($scope.Race.RacePowers.indexOf(power), 1);
        });
    };
};

AdminRaceController.$inject = ['$scope', '$window', '$http', '$cookies', '$timeout'];