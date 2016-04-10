//Manages currently open patients.
module patient.services {
    export class PatientService implements interfaces.patientService {
        static $inject = ["$http", "$q"];

        constructor(private $http: angular.IHttpService, private $q: angular.IQService) {
            
        }

        createNewPatient(): interfaces.patientDetailed {
            return <interfaces.patientDetailed>{
                patientId: 0,
                title: null,
                givenName: null,
                middleNames: null,
                familyName: null,
                preferredName: null,
                gender: null,
                dateOfBirth: null,
                mobilePhoneNumber: null,
                homePhoneNumber: null,
                workPhoneNumber: null,
                preferredContact: null,
                residentialAddress: null,
                socialHistory: null,
                smokingHistory: null,
                alcoholHistory: null,
                drugHistory: null,
                fullName: null,
                vitalSigns: [],
                isActive: true,
                medicareCardNumber: null,
                medicareCardExpiry: null,
                medicareCardPosition: null,
                phoneNumbers: [],
                addresses: [],
                emailAddress: null
            }
        }

        getPatientById(patientId: number): angular.IPromise<any> {
            return this.$http.get("api/patients/" + patientId + "/detailed");
        }

        saveNewPatient(newPatient: interfaces.patientDetailed): angular.IPromise<any> {
            if (newPatient.patientId === 0) {
                return this.$http.post("api/patients", newPatient);
            }
        }

        updatePatient(updatedPatient: interfaces.patientDetailed): angular.IPromise<any> {
            return this.$http.put("api/patients/" + updatedPatient.patientId, updatedPatient);
        }
    }
    angular.module("patient").service("PatientService", PatientService);
}