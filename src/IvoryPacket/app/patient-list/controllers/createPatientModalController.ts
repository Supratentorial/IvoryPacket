﻿module patient.controllers {
    export class CreatePatientModalController {
        newPatient: interfaces.patientDetailed;
        static $inject: Array<string> = ["$uibModalInstance", "PatientManagerService"];
        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private patientManagerService: interfaces.patientService ) {
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