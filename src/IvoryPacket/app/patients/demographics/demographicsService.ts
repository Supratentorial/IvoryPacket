module patient.services {
    export class DemographicsService implements interfaces.demographicsService {
        static $inject = ["PatientShellService"];
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

        getFullNameWithTitle(): string {
            var givenName = this.patientShellService.currentPatient.givenName;
            var familyName = this.patientShellService.currentPatient.familyName.toUpperCase();
            var middleNames = this.patientShellService.currentPatient.middleNames;
            var title = this.patientShellService.currentPatient.title;
            return familyName + ", " + givenName + " " + middleNames + " (" + title + ")"; 
        }


    }
    angular.module("patient").service("DemographicsService", DemographicsService);
}