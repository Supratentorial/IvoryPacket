module common.services {
    export class PhoneNumberService implements interfaces.phoneNumberService {
        static $inject = ["PatientShellService"];
        constructor(private patientShellService: interfaces.patientService) {

        }

        createNewMobileNumber(): interfaces.phoneNumber {
            return <interfaces.phoneNumber>{
                phoneNumberId: 0,
                countryCode: "61",
                areaCode: "3",
                isPreferred: false,
                type: "Mobile",
                value: ""
            }
        }

        createNewHomeNumber(): interfaces.phoneNumber {
            return <interfaces.phoneNumber>{
                phoneNumberId: 0,
                countryCode: "61",
                areaCode: "3",
                isPreferred: false,
                type: "Home",
                value: ""
            }
        }

        createNewWorkNumber(): interfaces.phoneNumber {
            return <interfaces.phoneNumber>{
                phoneNumberId: 0,
                countryCode: "61",
                areaCode: "3",
                isPreferred: false,
                type: "Work",
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