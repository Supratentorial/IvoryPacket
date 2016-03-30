module patient.services {
    export class VitalsService implements interfaces.vitalsService {
        static $inject: Array<string> = ["$http", "PatientShellService"];
        constructor(private $http: angular.IHttpService, private patientShellService: interfaces.patientShellService) {

        }

        getPatientVitalSigns(): angular.IPromise<any> {
            console.log(this.patientShellService.currentPatient.patientId);
            return this.$http.get("api/patient/" + this.patientShellService.currentPatient.patientId + "/observations/vitalsigns");
        }

        saveNewVitalSigns(vitalSignsDTO: interfaces.vitalSignsDTO): angular.IPromise<any> {
            return this.$http.post("api/patient/" + this.patientShellService.currentPatient.patientId + "/observations/vitalsigns", vitalSignsDTO);
        }

        updateVitalSigns(vitalSignsDTO: interfaces.vitalSignsDTO): angular.IPromise<any> {
            return this.$http.put("api/patient/" + this.patientShellService.currentPatient.patientId + "/observations/vitalsigns", vitalSignsDTO);
        }
    }
    angular.module("patient").service("VitalsService", VitalsService);
}