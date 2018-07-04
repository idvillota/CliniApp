var ClinicApp = angular.module('ClinicApp', ['ngRoute', 'ClinicControllers']);

ClinicApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/PatientList',
    {
        templateUrl: 'Patient/list.html',
        controller: 'PatientListController'
    }).
    when('/PatientCreate',
    {
        templateUrl: 'Patient/edit.html',
        controller: 'PatientEditController'
    }).
    when('/PatientEdit/:id',
    {
        templateUrl: 'Patient/edit.html',
        controller: 'PatientEditController'
    }).
    when('/PatientDelete/:id',
    {
        templateUrl: 'Patient/delete.html',
        controller: 'PatientDeleteController'
    }).
    when('/DoctorList',
    {
        templateUrl: 'Doctor/list.html',
        controller: 'DoctorListController'
    }).
    when('/DoctorCreate',
    {
        templateUrl: 'Doctor/edit.html',
        controller: 'DoctorEditController'
    }).
    when('/DoctorEdit/:id',
    {
        templateUrl: 'Doctor/edit.html',
        controller: 'DoctorEditController'
    }).
    when('/DoctorDelete/:id',
    {
        templateUrl: 'Doctor/delete.html',
        controller: 'DoctorDeleteController'
    }).
    when('/CitaList',
    {
        templateUrl: 'Cita/list.html',
        controller: 'CitaListController'
    }).
    when('/CitaCreate',
    {
        templateUrl: 'Cita/edit.html',
        controller: 'CitaEditController'
    }).
    when('/CitaEdit/:id',
    {
        templateUrl: 'Cita/edit.html',
        controller: 'CitaEditController'
    }).
    when('/CitaDelete/:id',
    {
        templateUrl: 'Cita/delete.html',
        controller: 'CitaDeleteController'
    }).
    when('/CitaTypeList',
    {
        templateUrl: 'CitaType/list.html',
        controller: 'CitaTypeListController'
    }).
    when('/CitaTypeCreate',
    {
        templateUrl: 'CitaType/edit.html',
        controller: 'CitaTypeEditController'
    }).
    when('/CitaTypeEdit/:id',
    {
        templateUrl: 'CitaType/edit.html',
        controller: 'CitaTypeEditController'
    }).
    when('/CitaTypeDelete/:id',
    {
        templateUrl: 'CitaType/delete.html',
        controller: 'CitaTypeDeleteController'
    }).
    otherwise(
    {
        redirectTo: '/CitaList'
    });
}]);