module patient.services {
    export class PatientListService implements interfaces.patient.services.PatientListService {
        static $inject = ["$http"];
        patientsWithAppointmentToday = [];
        constructor(private $http: angular.IHttpService) {
            
        }
        
        getRecentPatients() {

        }

        getAllPatients() : any {
            this.$http.get("api/patients").then((result) => {
                return angular.copy(result.data, this.patientsWithAppointmentToday);
            });
        }

        deletePatient() {

        }

        archivePatient() {

        }

    }
    angular.module("patient").service("PatientListService", PatientListService); 
}