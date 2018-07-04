var ClinicControllers = angular.module("ClinicControllers", []);

ClinicControllers.controller("PatientListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('/api/patient').then(function (data) {
            $scope.patients = data.data;
        });
    }
]);

ClinicControllers.controller("PatientDeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/patient/' + $routeParams.id).then(function (data) {
            $scope.DocumentNumber = data.data.DocumentNumber
            $scope.FirstName = data.data.FirstName;
            $scope.LastName = data.data.LastName;
            $scope.Birth = data.data.Birth;
            $scope.PhoneNumber = data.data.PhoneNumber;
            $scope.Address = data.data.Address;
        });
        $scope.delete = function () {
            $http.delete('/api/patient/' + $scope.id).then(function (data) {
                $location.path('/PatientList');
            }).catch(function (data) {
                $scope.error = "An error has occured while deleting patient! " + data;
            });
        };
    }
]);


ClinicControllers.controller("PatientEditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        $http.get('/api/patient').then(function (data) {
            $scope.patients = data.data;
        });
        $scope.id = 0;

        $scope.save = function () {
            var obj = {
                Id: $scope.Id,
                DocumentNumber: $scope.DocumentNumber,
                FirstName: $scope.FirstName,
                LastName: $scope.LastName,
                Birth: $scope.Birth,
                PhoneNumber: $scope.PhoneNumber,
                Address: $scope.Address
            };
            if ($scope.id == 0) {
                $http.post('/api/patient/', obj).then(function (data) {
                    $location.path('/PatientList');
                }).catch(function (data) {
                    $scope.error = "An error has occured while adding patient! " + data.data.ExceptionMessage;
                });
            }
            else {
                $http.put('/api/patient/', obj).then(function (data) {
                    $location.path('/PatientList');
                }).catch(function (data) {
                    console.log(data);
                    $scope.error = "An Error has occured while Saving patient! " + data.data.ExceptionMessage;
                });
            }
        }
        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Edit patient";
            $http.get('/api/patient/' + $routeParams.id).then(function (data) {
                $scope.Id = data.data.Id;
                $scope.DocumentNumber = data.data.DocumentNumber;
                $scope.FirstName = data.data.FirstName;
                $scope.LastName = data.data.LastName;
                $scope.Birth = data.data.Birth;
                $scope.PhoneNumber = data.data.PhoneNumber;
                $scope.Address = data.data.Address;
            });
        }
        else {
            $scope.title = "Create New patient";
        }
    }
]);

ClinicControllers.controller("DoctorListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('/api/doctor').then(function (data) {
            $scope.doctors = data.data;
        });
    }
]);

ClinicControllers.controller("DoctorDeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/doctor/' + $routeParams.id).then(function (data) {
            $scope.DocumentNumber = data.data.DocumentNumber
            $scope.FirstName = data.data.FirstName;
            $scope.LastName = data.data.LastName;
            $scope.PhoneNumber = data.data.PhoneNumber;
        });
        $scope.delete = function () {
            $http.delete('/api/doctor/' + $scope.id).then(function (data) {
                $location.path('/DoctorList');
            }).catch(function (data) {
                $scope.error = "An error has occured while deleting patient! " + data;
            });
        };
    }
]);


ClinicControllers.controller("DoctorEditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        $http.get('/api/doctor').then(function (data) {
            $scope.doctors = data.data;
        });
        $scope.id = 0;

        $scope.save = function () {
            var obj = {
                Id: $scope.Id,
                DocumentNumber: $scope.DocumentNumber,
                FirstName: $scope.FirstName,
                LastName: $scope.LastName,
                PhoneNumber: $scope.PhoneNumber
            };
            if ($scope.id == 0) {
                $http.post('/api/doctor/', obj).then(function (data) {
                    $location.path('/DoctorList');
                }).catch(function (data) {
                    $scope.error = "An error has occured while adding patient! " + data.data.ExceptionMessage;
                });
            }
            else {
                $http.put('/api/doctor/', obj).then(function (data) {
                    $location.path('/DoctorList');
                }).catch(function (data) {
                    console.log(data);
                    $scope.error = "An Error has occured while Saving customer! " + data.data.ExceptionMessage;
                });
            }
        }
        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Edit Doctor";
            $http.get('/api/doctor/' + $routeParams.id).then(function (data) {
                $scope.Id = data.data.Id;
                $scope.DocumentNumber = data.data.DocumentNumber;
                $scope.FirstName = data.data.FirstName;
                $scope.LastName = data.data.LastName;
                $scope.PhoneNumber = data.data.PhoneNumber;
            });
        }
        else {
            $scope.title = "Create New Doctor";
        }
    }
]);

ClinicControllers.controller("CitaListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('/api/cita').then(function (data) {
            $scope.citas = data.data;
        });
    }
]);

ClinicControllers.controller("CitaDeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/cita/' + $routeParams.id).then(function (data) {
            $scope.DocumentNumber = data.data.DocumentNumber
            $scope.FirstName = data.data.FirstName;
            $scope.LastName = data.data.LastName;
            $scope.PhoneNumber = data.data.PhoneNumber;
        });
        $scope.delete = function () {
            $http.delete('/api/cita/' + $scope.id).then(function (data) {
                $location.path('/CitaDeleteList');
            }).catch(function (data) {
                $scope.error = "An error has occured while deleting cita! " + data;
            });
        };
    }
]);


ClinicControllers.controller("CitaEditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        $http.get('/api/Patient').then(function (data) {
            $scope.Patients = data.data;
        });
        $scope.id = 0;

        $http.get('/api/Doctor').then(function (data) {
            $scope.Doctors = data.data;
        });

        $http.get('/api/CitaType').then(function (data) {
            $scope.CitaTypes = data.data;
        });

        $scope.save = function () {
            var obj = {
                Id: $scope.Id,
                DocumentNumber: $scope.DocumentNumber,
                FirstName: $scope.FirstName,
                LastName: $scope.LastName,
                PhoneNumber: $scope.PhoneNumber
            };
            if ($scope.id == 0) {
                $http.post('/api/cita/', obj).then(function (data) {
                    $location.path('/CitaList');
                }).catch(function (data) {
                    $scope.error = "An error has occured while adding patient! " + data.data.ExceptionMessage;
                });
            }
            else {
                $http.put('/api/cita/', obj).then(function (data) {
                    $location.path('/CitaList');
                }).catch(function (data) {
                    console.log(data);
                    $scope.error = "An Error has occured while Saving Cita! " + data.data.ExceptionMessage;
                });
            }
        }
        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Edit Cita";
            $http.get('/api/cita/' + $routeParams.id).then(function (data) {
                $scope.Id = data.data.Id;
                $scope.DocumentNumber = data.data.DocumentNumber;
                $scope.FirstName = data.data.FirstName;
                $scope.LastName = data.data.LastName;
                $scope.PhoneNumber = data.data.PhoneNumber;
            });
        }
        else {
            $scope.title = "Create New Cita";
        }
    }
]);

ClinicControllers.controller("CitaTypeListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('/api/citaType').then(function (data) {
            $scope.citaTypes = data.data;
        });
    }
]);


ClinicControllers.controller("CitaTypeDeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/citaType/' + $routeParams.id).then(function (data) {
            $scope.Name = data.data.Name;
            $scope.Description = data.data.Description;
        });
        $scope.delete = function () {
            $http.delete('/api/citaType/' + $scope.id).then(function (data) {
                $location.path('/CitaTypeList');
            }).catch(function (data) {
                $scope.error = "An error has occured while deleting cita Type! " + data;
            });
        };
    }
]);


ClinicControllers.controller("CitaTypeEditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        $http.get('/api/citaType').then(function (data) {
            $scope.citaTypes = data.data;
        });
        $scope.id = 0;

        $scope.save = function () {
            var obj = {
                Id: $scope.Id,
                Name: $scope.Name,
                Description: $scope.Description
            };
            if ($scope.id == 0) {
                $http.post('/api/CitaType/', obj).then(function (data) {
                    $location.path('/CitaTypeList');
                }).catch(function (data) {
                    $scope.error = "An error has occured while adding cita type! " + data.data.ExceptionMessage;
                });
            }
            else {
                $http.put('/api/citatype/', obj).then(function (data) {
                    $location.path('/CitaTypeList');
                }).catch(function (data) {
                    console.log(data);
                    $scope.error = "An Error has occured while Saving cita types! " + data.data.ExceptionMessage;
                });
            }
        }
        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Edit patient";
            $http.get('/api/CitaType/' + $routeParams.id).then(function (data) {
                $scope.Id = data.data.Id;
                $scope.Name = data.data.Name;
                $scope.Description = data.data.Description;
            });
        }
        else {
            $scope.title = "Create New Cita Type";
        }
    }
]);