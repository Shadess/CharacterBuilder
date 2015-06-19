var AuthHttpResponseInterceptor = function ($q, $window) {
    return {
        response: function (response) {
            if (response.status === 401) {
                console.log("Response 401");
            }
            return response || $q.when(response);
        },
        responseError: function (rejection) {
            if (rejection.status === 401) {
                console.log("Response Error 401", rejection);
                $window.location = $window.SITE_URL + 'Account/Logout';
            }
            return $q.reject(rejection);
        }
    };
};

AuthHttpResponseInterceptor.$inject = ['$q', '$window'];