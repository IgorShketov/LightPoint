var personsApp = angular.module('personsApp');

personsApp.controller('personsController', personsController);

function personsController($scope, personsService, $http) {

    var promise = personsService.getPersons();
    promise.then(function (resolve) {
        $scope.persons = resolve;
    });

    $scope.phoneSelect = "Home phone Number";
    $scope.deletedPersonIndex;

    $scope.setDeletedPersonIndex = function (index) {
        $scope.deletedPersonIndex = index;
    }

    $scope.getPhone = function(person) {
        if ($scope.phoneSelect == "Home phone Number") {
            return person.phoneNumber[0].number;
        }
        else if ($scope.phoneSelect == "Fax") {
            return person.phoneNumber[1].number;
        }
    }

    function clearFields(person) {
        delete person._firstName;
        delete person._lastName;
        delete person._age;
        delete person._address;
        delete person._phoneNumber;
    }

    $scope.addNewPerson = function (person, form) {
        if(form.$valid)
        {
            var newPerson = {};

            newPerson.id = 1;
            newPerson.firstName = person._firstName;
            newPerson.lastName = person._lastName;
            newPerson.age = person._age;
            newPerson.address = person._address;
            newPerson.phoneNumber = [];
            newPerson.phoneNumber.push({ type: "home", number: person._phoneNumber[0].number });
            newPerson.phoneNumber.push({ type: "fax", number: person._phoneNumber[1].number });

            form.$setPristine();
            form.$setUntouched();

            $http.put('angular/models/persons.json', $scope.persons).then(function (data) {
                console.log('done');
            });

            $scope.persons.push(newPerson);
            $scope.dismiss();
            clearFields(person);
        }
    }

    $scope.removePerson = function (index) {
        $scope.persons.splice(index, 1);
    };
};

personsApp.filter('meFilter', function () {
    return function (persons, filterPattern) {
        if (filterPattern === undefined) {
            return persons;
        }
        else {
            var personsFiltered = [];
            persons.forEach(function (item) {
                if ((item.lastName + ' ' + item.firstName).toLowerCase().indexOf(filterPattern) !== -1 ||
                    (item.firstName + ' ' + item.lastName).toLowerCase().indexOf(filterPattern) !== -1) {
                    personsFiltered.push(item);
                }
            });
            return personsFiltered;
        }
    }
});

personsApp.directive('personModal', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            scope.dismiss = function () {
                element.modal('hide');
            };
        }
    }
});