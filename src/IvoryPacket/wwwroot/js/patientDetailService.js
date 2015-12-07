var patient;
(function (patient) {
    var services;
    (function (services) {
        var PatientDetailService = (function () {
            function PatientDetailService() {
            }
            PatientDetailService.$inject = [];
            return PatientDetailService;
        })();
        services.PatientDetailService = PatientDetailService;
        angular.module("patient").service("PatientDetailService", PatientDetailService);
    })(services = patient.services || (patient.services = {}));
})(patient || (patient = {}));
