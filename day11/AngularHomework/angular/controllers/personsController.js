var personsApp = angular.module('personsApp');

personsApp.controller('personsController', personsController);

function personsController($scope, $http) {

    $http.get('angular/models/persons.json').success(function (response) {
        $scope.persons = response;
    });

    $scope.phoneSelect = "Home phone Number";

    $scope.getPhone = function(person) {
        if ($scope.phoneSelect == "Home phone Number") {
            return person.phoneNumber[0].number;
        }
        else if ($scope.phoneSelect == "Fax") {
            return person.phoneNumber[1].number;
        }
    }

    $scope.removePerson = function (row) {
        $scope.persons.splice($scope.persons.indexOf(row), 1);
    };
};