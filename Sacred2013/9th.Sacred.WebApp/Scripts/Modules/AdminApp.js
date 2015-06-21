(function () {
    var app = angular.module('SacredAdmin', ['ngCookies']).config(function ($httpProvider) {
        $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
    });

    // Controllers
    app.controller('AdminRaceController', AdminRaceController);

    // Factories
    app.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
})();