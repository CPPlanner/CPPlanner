(function () {
    "use strict";

    // Creating the module
    angular.module("app-demo", ['dndLists', 'ngRoute'])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "displayController",
                templateUrl: "/views/displayView.html"
            });

            $routeProvider.when("/detail/", {
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