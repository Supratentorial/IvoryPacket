module patient.controllers {
    export class PatientShellController {
        static $inject = ["PatientManagerService", "$state", "DemographicsService"];
        fullName: string;
        age: string;
        isLoading: boolean = false;
        constructor(private patientManagerService: interfaces.services.patientManagerService, private $state: angular.ui.IState, private demographicsService: interfaces.services.demographicsService) {
            var patientId: number = this.$state.params["patientId"];
            if (patientId != 0) {
                this.isLoading = true;
                this.patientManagerService.openPatientById(patientId).then((result) => {
                    this.patientManagerService.setCurrentPatientById(patientId)
                    this.demographicsService.getCurrentPatient();
                }).finally(() => {
                    this.isLoading = false;
                });
            }
        }
    }
    angular.module("patient").controller("PatientShellController", PatientShellController);
}
