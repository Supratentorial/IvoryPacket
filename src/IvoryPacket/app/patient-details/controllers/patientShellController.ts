module patient.controllers {
    export class PatientShellController {
        static $inject = ["PatientShellService", "$state"];
        constructor(private patientShellService: patient.services.patientShellService, private $state: angular.ui.IState) {
            var patientId: number = this.$state.params["patientId"];
            if (patientId != 0) {
                this.patientShellService.getPatientById(patientId);
            }
            else {
                
            }
        }
    }
    angular.module("patient").controller("PatientShellController", patient.controllers.PatientShellController);
}
