module patient.controllers {
    "use strict"
    export class DemographicsController {
        static $inject = [];
        genderOptions: string[] = ["Male", "Female"];
        titleOptions: string[] = ["Mr", "Mrs", "Master", "Ms", "Doctor"]
        constructor() {
        }
    }
    angular.module("patient").controller("DemographicsController", patient.controllers.DemographicsController);
}