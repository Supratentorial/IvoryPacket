module patient.controllers {
    "use strict"
    export class DemographicsController {
        static $inject = ["DemographicsService"];
        genderOptions: string[] = ["Male", "Female"];
        titleOptions: string[] = ["Mr", "Mrs", "Master", "Ms", "Doctor"]
        constructor(private patientDetailService) {
        }

        private save() {
            
        }
    }
    angular.module("patient").controller("DemographicsController", patient.controllers.DemographicsController);
}