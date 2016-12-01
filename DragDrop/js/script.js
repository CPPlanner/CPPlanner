var app = angular.module("app", ['dndLists', 'ngMaterial', 'ngMessages','material.svgAssetsCache'])
.controller('AppCtrl', function($scope, $timeout, $mdSidenav, $log){
  $scope.toggleLeft = buildDelayedToggler('left');

  function debounce(func, wait, context) {
    var timer;

    return function debounced() {
      var context = $scope,
          args = Array.prototype.slice.call(arguments);
      $timeout.cancel(timer);
      timer = $timeout(function() {
        timer = undefined;
        func.apply(context, args);
      }, wait || 10);
    };
  }

  function buildDelayedToggler(navID) {
    return debounce(function() {
      $mdSidenav(navID)
        .toggle()
        .then(function () {
      });
    }, 200);
  }

  function buildToggler(navID) {
    return function() {
      $mdSidenav(navID)
        .toggle()
        .then(function () {
      });
    }
  }
})

app.controller('LeftCtrl', function ($scope, $timeout, $mdSidenav, $log) {
  $scope.close = function () {
    // Component lookup should always be available since we are not using `ng-if`
    $mdSidenav('left').close()
      .then(function () {
    });
  };
});


app.factory('myService', function($http) {
  var myService = {
    async: function() {
      var promise = $http.get("dCatalog.json").then(function (response) {
//        console.log(response);
        return response.data;
      });
      return promise;
    }
  };
  return myService;
});


app.controller('MainCtrl', function(myService,$scope) {

  // Variables
  $scope.courseNumber;
  $scope.courseTitle;
  $scope.courseUnits;
  $scope.counter = 0;  //TODO find a way to eliminate global counter
  $scope.total = 0;
  $scope.temp = 0;


  $scope.models = {
    selected: null,
    lists: {},
    catalogList: {"Classes": []}
  }

  $scope.addNew = function() {

      var newArray = [];
      $scope.models.lists["Added" + $scope.counter] = newArray;
      $scope.counter++;
  };

  // Populate course lists
  myService.async().then(function(d) {
    $scope.data = d;
    angular.forEach($scope.data,function(value,key){
      $scope.models.catalogList.Classes.push(value);
    });

//    console.log($scope.models.catalogList.Classes[0]);
  });

  // Display course information when clicked
  $scope.displayInfo = function(item) {
      $scope.courseNumber = item.number;
      $scope.courseTitle = item.title;
      $scope.courseUnits = item.units;
  };

  $scope.getTotalUnits = function() {
//    var sum = 0;
//    $('.module-units').each(function(i, obj) {
//      sum = sum + obj.innerHTML;
//    });
//    $scope.sumUnits += sum;
  };





    $scope.units = function(array) {

        var sum = 0;

        if(array)
        {
            for(var i = 0; i < array.length; i++){
                   sum = sum + array[i].units;
                  // $scope.addAllUnits(temp);
            }
        }
        return sum;
    };
});
