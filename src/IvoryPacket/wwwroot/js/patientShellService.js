var patient;
(function (patient) {
    var services;
    (function (services) {
        var PatientShellService = (function () {
            function PatientShellService() {
            }
            return PatientShellService;
        })();
        services.PatientShellService = PatientShellService;
        angular.module("patient").service("PatientShellService", patient.services.PatientShellService);
    })(services = patient.services || (patient.services = {}));
})(patient || (patient = {}));
