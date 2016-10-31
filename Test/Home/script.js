// script.js

var CPPlanner = angular.module('CPPlanner', ['ngRoute', 'ngAnimate']);

// configure our routes
CPPlanner.config(function($routeProvider) {
  $routeProvider

  // route for the home page
    .when('/', {
    templateUrl : 'home.html',
    controller  : 'mainController'
  })

  // route for the guide page
    .when('/guide', {
    templateUrl : 'guide.html',
    controller  : 'guideController'
  })

  //route for the planner page
  .when('/planner',{
    templateUrl : 'planner.html',
    controller  : 'plannerController'
  })

});


//planner page controller
CPPlanner.controller('plannerController', function($scope){
  //planner Controller
  $scope.pageClass = 'planner';
});



//home page controller
CPPlanner.controller('mainController', function($scope) {
  $scope.message = 'Planning your future made easy!';
  $scope.pageClass = 'home';
});

//guid page controller
CPPlanner.controller('guideController', function($scope) {

  $scope.message = 'Welcome to the guide.';
  $scope.pageClass = 'guide'


  $scope.items = [
    {Product:"CS130", Desc: "Didnt like this class", Units: 4},
    {Product:"CS140", Desc: "Beginning Java", Units: 4},
    {Product:"CS141", Desc: "Java2", Units: 4},
    {Product:"CS240", Desc: "Data Structures", Units: 4}
  ];
  $scope.editing = false;
//  $scope.addItem = function(item){
//    $scope.items.push(item);
//    $scope.item={};
//  };

  $scope.myCartItem = []

  $scope.addToCart = function(item){
    $scope.myCartItem.push(item);
  }


  $scope.resetClasses = function(){
    $scope.myCartItem = []
  }

});


