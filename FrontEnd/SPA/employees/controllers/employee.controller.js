(function () {
    'use strict';
    angular.module('tsi.employee').controller("employeesCtrl", ["employeesService", '$scope', employeesCtrl]);

    function employeesCtrl(employeesService, $scope) {
        $scope.title = "Create New Employee";
    }

    angular.module('tsi.employee').controller("listEmployeesCtrl", ["employeesService", '$scope', listEmployeesCtrl]);

    function listEmployeesCtrl(employeesService, $scope) {
        $scope.title = "List Employee";

        $scope.listEmployees = employeesService.getAllEmployee();
        console.debug($scope.listEmployees);
    }
})();