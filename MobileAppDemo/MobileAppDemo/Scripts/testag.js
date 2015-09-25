//var testApp = angular.module('testApp', ['localForageModule'])

//testApp.controller('testController', ['$scope', '$localForage', function ($scope, $localForage) {
//    localforage.getItem('key').then(function (data) {
//        var myVar = data;
//        alert(JSON.stringify(value));
//     //   $localForage.bind($scope,myVar);
//    },
//    function (error) {
//        console.error("error on localforage get");
//    });
//    $scope.message = strValue;
//    }]);

var data = "This message was served up with Angular!";

//model
baseObj = function (objVal) {
    this.objVal = objVal;
};

//init object with data
newObj = new baseObj(data);

//store data in local DB
localforage.setItem('key', newObj, function (err, result) {
    alert("obj val: " + newObj.objVal);
});

//controller
var testApp = angular.module('testApp', ['']);
testApp.controller('testController', ['$scope', function ($scope) {
    //tie to dom
    $scope.message = newObj.objVal;

}]);

//localforage.setItem('key', obj, function (err, result) {

//    //some code to execute
//    localforage.getItem('key', function (err, value) {
//        var val = JSON.stringify(value);
//        alert("get Item: " + val);
//        newObj = new baseObj(val);
//        //testApp.setObjItem(value, newObj.setVal, newObj);
//        alert("object value = " + newObj.objVal);
//    });

//});







