var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        var PatientSummaryController = (function () {
            function PatientSummaryController() {
            }
            return PatientSummaryController;
        })();
        controllers.PatientSummaryController = PatientSummaryController;
        angular.module("patient").controller("PatientSummaryController", patient.controllers.PatientSummaryController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
