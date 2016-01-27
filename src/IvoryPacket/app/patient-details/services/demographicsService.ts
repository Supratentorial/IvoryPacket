module patient.services {
    export class DemographicsService implements interfaces.services.demographicsService {
        static $inject = ["$http", "PatientManagerService"];
        currentPatient: interfaces.models.patient;
        fullName: string;
        age: string;
        constructor(private $http: angular.IHttpService, private patientManagerService: interfaces.services.patientManagerService) {
              
        }

        getCurrentPatient() : void {
            this.currentPatient = this.patientManagerService.getCurrentPatient();
            this.getCurrentPatientFullName();
            this.getCurrentPatientAge();
        }

        getCurrentPatientFullName() {
            if (this.currentPatient.familyName) {
                this.fullName = this.currentPatient.familyName.toUpperCase() + ", " + this.currentPatient.givenName;
            }
            if (this.currentPatient.middleNames) {
                this.fullName += " " + this.currentPatient.middleNames;
            }
            if (this.currentPatient.title) {
                this.fullName += " (" + this.currentPatient.title + ") "; 
            }
        }

        getCurrentPatientAge() {
            var dateOfBirth = this.currentPatient.dateOfBirth;
            if (!dateOfBirth) {
                return;
            }
            var ageYears = moment().diff(moment(dateOfBirth, "YYYY/MM/dd"), "years");
            if (ageYears > 2) {
                this.age = ageYears.toString() + " years";
            }
            if (ageYears < 2) {
                this.age = moment().diff(moment(dateOfBirth, "YYYY/MM/dd"), "months").toString() + " months";
            }

        }
    }

    angular.module("patient").service("DemographicsService", DemographicsService);
}