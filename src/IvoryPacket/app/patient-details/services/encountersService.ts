module patient.services {
    export class EncountersService {
        static $inject = ["http", "PatientManagerService"];
        constructor(private $http: angular.IHttpService, private patientManagerService: interfaces.services.patientManagerService) {

        }

        getCurrentPatientPastEncounters(patientId: number) {
            return this.$http.get("api/patients/" + this.patientManagerService.currentPatientId + "/encounters");
        }

        saveEncounter(encounter: interfaces.models.encounter) { }

    }

    angular.module("patient").service("EncountersService", EncountersService);
}