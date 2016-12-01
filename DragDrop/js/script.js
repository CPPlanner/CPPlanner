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
    var sum = 0;
    $('.module-units').each(function(i, obj) {
      sum = sum + obj.innerHTML;
    });
    $scope.sumUnits += sum;
  };





    $scope.units = function(array) {
       // console.log(array);

        /*var sum = 0;
        $scope.sum = 0;
        console.log(sum);
        if(array)
        {
            for(var i = 0; i < array.length; i++){
                   sum = sum + array[i].units;
            }
        }
        $scope.sum = sum;*/

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

  // Adding new divs
   /*$(function() {
      $("#addUserModule").click(function() {
          div = document.createElement('div');
          $(div).addClass("inner").html("new inner div");
          $("#schedule-bank").append(div);
        });
    });*/


});

