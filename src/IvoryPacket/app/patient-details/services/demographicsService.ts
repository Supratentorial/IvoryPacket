module patient.services {
    export class DemographicsService implements interfaces.services.demographicsService {

        static $inject = ["$http", "PatientManagerService"];
        constructor(private $http: angular.IHttpService, private patientManagerService: interfaces.services.patientManagerService) {

        }

        getCurrentPatientDateOfBirth() {

        }

        getCurrentPatientMiddleNames(): string {
            return this.patientManagerService.currentPatient.middleNames;
        }

        getCurrentPatientFullName(): string {
            var fullName: string;
            if (this.patientManagerService.currentPatient.familyName) {
                fullName = this.patientManagerService.currentPatient.familyName.toUpperCase() + ", " + this.patientManagerService.currentPatient.givenName;
            }
            if (this.patientManagerService.currentPatient.middleNames) {
                fullName += " " + this.patientManagerService.currentPatient.middleNames;
            }
            if (this.patientManagerService.currentPatient.title) {
                fullName += " (" + this.patientManagerService.currentPatient.title + ") "; 
            }
            return fullName;
        }

        getCurrentPatientAge(): string {
            var dateOfBirth = this.patientManagerService.currentPatient.dateOfBirth;
            if (!dateOfBirth) {
                return;
            }
            var ageYears = moment().diff(moment(dateOfBirth, "YYYY/MM/dd"), "years");
            if (ageYears > 2) {
                return ageYears.toString() + " years";
            }
            if (ageYears < 2) {
                return moment().diff(moment(dateOfBirth, "YYYY/MM/dd"), "months").toString() + " months";
            }
        }
    }

    angular.module("patient").service("DemographicsService", DemographicsService);
}