(function () {
    "use strict";

    // Getting the existing module
    angular.module("app-demo")
        .controller("demo2Controller", demo2Controller);

    function demo2Controller($routeParams, $http) {
        var vm = this;
        vm.catalogs = [];
        vm.errorMessage = "";
        vm.isBusy = true;

        vm.thisName = $routeParams.name;

        $http.get("/api/catalog/")
            .then(function (response) {
                // success
                angular.copy(response.data, vm.catalogs)
            }, function (error) {
                // failure
                vm.errorMessage = "Failed to retrieve catalog from user: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }

})();
