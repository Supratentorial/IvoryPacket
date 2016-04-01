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
                mobilePhoneId: 0,
                mobilePhoneCountryCode: "+61",
                mobilePhoneNumber: null,
                homePhoneId: 0,
                homePhoneCountryCode: "+61",
                homePhoneAreaCode: "3",
                homePhoneNumber: null,
                workPhoneId: 0,
                workPhoneCountryCode: "+61",
                workPhoneAreaCode: "3",
                workPhoneNumber: null,
                preferredContact: null,
                residentialAddressId: 0,
                residentialAddressLine1: null,
                residentialAddressLine2: null,
                residentialAddressSuburb: null,
                residentialAddressState: null,
                residentialAddressPostalCode: null,
                residentialAddressCountry: null,
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