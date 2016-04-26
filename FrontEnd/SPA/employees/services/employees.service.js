(function () {
    'use strict';
    angular.module('tsi.employee').service('employeesService', ["$http", "$q", employeeService]);

    function employeeService($http, $q) {
        this.getAllEmployee = function () {
            var ret = "";
            /*$http.get("Employees/getAllEmployee").then(function (response) {
                                    console.debug(response.data);
                                    ret = response.data;
            });*/
            $.ajax({
                url: "Employees/getAllEmployee",
                type: 'GET',
                //async: false,
                success: function (response) {
                    //ret = response;
                    return response;
                },
                error: function (xhr, status, error) {
                    alert("Error");
                }
           });
           //return ret;
        }
    }
})();