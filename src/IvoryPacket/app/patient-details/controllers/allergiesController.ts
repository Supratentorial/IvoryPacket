module patient.controllers {
    export class AllergiesController {
         
        static $inject = ["AllergiesService"];
        allergySeverityOptions: string[];
        allergyReactionTypes: string[];
        currentAllergy: interfaces.models.allergy;

        constructor(private allergiesService: interfaces.services.allergiesService) {
            this.allergySeverityOptions = [];
            this.allergyReactionTypes = [];
            this.currentAllergy = {
                allergyId: 0,
                note: "",
                type: "",
                severity: "",
                substance: "",
                recordedDate: null,
                clinicalManifestation: ""
            }
            this.getAllergySeverityOptions();
            this.getAllergyReactionTypes();
        }

        getAllergySeverityOptions(): void {
            this.allergiesService.getAllergySeverityOptions().then((data) => {
                angular.copy(data, this.allergySeverityOptions);
            });
        }

        getAllergyReactionTypes(): void {
            this.allergiesService.getAllergyReactionTypes().then((data) => {
                angular.copy(data, this.allergyReactionTypes);
            });
        }


        saveAllergy() {
            this.allergiesService.addAllergy(this.currentAllergy);
        }
    }
    angular.module("patient").controller("AllergiesController", AllergiesController);
}