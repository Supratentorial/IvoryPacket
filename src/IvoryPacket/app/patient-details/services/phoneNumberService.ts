module common.services {
    export class PhoneNumberService implements interfaces.services.phoneNumberService {
        static $inject = ["PatientManagerService"];
        constructor(private patientManagerService: interfaces.services.patientManagerService) {

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

    isValidPhoneNumber(phoneNumber: interfaces.phoneNumber): boolean {
        if (phoneNumber.value === "") {
            return false;
        }
        return true;
    }

}
angular.module("patient").service("PhoneNumberService", PhoneNumberService);
}