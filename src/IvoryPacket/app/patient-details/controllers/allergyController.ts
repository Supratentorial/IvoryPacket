module patient.controllers {
    export class AllergyController {
         
        static $inject = [];
        construction() {
        }
    }
    angular.module("patient").controller("AllergyController", patient.controllers.AllergyController);
}