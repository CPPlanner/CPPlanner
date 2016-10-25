(function () {
    "use strict";

    // Creating the module
    angular.module("app-demo", ["ngRoute"])
        .config(function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "demoController",
                controllerAs: "vm",
                templateUrl: "/views/demoView.html"
            });

            $routeProvider.when("/detail/:name", {
                controller: "demo2Controller",
                controllerAs: "vm",
                templateUrl: "/views/demo2View.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });
        });
})();