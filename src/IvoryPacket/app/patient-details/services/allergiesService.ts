module patient.services {
    export interface allergiesService {
        getAllergySeverityOptions(): any;
        getAllergyReactionTypes(): any;
        addAllergy(allergy: interfaces.allergy): void;
    }
    export class AllergiesService implements allergiesService {
        static $inject = ["PatientShellService", "$http"];
        constructor(private patientShellService: patient.services.patientShellService, private $http: angular.IHttpService) {

        }

        addAllergy(allergy: interfaces.allergy) {
            this.patientShellService.currentPatient.allergies.push(allergy);
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
    angular.module("patient").service("AllergiesService", patient.services.AllergiesService);
}