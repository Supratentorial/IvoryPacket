var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        var PatientShellController = (function () {
            function PatientShellController(patientShellService, patientService, $state) {
                var _this = this;
                this.patientShellService = patientShellService;
                this.patientService = patientService;
                this.$state = $state;
                var patientId = this.$state.params["patientId"];
                if (patientId != 0) {
                    this.patientService.getPatientById(patientId).then(function (result) {
                        _this.patientShellService.addPatientToOpenList(result.data);
                        _this.patientShellService.setCurrentPatient(patientId);
                    }).finally(function () {
                    });
                }
            }
            PatientShellController.$inject = ["PatientShellService", "PatientService", "$state"];
            return PatientShellController;
        })();
        controllers.PatientShellController = PatientShellController;
        angular.module("patient").controller("PatientShellController", PatientShellController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
