//Manages currently open patients.
module patient.services {
    export class PatientManagerService implements interfaces.services.patientManagerService {
        openPatients: interfaces.models.patient[];
        currentPatient: interfaces;
        static $inject = ["$http", "$q"];
        constructor(private $http: angular.IHttpService, private $q: angular.IQService) {
            this.openPatients = [];
            this.currentPatient = <interfaces.models.patient>{};
        }

        isOpenPatient(patientId: number): boolean {
            for (var i = 0; i < this.openPatients.length; i++) {
                var openPatient = this.openPatients[i];
                if (patientId === openPatient.patientId) {
                    return true;
                }
            }
            return false;
        }

        isCurrentPatient(patientId: number): boolean {
            if (this.currentPatient.patientId === patientId) {
                return true;
            }
            return false;
        }

        createNewPatient(): void {
            if (this.isOpenPatient(0)) {
                //TODO: Use message service to alert user.
                return;
            }
            var newPatient = <interfaces.models.patient>{
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
                medicareCardNumber: null,
                medicareCardExpiry: null,
                medicareCardPosition: null,
                allergies: [],
                phoneNumbers: [],
                addresses: [],
                emailAddress: null
            }
            this.openPatients.push(newPatient);
        }

        getCurrentPatient(): interfaces.models.patient {
            return this.currentPatient;
        };

        openPatientById(patientId: number) {
            return this.$http.get("api/patients/" + patientId).then(
                (result) => {
                    var patient = <interfaces.models.patient>{};
                    angular.copy(result.data, patient);
                    if (!this.isOpenPatient(patient.patientId)) {
                        this.openPatients.push(patient);
                    }
                    this.setCurrentPatientById(patient.patientId);
                },
                (error) => {

                });
        }

        savePatient() {
            if (this.currentPatient.patientId === 0) {
                return this.$http.post("api/patients/", this.currentPatient).then(
                    (result) => {
                        angular.copy(result.data, this.currentPatient);
                    },
                    (error) => {

                    });
            }
            return this.$http.put("api/patients/" + this.currentPatient.patientId, this.currentPatient).then(
                (result) => {
                    angular.copy(result.data, this.currentPatient);
                    console.log(result.data);
                    console.log(this.currentPatient);
                },
                (error) => {

                });
        }

        setCurrentPatientById(patientId: number): void {
            if (patientId != null) {
                for (var i = 0; i < this.openPatients.length; i++) {
                    var openPatient = this.openPatients[i];
                    if (openPatient.patientId === patientId) {
                        angular.copy(openPatient, this.currentPatient);
                    }
                }
            }
        }
    }
    angular.module("patient").service("PatientManagerService", PatientManagerService);
}