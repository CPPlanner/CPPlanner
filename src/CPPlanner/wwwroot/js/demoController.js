(function () {
    "use strict";

    // Getting the existing module
    angular.module("app-demo")
        .controller("demoController", demoController);

    function demoController($scope, myService) {

            var vm = this;
    
            vm.objects = [{
                name: "Cesar",
                created: new Date()
            }, {
                name: "Nelly",
                created: new Date()
            }];
        
        }
    })();
