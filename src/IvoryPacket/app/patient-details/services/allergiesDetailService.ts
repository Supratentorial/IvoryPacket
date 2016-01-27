module patient.services {
    export class AllergiesDetailService implements interfaces.services.allergiesDetailService {
        static $inject = ["PatientManagerService", "$http"];
        allergySeverityOptions: string[];
        allergyReactionTypes: string[];
        currentAllergy: interfaces.models.allergy;

        constructor(private patientManagerService: interfaces.services.patientManagerService, private $http: angular.IHttpService) {
            this.allergyReactionTypes = [];
            this.allergySeverityOptions = [];
            this.getAllergySeverityOptions();
            this.getAllergyReactionTypes();
        }

        getAllergyById(allergyId: number): angular.IHttpPromise<any> {
            if (allergyId) {
                return this.$http.get("api/patients/" + this.patientManagerService.currentPatientId + "/allergies/" + allergyId);
            }
        }

        addNewAllergy(allergy: interfaces.models.allergy): angular.IHttpPromise<any> {
            if (allergy.allergyId == 0) {
                return this.$http.post("api/patients/" + this.patientManagerService.currentPatientId + "/allergies", allergy);
            }
        }

        updateExistingAllergy(allergy: interfaces.models.allergy): angular.IHttpPromise<any> {
            if (allergy.allergyId != 0) {
                return this.$http.put("apie/patients/" + this.patientManagerService.currentPatientId + "/allergies", allergy);
            }
        }

        deleteAllergy(allergyId: number) {
            //Todo: change allergy status.
        }

        getAllergySeverityOptions() {
            return this.$http.get("api/allergies/valuesets/severity").then(
                //Success
                (response) => {
                    angular.copy(response.data, this.allergySeverityOptions);
                },
                //Failure
                (error) => {

                });
        }

        getAllergyReactionTypes() {
            return this.$http.get("api/allergies/valuesets/reactiontypes").then(
                //Success
                (response) => {
                    angular.copy(response.data, this.allergyReactionTypes);
                },
                //Failure
                (error) => {
                });

        }

    }
    angular.module("patient").service("AllergiesDetailService", AllergiesDetailService);
}