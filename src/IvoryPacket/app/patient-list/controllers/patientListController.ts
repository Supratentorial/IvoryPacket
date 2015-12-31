module patient.controllers {
    "use strict"
    export class PatientListController {
        static $inject = ["PatientListService"];
        constructor(private patientListService: interfaces.patient.services.PatientListService) {
            this.patientListService.getAllPatients();
        }
    }
    angular.module("patient").controller("PatientListController", PatientListController);
}