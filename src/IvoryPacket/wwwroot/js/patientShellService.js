//Manages currently open patients.
var patient;
(function (patient) {
    var services;
    (function (services) {
        var PatientShellService = (function () {
            function PatientShellService($http) {
                this.$http = $http;
                this.currentPatient = {
                    patientId: 0,
                    title: null,
                    givenName: null,
                    middleNames: null,
                    familyName: null,
                    preferredName: null,
                    gender: null,
                    dateOfBirth: null,
                    ethnicity: null,
                    isActive: true,
                    homePhone: null,
                    workPhone: null,
                    mobilePhone: null,
                    medicareCardNumber: null,
                    medicareCardExpiry: null,
                    medicareCardPosition: null,
                    allergies: [],
                    contactPoints: []
                };
            }
            PatientShellService.prototype.getPatientById = function (patientId) {
                var _this = this;
                this.$http.get("api/patients" + patientId).then(function (result) {
                    //Todo: check if patient isn't already open.
                    angular.copy(result.data, _this.currentPatient);
                    _this.activatePatient();
                });
            };
            PatientShellService.prototype.savePatient = function () {
                var _this = this;
                return this.$http.post("api/patients/", this.currentPatient).then(function (result) {
                    angular.copy(_this.currentPatient, result.data);
                }, function (error) {
                });
            };
            PatientShellService.prototype.activatePatient = function () {
            };
            PatientShellService.$inject = ["$http"];
            return PatientShellService;
        })();
        services.PatientShellService = PatientShellService;
        angular.module("patient").service("PatientShellService", patient.services.PatientShellService);
    })(services = patient.services || (patient.services = {}));
})(patient || (patient = {}));
