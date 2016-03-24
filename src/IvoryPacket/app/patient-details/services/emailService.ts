module patient.services {
    export class EmailService {
        static $inject = ["PatientManagerService"];
        currentPatient: interfaces.patientDetailed;
        constructor(private patientManagerService: interfaces.services.patientManagerService) {

        }

        getCurrentPatientEmail(): interfaces.emailAddress {
            var emailAddress: interfaces.emailAddress = this.createNewEmail();
            angular.copy(this.patientManagerService.getCurrentPatient().emailAddress, emailAddress);
            return emailAddress;
        }

        setCurrentPatientEmail(email: interfaces.emailAddress) {
            this.patientManagerService.getCurrentPatient().emailAddress = email;
        }

        createNewEmail(): interfaces.emailAddress {
            var email = <interfaces.emailAddress>{
                isPreferred: true,
                emailAddressId: 0,
                emailValue: ""
            };
            return email;
        }
    }
    angular.module("patient").service("EmailService", EmailService);
}