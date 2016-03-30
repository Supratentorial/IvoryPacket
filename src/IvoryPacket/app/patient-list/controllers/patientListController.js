var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        "use strict";
        var PatientListController = (function () {
            function PatientListController(patientListService, patientShellService, $uibModal) {
                var _this = this;
                this.patientListService = patientListService;
                this.patientShellService = patientShellService;
                this.$uibModal = $uibModal;
                this.isLoading = false;
                this.isLoading = true;
                this.patientListService.getAllPatients().then().finally(function () {
                    _this.isLoading = false;
                });
            }
            PatientListController.prototype.createPatient = function () {
                this.$uibModal.open({
                    templateUrl: "html/create-patient-modal.html",
                    backdrop: "static",
                    controllerAs: "vm",
                    controller: "CreatePatientModalController"
                });
            };
            PatientListController.$inject = ["PatientListService", "PatientShellService", "$uibModal"];
            return PatientListController;
        })();
        controllers.PatientListController = PatientListController;
        angular.module("patient").controller("PatientListController", PatientListController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
