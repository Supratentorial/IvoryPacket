module patient.controllers {
    export class PatientShellController {
        static $inject = ["PatientShellService","PatientService", "$state"];
        constructor(private patientShellService: interfaces.patientShellService, private patientService: interfaces.patientService, private $state: angular.ui.IState) {
            var patientId: number = this.$state.params["patientId"];
            if (patientId != 0) {
                this.patientService.getPatientById(patientId).then((result) => {
                    this.patientShellService.addPatientToOpenList(result.data);
                    this.patientShellService.setCurrentPatient(patientId);
                }).finally(() => {

                });
            }
        }
    }
    angular.module("patient").controller("PatientShellController", PatientShellController);
}
