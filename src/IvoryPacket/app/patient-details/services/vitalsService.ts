module patient.services {
    export class VitalsService implements interfaces.vitalsService {
        static $inject: Array<string> = ["$http", "PatientManagerService"];
        constructor(private $http: angular.IHttpService, private PatientManagerService: interfaces.services.patientManagerService) {

        }

        getPatientVitalSigns(): angular.IPromise<any> {
            return this.$http.get("api/patient/" + this.PatientManagerService.currentPatientId + "/observations / vitalsigns");
        }

        saveNewVitalSigns(vitalSignsDTO: interfaces.vitalSignsDTO): angular.IPromise<any> {
            return this.$http.post("api/patient/" + this.PatientManagerService.currentPatientId + "/observations/vitalsigns", vitalSignsDTO);
        }

        updateVitalSigns(vitalSignsDTO: interfaces.vitalSignsDTO): angular.IPromise<any> {
            return this.$http.put("api/patient/" + this.PatientManagerService.currentPatientId + "/observations/vitalsigns", vitalSignsDTO);
        }
    }
    angular.module("patient").service("VitalsService", VitalsService);
}