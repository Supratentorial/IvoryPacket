module patient.controllers {
    export class AllergiesController {
         
        static $inject = ["AllergiesService"];
        allergySeverityOptions: string[];
        allergyReactionTypes: string[];
        currentAllergy: patient.interfaces.allergy;

        constructor(private allergiesService: patient.interfaces.allergiesService) {
            this.allergySeverityOptions = [];
            this.allergyReactionTypes = [];
            this.currentAllergy = {
                allergyId: 0,
                note: "",
                onset: null,
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
            this.allergiesService.saveAllergy(this.currentAllergy);
        }
    }
    angular.module("patient").controller("AllergiesController", patient.controllers.AllergiesController);
}