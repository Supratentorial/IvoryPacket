module patient.services {
    export class AllergyService {
        static $inject = [];
        constructor() {
        }

        getPatientAllergyById(patientId: number) {

        }

        addPatientAllergy(patientId: number, allergy: patient.interfaces.Allergy) {

        }



    }
    angular.module("patient").service("AllergyService", patient.services.AllergyService);
}