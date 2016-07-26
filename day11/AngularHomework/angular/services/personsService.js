var personsApp = angular.module('personsApp');

personsApp.factory('personsService', function ($http, $q) {

    return {
        getPersons: function () {
            var deferred = $q.defer();
            $http.get('angular/models/persons.json').success(function (response) {
                deferred.resolve(response);
            });
            return deferred.promise;
        }
    }
});