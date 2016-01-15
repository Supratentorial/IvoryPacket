var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        "use strict";
        var DemographicsController = (function () {
            function DemographicsController(patientManagerService, moment, phoneNumberService, emailService, demographicsService, $state) {
                var _this = this;
                this.patientManagerService = patientManagerService;
                this.moment = moment;
                this.phoneNumberService = phoneNumberService;
                this.emailService = emailService;
                this.demographicsService = demographicsService;
                this.$state = $state;
                this.genderOptions = ["Male", "Female"];
                this.titleOptions = ["Mr", "Mrs", "Master", "Ms", "Doctor"];
                this.contactOptions = ["Mobile", "Home", "Work", "Email"];
                this.isBusy = false;
                var patientId = this.$state.params["patientId"];
                this.patientManagerService.openPatientById(patientId).then(function (response) {
                    _this.givenName = _this.patientManagerService.currentPatient.givenName;
                    _this.middleNames = _this.demographicsService.getCurrentPatientMiddleNames();
                    _this.familyName = _this.patientManagerService.currentPatient.familyName;
                    _this.title = _this.patientManagerService.currentPatient.title;
                    _this.preferredName = _this.patientManagerService.currentPatient.preferredName;
                    _this.gender = _this.patientManagerService.currentPatient.gender;
                    _this.dateOfBirth = new Date(_this.patientManagerService.currentPatient.dateOfBirth);
                    _this.age = _this.demographicsService.getCurrentPatientAge();
                    _this.fullName = _this.demographicsService.getCurrentPatientFullName();
                    //this.mobilePhone = this.phoneNumberService.getPhoneNumberByType("mobile");
                    //this.homePhone = this.phoneNumberService.getPhoneNumberByType("home");
                    //this.workPhone = this.phoneNumberService.getPhoneNumberByType("work");
                    _this.emailAddress = _this.emailService.getCurrentPatientEmail();
                });
            }
            DemographicsController.prototype.savePatient = function () {
                var _this = this;
                this.isBusy = true;
                this.patientManagerService.currentPatient.givenName = this.givenName;
                this.patientManagerService.currentPatient.middleNames = this.middleNames;
                this.patientManagerService.currentPatient.familyName = this.familyName;
                this.patientManagerService.currentPatient.title = this.title;
                this.patientManagerService.currentPatient.gender = this.gender;
                this.patientManagerService.currentPatient.dateOfBirth = moment(this.dateOfBirth).format("YYYY/MM/DD");
                this.patientManagerService.currentPatient.preferredName = this.preferredName;
                this.emailService.setCurrentPatientEmail(this.emailAddress);
                //this.phoneNumberService.addNewPatientPhoneNumber(this.mobilePhone)
                this.patientManagerService.savePatient()
                    .then(function () {
                    console.log(_this.demographicsService.getCurrentPatientMiddleNames());
                    _this.$state.go("patient.detail.demographics.view");
                }, function () { console.log("patient failed to save"); })
                    .finally(function () { _this.isBusy = false; });
            };
            DemographicsController.prototype.updatePhoneNumber = function () {
            };
            DemographicsController.$inject = ["PatientManagerService", "moment", "PhoneNumberService", "EmailService", "DemographicsService", "$state"];
            return DemographicsController;
        })();
        controllers.DemographicsController = DemographicsController;
        angular.module("patient").controller("DemographicsController", DemographicsController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
