var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        "use strict";
        var DemographicsController = (function () {
            function DemographicsController(patientDetailService) {
                this.patientDetailService = patientDetailService;
                this.genderOptions = ["Male", "Female"];
                this.titleOptions = ["Mr", "Mrs", "Master", "Ms", "Doctor"];
            }
            DemographicsController.prototype.save = function () {
            };
            DemographicsController.$inject = ["DemographicsService"];
            return DemographicsController;
        })();
        controllers.DemographicsController = DemographicsController;
        angular.module("patient").controller("DemographicsController", patient.controllers.DemographicsController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
