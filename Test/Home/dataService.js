var CoursesService = angular.module('CPPlanner', [])
.service('dataService',function(){
  var listItem = [{Product:"CS130", Desc: "Didnt like this class", Units: 4},
                  {Product:"CS140", Desc: "Beginning Java", Units: 4},
                  {Product:"CS141", Desc: "Java2", Units: 4},
                  {Product:"CS240", Desc: "Data Structures", Units: 4}];
  var addList = function(newObj){
    listItem.push(newObj);
  };

  var getList = function(){
   return listItem;
  };

  return{
   addList: addList,
   getList: getList
  };
});
