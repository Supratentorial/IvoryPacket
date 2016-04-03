module patient.controllers {
    export class PatientShellController {
        static $inject = ["PatientShellService", "PatientService", "PhoneNumberService", "$state"];
        constructor(private patientShellService: interfaces.patientShellService, private patientService: interfaces.patientService, private phoneNumberService: interfaces.phoneNumberService, private $state: angular.ui.IState) {
            var patientId: number = this.$state.params["patientId"];
            if (patientId != 0) {
                this.patientService.getPatientById(patientId).then((result) => {
                    this.patientShellService.addPatientToOpenList(result.data);
                    this.patientShellService.setCurrentPatient(patientId);
                    if (this.patientShellService.currentPatient.mobilePhoneNumber === null) {
                        this.patientShellService.currentPatient.mobilePhoneNumber = this.phoneNumberService.createNewMobileNumber();
                    }
                    if (this.patientShellService.currentPatient.homePhoneNumber === null) {
                        this.patientShellService.currentPatient.homePhoneNumber = this.phoneNumberService.createNewHomeNumber();
                    }
                    if (this.patientShellService.currentPatient.residentialAddress === null) {
                        this.patientShellService.currentPatient.residentialAddress = this.demographricsService.createNewResidentialAddress();
                    }
                }).finally(() => {

                });
            }
        }
    }
    angular.module("patient").controller("PatientShellController", PatientShellController);
}
