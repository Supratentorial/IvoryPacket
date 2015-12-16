module patient.services {
    export class AllergiesService implements patient.interfaces.allergiesService {
        static $inject = ["PatientShellService", "$http"];
        constructor(private patientShellService: patient.interfaces.patientShellService, private $http: angular.IHttpService) {

        }

        saveAllergy(allergy: patient.interfaces.allergy) {
            return this.$http.post("api/allergies", allergy).then(
                //Success
                () => {
                    console.log("Allergy successfully saved to server.");
                },
                //Failure
                () => { });
        }

        getAllergySeverityOptions() {
            return this.$http.get("api/allergies/valuesets/severity").then(
                //Success
                (response) => {
                    console.log("Successfully got the data.");
                    return response.data;
                },
                //Failure
                (error) => {

                });
        }

        getAllergyReactionTypes() {
            return this.$http.get("api/allergies/valuesets/reactiontypes").then(
                //Success
                (response) => {
                    console.log("Successfully got reaction types.");
                    return response.data;
                },
                //Failure
                (error) => {
                });

        }


        getCurrentPatientAllergies() {
            this.$http.get("api/allergies").then(() => { });
        }

        getPatientAllergyById(patientId: number) {

        }

        addPatientAllergy(patientId: number, allergy: patient.interfaces.allergy) {

        }



    }
    angular.module("patient").service("AllergiesService", patient.services.AllergiesService);
}