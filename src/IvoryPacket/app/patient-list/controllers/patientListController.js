var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        "use strict";
        var PatientListController = (function () {
            function PatientListController() {
            }
            PatientListController.$inject = [];
            return PatientListController;
        })();
        controllers.PatientListController = PatientListController;
        angular.module("patient").controller("PatientListController", PatientListController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
