module patient.services {
    export class PatientListService implements interfaces.services.patientListService {
        static $inject = ["$http"];
        patientsWithAppointmentToday = [];
        constructor(private $http: angular.IHttpService) {
            
        }
        
        getRecentPatients() {

        }

        getAllPatients(): angular.IPromise<any> {
            return this.$http.get("api/patients").then((result) => {
                angular.copy(result.data, this.patientsWithAppointmentToday);
            });
        }

        deletePatient() {

        }

        archivePatient() {

        }

    }
    angular.module("patient").service("PatientListService", PatientListService); 
}