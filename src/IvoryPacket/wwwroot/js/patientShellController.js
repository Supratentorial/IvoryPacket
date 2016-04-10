var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        var PatientShellController = (function () {
            function PatientShellController(patientShellService, patientService, demographicsService, $state) {
                var _this = this;
                this.patientShellService = patientShellService;
                this.patientService = patientService;
                this.demographicsService = demographicsService;
                this.$state = $state;
                var patientId = this.$state.params["patientId"];
                if (patientId != 0) {
                    this.patientService.getPatientById(patientId).then(function (result) {
                        _this.patientShellService.addPatientToOpenList(result.data);
                        _this.patientShellService.setCurrentPatient(patientId);
                        if (_this.patientShellService.currentPatient.mobilePhoneNumber === null) {
                            _this.patientShellService.currentPatient.mobilePhoneNumber = _this.demographicsService.createNewPhoneNumber("Mobile");
                        }
                        if (_this.patientShellService.currentPatient.homePhoneNumber === null) {
                            _this.patientShellService.currentPatient.homePhoneNumber = _this.demographicsService.createNewPhoneNumber("Home");
                        }
                        if (_this.patientShellService.currentPatient.residentialAddress === null) {
                            _this.patientShellService.currentPatient.residentialAddress = _this.demographicsService.createNewAddress("Residential");
                        }
                    }).finally(function () {
                    });
                }
            }
            PatientShellController.$inject = ["PatientShellService", "PatientService", "DemographicsService", "$state"];
            return PatientShellController;
        })();
        controllers.PatientShellController = PatientShellController;
        angular.module("patient").controller("PatientShellController", PatientShellController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
