module patient.controllers {
    "use strict"
    export class PatientListController {
        isLoading: boolean = false;
        static $inject = ["PatientListService", "PatientManagerService", "$uibModal"];
        constructor(private patientListService: interfaces.services.patientListService, private patientManagerService: interfaces.services.patientManagerService, private $uibModal: angular.ui.bootstrap.IModalService) {
            this.isLoading = true;
            this.patientListService.getAllPatients().then().finally(() => {
                this.isLoading = false;
            });
        }

        createPatient() {
            this.$uibModal.open({
                templateUrl: "html/create-patient-modal.html",
                backdrop: "static",
                controllerAs: "vm",
                controller: "CreatePatientModalController"
            })
        }
    }
    angular.module("patient").controller("PatientListController", PatientListController);
}