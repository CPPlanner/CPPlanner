var app = angular.module("app", ['dndLists', 'ngMaterial', 'ngMessages','material.svgAssetsCache'])
.controller('AppCtrl', function($scope, $timeout, $mdSidenav, $log){
  $scope.toggleLeft = buildDelayedToggler('left');
//  $scope.toggleRight = buildToggler('right');

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
  $scope.totalUnits = 0;
  $scope.errorMessage = "";


  $scope.models = {
    selected: null,
    lists: [],
    catalogList: {"Classes": []}
  }

  // Populate course lists
  myService.async().then(function(d) {
    $scope.data = d;
    angular.forEach($scope.data,function(value,key){
      $scope.models.catalogList.Classes.push(value);
    });
  });

  // Add new semester box
  $scope.addNew = function() {
      var newArray = [];
      $scope.models.lists.push(newArray);
  };

  // Remove existing semester box
  $scope.remove = function(array) {
      $scope.errorMessage = "";
      var index = $scope.models.lists.indexOf(array);

      // remove array from list
      if(index > -1) {
          // make sure array is empty.
          if(array.length != 0) {
              $scope.errorMessage = "Semester contains courses. Empty container before removing.";
          } else {
              $scope.models.lists.splice(index, 1);
          }
      }
  };

  // Display course information when clicked
  $scope.displayInfo = function(item) {
      $scope.courseNumber = item.number;
      $scope.courseTitle = item.title;
      $scope.courseUnits = item.units;
  };

  // Display container units
  $scope.units = function(array) {
      var sum = 0;
      if(array) {
          for(var i=0; i<array.length; i++) {
              sum = sum + array[i].units;
          }
      }
      updateTotalUnits();
      return sum;
  };

  // Update total units
  var updateTotalUnits = function() {
      var sum = 0;
      $('.module-units').each(function(i, obj) {
         sum = sum + parseInt(obj.innerHTML);
      });
      $scope.totalUnits = sum;
  };

});

