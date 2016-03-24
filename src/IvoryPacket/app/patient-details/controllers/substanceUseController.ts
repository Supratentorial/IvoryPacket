module patient.controllers {
    export class SubstanceUseController {
        static $inject: Array<string> = ["SubstanceUseService"];
        smokingObservation: interfaces.smokingDTO;
        alcoholObservation: interfaces.alcoholDTO;
        drugObservation: interfaces.drugDTO;
        isLoading: boolean = false;
        constructor(private substanceUseService: interfaces.substanceUseService) {
            this.getSmokingObservation();
            this.getAlcoholObservation();
            this.getDrugObservation();
        }

        getSmokingObservation() {
            this.isLoading = true;
            this.substanceUseService.getSmokingObservation()
                .then((smokingDTO: interfaces.smokingDTO) => {
                    if (smokingDTO.smokingObservationId) {
                        angular.copy(smokingDTO, this.smokingObservation)
                    } else {
                        this.smokingObservation = this.substanceUseService.createNewSmokingObservation();
                    }
                })
                .finally(() => {
                    this.isLoading = false;
                    console.log(this.smokingObservation);
                });
        }

        getAlcoholObservation() {
            
        }

        getDrugObservation() {

        }

        saveObservations() {
            console.log(this.smokingObservation);
            this.isLoading = true;
            this.substanceUseService.saveSmokingObservation(this.smokingObservation)
                .then((result) => { angular.copy(result, this.smokingObservation) })
                .finally(() => { this.isLoading = false; });
        }
    }
    angular.module("patient").controller("SubstanceUseController", SubstanceUseController);
}