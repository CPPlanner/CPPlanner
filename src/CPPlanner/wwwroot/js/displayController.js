var app = angular.module("app-demo");

app.factory('myService', function($http) {
  var myService = {
    async: function() {
      var promise = $http.get('/json/test.json').then(function (response) {
        console.log(response);
        return response.data;
      });
      return promise;
    }
  };
  return myService;
});

app.controller('displayController', function(myService,$scope) {

  $scope.models = {
    selected: null,
    lists: {"Added": [], "Classes": []}
  }


  myService.async().then(function(d) {
    $scope.data = d;
    angular.forEach($scope.data,function(value,key){
      $scope.models.lists.Classes.push(value);
    });

    console.log($scope.models.lists.Classes[0]);

  });
});

