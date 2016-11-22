var app = angular.module("app", ['dndLists']);

app.factory('myService', function($http) {
  var myService = {
    async: function() {
      var promise = $http.get("dCatalog.json").then(function (response) {
        console.log(response);
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
 
    
  $scope.models = {
    selected: null,
    lists: {"Added": [], "Classes": []}
  }

  // Populate course lists
  myService.async().then(function(d) {
    $scope.data = d;
    angular.forEach($scope.data,function(value,key){
      $scope.models.lists.Classes.push(value);
    });

    console.log($scope.models.lists.Classes[0]);
  });
    
  // Display course information when clicked    
  $scope.displayInfo = function(item) {
      $scope.courseNumber = item.number;
      $scope.courseTitle = item.title;
      $scope.courseUnits = item.units;
  }; 
      
    
});

