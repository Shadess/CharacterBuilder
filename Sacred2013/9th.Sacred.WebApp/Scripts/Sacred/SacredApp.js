(function () {
    var app = angular.module('SacredApp', ['SacredHomeApp']);

    app.controller('LoginController', ['$scope', '$http', '$window', LoginController]);
})();