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
                this.dateOfBirth = this.parseDate(this.patientShellService.currentPatient.dateOfBirth);
                this.mobilePhone = this.patientShellService.currentPatient.mobilePhone;
                this.workPhone = this.patientShellService.currentPatient.workPhone;
                this.homePhone = this.patientShellService.currentPatient.homePhone;
                this.age = this.calculateAge(this.dateOfBirth);
            }
            DemographicsController.prototype.parseDate = function (dateOfBirthString) {
                var dateOfBirth;
                if (!dateOfBirthString || 0 === dateOfBirthString.length) {
                    return;
                }
                try {
                    dateOfBirth = new Date(dateOfBirthString);
                }
                catch (e) {
                    console.log(e.message);
                    return;
                }
                return dateOfBirth;
            };
            DemographicsController.prototype.calculateAge = function (dateOfBirth) {
                if (!dateOfBirth) {
                    return;
                }
                var today = new Date();
                var age = today.getFullYear() - dateOfBirth.getFullYear();
                var m = today.getMonth() - dateOfBirth.getMonth();
                if (m < 0 || (m === 0 && today.getDate() < dateOfBirth.getDate())) {
                    age--;
                }
                var ageString = age.toString() + " years, " + m.toString() + " months";
                return ageString;
            };
            DemographicsController.prototype.updateDemographics = function () {
                var _this = this;
                this.isBusy = true;
                this.patientShellService.currentPatient.givenName = this.givenName;
                this.patientShellService.currentPatient.middleNames = this.middleNames;
                this.patientShellService.currentPatient.familyName = this.familyName;
                this.patientShellService.currentPatient.title = this.title;
                this.patientShellService.currentPatient.gender = this.gender;
                //this.patientShellService.currentPatient.dateOfBirth = this.dateOfBirth.to;
                this.patientShellService.currentPatient.preferredName = this.preferredName;
                this.patientShellService.currentPatient.mobilePhone = this.mobilePhone;
                this.patientShellService.currentPatient.workPhone = this.workPhone;
                this.patientShellService.currentPatient.homePhone = this.homePhone;
                this.patientShellService.savePatient().then(function () { _this.isBusy = false; });
            };
            DemographicsController.$inject = ["PatientShellService"];
            return DemographicsController;
        })();
        controllers.DemographicsController = DemographicsController;
        angular.module("patient").controller("DemographicsController", DemographicsController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
