module patient.services {
    export class SubstanceUseService implements interfaces.substanceUseService {
        static $inject: Array<string> = ["$http", "PatientManagerService"];
        constructor(private $http: angular.IHttpService, private patientManagerService: interfaces.patientShellService) {
            
        }

        getAlcoholObservation(): angular.IPromise<any> {
            return this.$http.get("api/observations/alcohol");
        }

        saveAlcoholObservation(alcoholDTO: interfaces.alcoholDTO): angular.IPromise<any> {
            return this.$http.post("api/observations/alcohol", alcoholDTO);
        }

        getSmokingObservation(): angular.IPromise<any> {
            return this.$http.get("api/patients/{patientId}/observations/smoking");
        }

        getDrugObservation(): angular.IPromise<any> {
            return this.$http.get("api/observations/drugs");
        }

        saveSmokingObservation(smokingDTO: interfaces.smokingDTO): angular.IPromise<any> {
            return this.$http.post("api/observations/smoking", smokingDTO);
        }

        saveDrugObservation(drugDTO: interfaces.drugDTO): angular.IPromise<any> {
            return this.$http.post("api/observations/drugs", drugDTO);
        }

        createNewSmokingObservation() {
            return <interfaces.smokingDTO>{
                patientId: 0,
                cigarettesPerDay: null,
                smokingStatus: null,
                notes: "",
                lastUpdated: null,
                ageCeased: 0,
                ageStarted: 0,
                smokingObservationId: 0                
            }
        }
    }
    angular.module("patient").service("SubstanceUseService", SubstanceUseService);
}