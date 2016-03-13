module patient.controllers {
    export class CreatePatientModalController {
        newPatient: interfaces.models.patientDetailed;
        static $inject: Array<string> = ["$uibModalInstance", "PatientManagerService"];
        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private patientManagerService: interfaces.services.patientManagerService ) {
            this.newPatient = this.patientManagerService.createNewPatient();
        }

        saveNewPatient() {
            this.patientManagerService.saveNewPatient(this.newPatient);
        }

        cancel() {
            this.$uibModalInstance.dismiss();
        }

    }
    angular.module("patient").controller("CreatePatientModalController", CreatePatientModalController);
}