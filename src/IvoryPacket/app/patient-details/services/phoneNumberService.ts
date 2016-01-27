module common.services {
    export class PhoneNumberService implements interfaces.services.phoneNumberService {
        static $inject = ["PatientManagerService"];
        constructor(private patientManagerService: interfaces.services.patientManagerService) {

        }

        getCurrentPatientMobileNumber(): interfaces.models.phoneNumber {
            var currentPatient: interfaces.models.patient = this.patientManagerService.getCurrentPatient();
            for (var i = 0; i < currentPatient.phoneNumbers.length; i++) {
                if (currentPatient.phoneNumbers[i].type === "mobile") {
                    return this.patientManagerService.getCurrentPatient().phoneNumbers[i];
                }
            }
        }

        currentPatientHasMobileNumber(): boolean {
            var currentPatient: interfaces.models.patient = this.patientManagerService.getCurrentPatient();
            for (var i = 0; i < currentPatient.phoneNumbers.length; i++) {
                if (currentPatient.phoneNumbers[i].type === "mobile" && currentPatient.phoneNumbers[i].phoneNumberId != 0) {
                    return true;
                }
            }
            return false;
        }

        createNewMobileNumber(): interfaces.models.phoneNumber {
            return <interfaces.models.phoneNumber>{
                phoneNumberId: 0,
                countryCode: "61",
                areaCode: "3",
                isPreferred: false,
                type: "mobile",
                value: ""
            }
        }

        setCurrentPatientMobileNumber(newMobileNumber: interfaces.models.phoneNumber): void {
            var currentPatient: interfaces.models.patient = this.patientManagerService.getCurrentPatient();
            var currentMobileNumber: interfaces.models.phoneNumber = this.getCurrentPatientMobileNumber();
            if (newMobileNumber.phoneNumberId != 0 && newMobileNumber.value) {
                angular.copy(newMobileNumber, currentMobileNumber);
            } else if (newMobileNumber.phoneNumberId === 0 && newMobileNumber.value) {
                currentPatient.phoneNumbers.push(newMobileNumber);
            } else if (newMobileNumber.phoneNumberId != 0 && newMobileNumber.value === "") {
                console.log("Archive the email address");
            }
        }

    getHomePhoneNumber() {

    }

    getWorkPhoneNumber() {

    }

    isExistingPhoneNumber(phoneNumberId: number): boolean {
            
        //for (var i = 0; i < this.patientManagerService.currentPatient.phoneNumbers.length; i++) {
        //    var existingPhone = this.patientManagerService.currentPatient.phoneNumbers[i];
        //    if (phoneNumberId === existingPhone.phoneNumberId) {
        //        return true;
        //    }
        //}
        return false;
    }

    isValidPhoneNumber(phoneNumber: interfaces.models.phoneNumber): boolean {
        if (phoneNumber.value === "") {
            return false;
        }
        return true;
    }

    updateExistingPhoneNumber(phoneNumber: interfaces.models.phoneNumber): void {

    }

}
angular.module("patient").service("PhoneNumberService", PhoneNumberService);
}