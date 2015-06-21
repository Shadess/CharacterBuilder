(function () {
    var app = angular.module('SacredApp', ['ngCookies', 'SacredAdmin']).config(function ($locationProvider, $httpProvider) {
        $locationProvider.html5Mode(true);
        $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
    });

    // Controllers
    app.controller('ProfileController', ProfileController);

    // Factories
    app.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
})();