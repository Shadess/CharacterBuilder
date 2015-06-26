var AdminPowerController = function ($scope, $window, $http, $cookies, $timeout) {
    // INIT FUNCTIONS
    $scope.GetBlankPower = function () {
        return {
            Id: 0,
            Name: '',
            Category: 0,
            Type: 0,
            ActionType: 0,
            EffectType: 0,
            Range: 0,
            AuraRange: 0,
            Description: '',
            Tier: 0,
            Active: true
        };
    };


    // VARIABLES
    $scope.userCookie = $cookies.getObject(SACRED_COOKIE);
    $scope.ButtonText = "Add";
    $scope.PowerTab = 0;

    $scope.Power = $scope.GetBlankPower();
    $scope.ShowPowerSuccess = false;
};

AdminRaceController.$inject = ['$scope', '$window', '$http', '$cookies', '$timeout'];