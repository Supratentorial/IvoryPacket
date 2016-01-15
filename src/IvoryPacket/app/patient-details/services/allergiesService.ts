module patient.services {
    export class AllergiesService implements interfaces.services.allergiesService {
        static $inject = ["PatientManagerService", "$http"];
        constructor(private patientManagerService: interfaces.services.patientManagerService, private $http: angular.IHttpService) {

        }

        addAllergy(allergy: interfaces.models.allergy) {
            this.patientManagerService.currentPatient.allergies.push(allergy);
        }

        deleteAllergy(allergyId: number) {
            //Todo: change allergy status.
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

    }
    angular.module("patient").service("AllergiesService", AllergiesService);
}