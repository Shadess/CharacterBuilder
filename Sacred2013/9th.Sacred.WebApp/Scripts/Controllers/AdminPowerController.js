var AdminPowerController = function ($scope, $window, $http, $cookies, $timeout) {
    // INIT FUNCTIONS
    $scope.GetBlankPower = function () {
        return {
            Id: 0,
            Name: '',
            Category: 1,
            CategoryId: 0,
            Type: 0,
            ActionType: 0,
            EffectType: 0,
            Range: 0,
            AuraRange: 0,
            Description: '',
            Tier: 0,
            Active: true,
            CategoryMapIds: []
        };
    };

    $scope.categoryValues = [{
        id: 1,
        label: "Race"
    }, {
        id: 2,
        label: "Class"
    }, {
        id: 3,
        label: "Heroic"
    }];


    // VARIABLES
    $scope.userCookie = $cookies.getObject(SACRED_COOKIE);
    $scope.ButtonText = "Add";
    $scope.PowerTab = 0;

    $scope.Power = $scope.GetBlankPower();
    $scope.ShowPowerSuccess = false;

    $scope.CategoryOptions = [];


    // FUNCTIONS
    $scope.AddPower = function () {
        console.log($scope.Power);
        //var apiUrl = $window.API_URL + "Race/AddRace";
        //if ($scope.ButtonText === "Save") {
        //    apiUrl = $window.API_URL + "Race/EditRace";
        //}

        //var data = {
        //    UserToken: $scope.userCookie.UserToken,
        //    Race: $scope.Race
        //}

        //$http.post(apiUrl, data).success(function (data) {
        //    $scope.ShowRaceSuccess = true;

        //    if ($scope.ButtonText === "Add") {
        //        $scope.Race.Id = data;
        //        $scope.$emit('RaceAddedEvent', $scope.Race);
        //        $scope.Race = $scope.GetBlankRace();
        //    }

        //    // Auto hide success alert
        //    $timeout(function () {
        //        $scope.ShowRaceSuccess = false;
        //    }, 2000);
        //});
    };


    $scope.SelectPower = function (power) {
        $scope.Power = power;
        $scope.PowerTab = power.Id;

        if (power.Id > 0) {
            $scope.ButtonText = "Save";
        }
        else {
            $scope.ButtonText = "Add";
        }
    };

    $scope.isSelected = function (value) {
        return $scope.PowerTab === value;
    };

    $scope.showDeleteButton = function () {
        return $scope.Power.Id > 0;
    };

    $scope.deletePower = function () {
        //var apiUrl = $window.API_URL + "Race/DeleteRaceById?userToken=" + $scope.userCookie.UserToken + "&id=" + $scope.Race.Id;
        //$http.get(apiUrl).success(function (data) {
        //    // Handle delete
        //    $scope.$emit('RaceDeletedEvent', $scope.Race);
        //    $scope.SelectRace($scope.GetBlankRace());
        //});
    };

    $scope.CategoryUpdate = function () {
        $scope.Power.CategoryId = 0;
    };

    $scope.categorySelected = function (value) {
        return $scope.Power.Category === value;
    };
};

AdminPowerController.$inject = ['$scope', '$window', '$http', '$cookies', '$timeout'];