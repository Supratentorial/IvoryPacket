var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        "use strict";
        var PatientListController = (function () {
            function PatientListController(patientListService, patientManagerService, $uibModal) {
                this.patientListService = patientListService;
                this.patientManagerService = patientManagerService;
                this.$uibModal = $uibModal;
                this.patientListService.getAllPatients();
            }
            PatientListController.prototype.createPatient = function () {
                this.$uibModal.open({
                    templateUrl: "html/create-patient-modal.html",
                    backdrop: "static",
                    controllerAs: "vm",
                    controller: "CreatePatientModalController"
                });
            };
            PatientListController.$inject = ["PatientListService", "PatientManagerService", "$uibModal"];
            return PatientListController;
        })();
        controllers.PatientListController = PatientListController;
        angular.module("patient").controller("PatientListController", PatientListController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
