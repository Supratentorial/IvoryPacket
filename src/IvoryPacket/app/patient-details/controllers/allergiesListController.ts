module patient.controllers {
    export class AllergiesListController {

        static $inject = ["PatientManagerService", "AllergiesListService", "$state"];

        constructor(private patientManagerService: interfaces.services.patientManagerService, private allergiesListService: interfaces.services.allergiesListService, private $state: angular.ui.IStateService) {
            var patientId = this.$state.params["patientId"];
            this.patientManagerService.openPatientById(patientId);
            this.allergiesListService.getCurrentPatientAllergies();
        }
    }
    angular.module("patient").controller("AllergiesListController", AllergiesListController);
}