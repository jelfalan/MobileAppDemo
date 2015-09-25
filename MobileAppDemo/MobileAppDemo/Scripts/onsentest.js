var module = ons.bootstrap('my-app', ['onsen']);
module.controller('AppController', function ($scope) { });
module.controller('pageController', function ($scope) {
    ons.ready(function () {
        //init code
    });
});