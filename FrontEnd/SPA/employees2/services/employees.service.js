(function () {
    'use strict';
    angular.module('tsi.employee').service('employeesService', ["$http", "$q", employeeService]);

    function employeeService($http, $q) { }
})();