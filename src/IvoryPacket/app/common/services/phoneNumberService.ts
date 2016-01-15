module common.services {
    export class PhoneNumberService implements interfaces.services.phoneNumberService {
        static $inject = [];
        constructor() {

        }

        getPhoneNumberByType(type: string, phoneNumberCollection: interfaces.models.phoneNumber[]): interfaces.models.phoneNumber {
            if (type === "") {
                
            }
            if (phoneNumberCollection) {
                for (var i = 0; i < phoneNumberCollection.length; i++) {
                    var phoneNumber: interfaces.models.phoneNumber = phoneNumberCollection[i];
                    if (phoneNumber.type === type) {
                        return phoneNumber;
                    }
                };
            }
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