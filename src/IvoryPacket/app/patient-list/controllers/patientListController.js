var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        "use strict";
        var PatientListController = (function () {
            function PatientListController(patientListService, patientManagerService) {
                this.patientListService = patientListService;
                this.patientManagerService = patientManagerService;
                this.patientListService.getAllPatients();
            }
            PatientListController.$inject = ["PatientListService", "PatientManagerService"];
            return PatientListController;
        })();
        controllers.PatientListController = PatientListController;
        angular.module("patient").controller("PatientListController", PatientListController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
