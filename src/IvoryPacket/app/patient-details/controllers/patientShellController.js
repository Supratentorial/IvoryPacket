var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        var PatientShellController = (function () {
            function PatientShellController(patientShellService, $state) {
                this.patientShellService = patientShellService;
                this.$state = $state;
                this.isBusy = false;
                var patientId = this.$state.params["patientId"];
                if (patientId != 0) {
                    this.isBusy = true;
                    this.patientShellService.getPatientById(patientId);
                }
                else {
                }
            }
            PatientShellController.$inject = ["PatientShellService", "$state"];
            return PatientShellController;
        })();
        controllers.PatientShellController = PatientShellController;
        angular.module("patient").controller("PatientShellController", PatientShellController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
