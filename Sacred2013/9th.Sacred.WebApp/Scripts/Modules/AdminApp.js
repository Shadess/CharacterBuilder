(function () {
    var app = angular.module('SacredAdmin', ['ngCookies', 'checklist-model']).config(function ($httpProvider) {
        $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
    });

    // Controllers
    app.controller('AdminController', AdminController);
    app.controller('AdminRaceController', AdminRaceController);
    app.controller('AdminClassController', AdminClassController);
    app.controller('AdminPowerController', AdminPowerController);

    // Factories
    app.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
})();