module patient.controllers {
    export class PatientShellController {
        static $inject = ["PatientShellService", "$state"];
        isBusy: boolean = false;
        constructor(private patientShellService: interfaces.patient.services.patientShellService, private $state: angular.ui.IState) {
            var patientId: number = this.$state.params["patientId"];
            
            if (patientId != 0) {
                this.isBusy = true;        
                this.patientShellService.getPatientById(patientId);
            }
            else {

            }
        }
    }
    angular.module("patient").controller("PatientShellController", PatientShellController);
}
