var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        var PatientShellController = (function () {
            function PatientShellController(patientShellService, $state) {
                this.patientShellService = patientShellService;
                this.$state = $state;
                var patientId = this.$state.params["patientId"];
                if (patientId != 0) {
                    this.patientShellService.getPatientById(patientId);
                }
                else {
                }
            }
            PatientShellController.$inject = ["PatientShellService", "$state"];
            return PatientShellController;
        })();
        controllers.PatientShellController = PatientShellController;
        angular.module("patient").controller("PatientShellController", patient.controllers.PatientShellController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
