//Manages currently open patients.
module patient.services {
    export class PatientService implements interfaces.patientService {
        static $inject = ["$http", "$q"];

        constructor(private $http: angular.IHttpService, private $q: angular.IQService) {
            
        }

        createNewPatient(): interfaces.patient {
            return <interfaces.patient>{
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
            return this.$http.get("api/patients/" + patientId + "?detailed=true");
        }

        saveNewPatient(newPatient: interfaces.patient): angular.IPromise<any> {
            if (newPatient.patientId === 0) {
                return this.$http.post("api/patients", newPatient);
            }
        }

        updatePatient(updatedPatient: interfaces.patient): angular.IPromise<any> {
            return this.$http.put("api/patients/" + updatedPatient.patientId, updatedPatient);
        }

        searchPatients(searchString: string): angular.IPromise<any> {
            return this.$http.get("api/patients/?searchString=" + searchString);
        };
    }
    angular.module("patient").service("PatientService", PatientService);
}