module patient.controllers {
    export class PatientShellController {
        static $inject = ["$state"];
        currentTab: string;
        constructor(private $state: angular.ui.IStateService) {
            
        }
    }
    angular.module("patient").controller("PatientShellController", patient.controllers.PatientShellController);
}
