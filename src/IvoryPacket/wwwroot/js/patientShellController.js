var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        var PatientShellController = (function () {
            function PatientShellController($state) {
                this.$state = $state;
            }
            PatientShellController.$inject = ["$state"];
            return PatientShellController;
        })();
        controllers.PatientShellController = PatientShellController;
        angular.module("patient").controller("PatientShellController", patient.controllers.PatientShellController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
