(function () {
    var app = angular.module('SacredAdmin', ['ngCookies']).config(function ($httpProvider) {
        $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
    });

    // Controllers
    app.controller('AdminController', AdminController);
    app.controller('AdminRaceController', AdminRaceController);
    app.controller('AdminClassController', AdminClassController);

    // Factories
    app.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
})();