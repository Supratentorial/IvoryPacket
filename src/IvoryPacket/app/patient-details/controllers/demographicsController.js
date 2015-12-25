var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        "use strict";
        var DemographicsController = (function () {
            function DemographicsController(patientShellService) {
                this.patientShellService = patientShellService;
                this.genderOptions = ["Male", "Female"];
                this.titleOptions = ["Mr", "Mrs", "Master", "Ms", "Doctor"];
                this.isBusy = false;
                this.givenName = this.patientShellService.currentPatient.givenName;
                this.middleNames = this.patientShellService.currentPatient.middleNames;
                this.familyName = this.patientShellService.currentPatient.familyName;
                this.title = this.patientShellService.currentPatient.title;
                this.preferredName = this.patientShellService.currentPatient.preferredName;
                this.gender = this.patientShellService.currentPatient.gender;
                this.dateOfBirth = this.patientShellService.currentPatient.dateOfBirth;
            }
            DemographicsController.prototype.updateDemographics = function () {
                var _this = this;
                this.isBusy = true;
                this.patientShellService.currentPatient.givenName = this.givenName;
                this.patientShellService.currentPatient.middleNames = this.middleNames;
                this.patientShellService.currentPatient.familyName = this.familyName;
                this.patientShellService.currentPatient.title = this.title;
                this.patientShellService.currentPatient.gender = this.gender;
                this.patientShellService.currentPatient.dateOfBirth = this.dateOfBirth;
                this.patientShellService.currentPatient.preferredName = this.preferredName;
                this.patientShellService.savePatient().then(function () { _this.isBusy = false; });
            };
            DemographicsController.$inject = ["PatientShellService"];
            return DemographicsController;
        })();
        controllers.DemographicsController = DemographicsController;
        angular.module("patient").controller("DemographicsController", patient.controllers.DemographicsController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
