//Manages currently open patients.
module patient.services {
    export class PatientManagerService implements interfaces.services.patientManagerService {
        openPatients: interfaces.models.patient[];
        currentPatientId: number;
        static $inject = ["$http", "$q"];
        constructor(private $http: angular.IHttpService, private $q: angular.IQService) {
            this.openPatients = [];
        }

        isPatientOpen(patientId: number): boolean {
            for (var i = 0; i < this.openPatients.length; i++) {
                var openPatient = this.openPatients[i];
                if (patientId === openPatient.patientId) {
                    return true;
                }
            }
            return false;
        }

        replaceOpenPatient(patient: interfaces.models.patient): void {
            for (var i = 0; i < this.openPatients.length; i++) {
                if (patient.patientId === this.openPatients[i].patientId) {
                    this.openPatients[i] = patient;
                }
            }
        }

        isCurrentPatient(patientId: number): boolean {
            if (this.currentPatientId === patientId) {
                return true;
            }
            return false;
        }

        createNewPatient(): void {
            if (this.isPatientOpen(0)) {
                //TODO: Use message service to alert user.
                return;
            }
            var newPatient = <interfaces.models.patient>{
                patientId: 0,
                title: null,
                givenName: "",
                middleNames: null,
                familyName: "",
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
            if (this.openPatients.length) {
                for (var i = 0; i < this.openPatients.length; i++) {
                    var patient: interfaces.models.patient = this.openPatients[i];
                    if (patient.patientId === this.currentPatientId) {
                        return patient;
                    }
                }
            }
        };

        setCurrentPatientById(patientId: number): void {
            if (patientId != null) {
                for (var i = 0; i < this.openPatients.length; i++) {
                    var openPatient = this.openPatients[i];
                    if (openPatient.patientId === patientId) {
                        this.currentPatientId = openPatient.patientId;
                    }
                }
            }
        }

        openPatientById(patientId: number) {
            return this.$http.get("api/patients/" + patientId).then(
                (result) => {
                    var patient = <interfaces.models.patient>{};
                    angular.copy(result.data, patient);
                    if (!this.isPatientOpen(patient.patientId)) {
                        this.openPatients.push(patient);
                    }
                    this.setCurrentPatientById(patient.patientId);
                },
                (error) => {

                });
        }

        closePatientById(patientId: number) {
            if (patientId === 0) {
                for (var i; i < this.openPatients; i++) {
                    if (patientId === this.openPatients[i].patientId) {
                        var index = this.openPatients.indexOf(this.openPatients[i]);
                        this.openPatients.splice(index, 1);
                    }
                }
            }
        }

        saveCurrentPatient() {
            var currentPatient: interfaces.models.patient = this.getCurrentPatient();
            if (currentPatient.patientId === 0) {
                return this.$http.post("api/patients/", currentPatient).then(
                    (result) => {
                        var savedPatient: interfaces.models.patient = <interfaces.models.patient>{};
                        angular.copy(result.data, savedPatient);
                        for (var i = 0; i < this.openPatients.length; i++) {
                            if (this.openPatients[i].patientId === 0) {
                                this.openPatients[i] = savedPatient;
                            }
                        }
                        this.setCurrentPatientById(savedPatient.patientId);
                    },
                    (error) => {

                    });
            }
            return this.$http.put("api/patients/" + currentPatient.patientId, currentPatient).then(
                (result) => {
                    var savedPatient: interfaces.models.patient = <interfaces.models.patient>{};
                    angular.copy(result.data, savedPatient);
                    this.replaceOpenPatient(savedPatient);
                },
                (error) => {

                });
        }
    }
    angular.module("patient").service("PatientManagerService", PatientManagerService);
}