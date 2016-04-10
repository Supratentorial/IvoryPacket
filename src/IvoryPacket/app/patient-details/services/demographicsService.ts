module patient.services {
    export class DemographicsService implements interfaces.demographicsService {
        static $inject = [];
        constructor(private patientShellService: interfaces.patientShellService) {

        }

        createNewPhoneNumber(type: string): interfaces.phoneNumber {
            return <interfaces.phoneNumber>{
                phoneNumberId: 0,
                countryCode: "61",
                areaCode: "3",
                isPreferred: false,
                type: type,
                value: ""
            }
        }

        createNewAddress(type: string): interfaces.address {
            return <interfaces.address>{
                addressId: 0,
                type: type,
                state: "",
                city: "",
                country: "Australia",
                postalCode: ""
            }
        }

        isValidPhoneNumber(phoneNumber: interfaces.phoneNumber): boolean {
            if (phoneNumber) {
                if (phoneNumber.value && phoneNumber.countryCode) {
                    return true;
                }
            }
        }



    }
    angular.module("patient").service("DemographicsService", DemographicsService);
}