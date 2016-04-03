module common.services {
    export class PhoneNumberService implements interfaces.phoneNumberService {
        static $inject = ["PatientManagerService"];
        constructor(private patientManagerService: interfaces.patientService) {

        }

        createNewMobileNumber(): interfaces.phoneNumber {
            return <interfaces.phoneNumber>{
                phoneNumberId: 0,
                countryCode: "61",
                areaCode: "3",
                isPreferred: false,
                type: "mobile",
                value: ""
            }
        }

        updatePhoneNumber(phoneNumber: interfaces.phoneNumber) {

        }

        saveNewPhoneNumber(phoneNumber: interfaces.phoneNumber) {
            
        }

    isValidPhoneNumber(phoneNumber: interfaces.phoneNumber): boolean {
        if (phoneNumber.value === "") {
            return false;
        }
        return true;
    }

}
angular.module("patient").service("PhoneNumberService", PhoneNumberService);
}