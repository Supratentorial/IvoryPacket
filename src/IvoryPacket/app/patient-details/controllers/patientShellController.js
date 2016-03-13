var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        var PatientShellController = (function () {
            function PatientShellController(patientManagerService, $state, demographicsService) {
                var _this = this;
                this.patientManagerService = patientManagerService;
                this.$state = $state;
                this.demographicsService = demographicsService;
                this.isBusy = false;
                var patientId = this.$state.params["patientId"];
                if (patientId != 0) {
                    this.patientManagerService.openPatientById(patientId).then(function (result) {
                        _this.patientManagerService.setCurrentPatientById(patientId);
                        _this.demographicsService.getCurrentPatient();
                    });
                }
            }
            PatientShellController.$inject = ["PatientManagerService", "$state", "DemographicsService"];
            return PatientShellController;
        })();
        controllers.PatientShellController = PatientShellController;
        angular.module("patient").controller("PatientShellController", PatientShellController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
