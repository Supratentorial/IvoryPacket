module patient.controllers {
    "use strict"
    export class PatientListController {
        static $inject = ["PatientListService", "PatientManagerService"];
        constructor(private patientListService: interfaces.services.patientListService, private patientManagerService: interfaces.services.patientManagerService) {
            this.patientListService.getAllPatients();
        }
    }
    angular.module("patient").controller("PatientListController", PatientListController);
}