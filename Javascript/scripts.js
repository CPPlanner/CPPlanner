var classApp = angular.module('classApp', []);
classApp.controller('ClassCtrl', function($scope,$http){
  $http.get('classes.json').then(function(reponse){
    $scope.names = reponse.data.cs;
    $scope.mathi = reponse.data.mat;
  });

  $scope.studentClasses= [];

  $scope.toggleActive = function(classes){
    classes.active = !classes.active;
  };


  $scope.addCourses = function(){

      angular.forEach($scope.names, function(classes){
        if (classes.active){
          $scope.studentClasses.push(classes.Name);
        }
      });
  };



  $scope.removeCourses = function(){
    console.log('Inside remove')
    angular.forEach($scope.studentClasses, function(remove){
      if (remove.active){
        $scope.studentClasses.pop(remove.Name);
      }
    });
  };
});
