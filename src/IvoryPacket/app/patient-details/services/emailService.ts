module patient.services {
    export class EmailService implements interfaces.services.emailService {
        static $inject = ["PatientManagerService"];

        constructor(private patientManagerService: interfaces.services.patientManagerService) {
            this.getCurrentPatientEmail();
        }

        addEmailAddress() {

        }

        getCurrentPatientEmail(): interfaces.models.emailAddress {
            if (this.patientManagerService.currentPatient.emailAddress) {
                return this.patientManagerService.currentPatient.emailAddress;
            }
            return this.createNewEmail();
        }

        createNewEmail(): interfaces.models.emailAddress {
            var email = <interfaces.models.emailAddress>{
                isPreferred: true,
                emailAddressId: 0,
                emailValue: ""
            };
            return email;
        }

        setCurrentPatientEmail(email: interfaces.models.emailAddress) {
            this.patientManagerService.currentPatient.emailAddress = email;
        }
    }
    angular.module("patient").service("EmailService", EmailService);
}