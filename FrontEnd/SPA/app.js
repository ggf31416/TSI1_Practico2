(function () {

    angular.module('tsi', [
        'ngRoute',
        // Custom modules 
        'tsi.employee'
    ]);

    angular.module('tsi').config(['$routeProvider','$locationProvider', configFunction]);

    /*@ngInject*/
    function configFunction($routeProvider, $locationProvider) {
        $locationProvider.html5Mode({ enabled: true, requireBase: false}).hashPrefix('!');  

        // Routes
        $routeProvider
			.when("/", {
			    templateUrl: "index.html"
			})
            .when("/createEmployees", {
                templateUrl: "/SPA/employees/employees.html",
                controller: "employeesCtrl"
            })
            .when("/listEmployee", {
                templateUrl: "listEmployee.html",
                controller: "listEmployeesCtrl"
            }).otherwise({ redirectTo: '/' });
    }
})();