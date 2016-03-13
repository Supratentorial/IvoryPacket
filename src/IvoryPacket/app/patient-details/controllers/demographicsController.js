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
                if (patientId) {
                    this.patientManagerService.openPatientById(patientId).then(function (response) {
                        _this.demographicsService.getCurrentPatient();
                        _this.givenName = _this.demographicsService.currentPatient.givenName;
                        _this.middleNames = _this.demographicsService.currentPatient.middleNames;
                        _this.familyName = _this.demographicsService.currentPatient.familyName;
                        _this.title = _this.demographicsService.currentPatient.title;
                        _this.preferredName = _this.demographicsService.currentPatient.preferredName;
                        _this.gender = _this.demographicsService.currentPatient.gender;
                        _this.dateOfBirth = new Date(_this.demographicsService.currentPatient.dateOfBirth);
                        _this.emailAddress = _this.emailService.getCurrentPatientEmail();
                        if (_this.phoneNumberService.currentPatientHasMobileNumber()) {
                            _this.mobilePhone = {};
                            angular.copy(_this.phoneNumberService.getCurrentPatientMobileNumber(), _this.mobilePhone);
                            console.log(_this.mobilePhone);
                        }
                        else {
                            _this.mobilePhone = _this.phoneNumberService.createNewMobileNumber();
                        }
                    });
                }
            }
            DemographicsController.prototype.savePatient = function () {
                var _this = this;
                this.isBusy = true;
                this.demographicsService.currentPatient.givenName = this.givenName;
                this.demographicsService.currentPatient.familyName = this.familyName;
                this.demographicsService.currentPatient.title = this.title;
                this.demographicsService.currentPatient.middleNames = this.middleNames;
                this.demographicsService.currentPatient.gender = this.gender;
                this.demographicsService.currentPatient.dateOfBirth = moment(this.dateOfBirth).format("YYYY/MM/DD");
                this.demographicsService.currentPatient.preferredName = this.preferredName;
                this.emailService.setCurrentPatientEmail(this.emailAddress);
                if (this.mobilePhone.value) {
                    this.phoneNumberService.setCurrentPatientMobileNumber(this.mobilePhone);
                }
                this.patientManagerService.updateCurrentPatient()
                    .then(function () {
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
