var AdminController = function ($scope, $http, $window, $cookies) {
    var self = this;


    // Variables
    self.tab = 1;
    self.userCookie = $cookies.getObject(SACRED_COOKIE);

    self.RaceList = [];
    self.RacesLoading = true;
    self.ClassList = [];
    self.ClassesLoading = true;
    self.PowerList = [];
    self.PowersLoading = true;


    // Init functions
    var apiURL = $window.API_URL + "Race/GetAll?userToken=" + self.userCookie.UserToken;
    $http.get(apiURL).success(function (data) {
        self.RaceList = data;
        self.RacesLoading = false;
    });

    var classesApiURL = $window.API_URL + "Class/GetAll?userToken=" + self.userCookie.UserToken;
    $http.get(classesApiURL).success(function (data) {
        self.ClassList = data;
        self.ClassesLoading = false;
    });

    var powersApiUrl = $window.API_URL + "Power/GetAll?userToken=" + self.userCookie.UserToken;
    $http.get(powersApiUrl).success(function (data) {
        self.PowerList = data;
        self.PowersLoading = false;
    });


    // Functions
    self.selectTab = function (value) {
        self.tab = value;
    };

    self.isSelected = function (checkTab) {
        return self.tab === checkTab;
    };


    // Events
    $scope.$on('RaceDeletedEvent', function (event, args) {
        self.RaceList.splice(self.RaceList.indexOf(args), 1);
    });

    $scope.$on('RaceAddedEvent', function (event, args) {
        self.RaceList.push(args);
    });

    $scope.$on('ClassDeletedEvent', function (event, args) {
        self.ClassList.splice(self.ClassList.indexOf(args), 1);
    });

    $scope.$on('ClassAddedEvent', function (event, args) {
        self.ClassList.push(args);
    });
};

AdminController.$inject = ['$scope', '$http', '$window', '$cookies'];