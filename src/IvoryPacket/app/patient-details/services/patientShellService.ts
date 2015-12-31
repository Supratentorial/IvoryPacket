//Manages currently open patients.
module interfaces.services {
    export class PatientShellService implements interfaces.patient.services.patientShellService {
        openPatients: interfaces.patient.models.patient[];
        currentPatient: interfaces.patient.models.patient;
        static $inject = ["$http"];
        constructor(private $http: angular.IHttpService) {
            this.currentPatient = {
                patientId: 0,
                title: null,
                givenName: null,
                middleNames: null,
                familyName: null,
                preferredName: null,
                gender: null,
                dateOfBirth: null,
                ethnicity: null,
                isActive: true,
                homePhone: null,
                workPhone: null,
                mobilePhone: null,
                medicareCardNumber: null,
                medicareCardExpiry: null,
                medicareCardPosition: null,
                allergies: [],
                contactPoints: []
            }
        }

        getPatientById(patientId: number) {
            this.$http.get("api/patients/" + patientId).then((result) => {
                //Todo: check if patient isn't already open.
                angular.copy(result.data, this.currentPatient);
                this.activatePatient();
            });
        }

        savePatient() {
            return this.$http.post("api/patients/", this.currentPatient).then(
                (result) => {
                    angular.copy(this.currentPatient, result.data);
                },
                (error) => {

                });
        }

        activatePatient(): void {

        }
    }
    angular.module("patient").service("PatientShellService", PatientShellService);
}