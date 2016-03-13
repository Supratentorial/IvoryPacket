module patient.services {
    export class EmailService implements interfaces.services.emailService {
        static $inject = ["PatientManagerService"];
        currentPatient: interfaces.models.patientDetailed;
        constructor(private patientManagerService: interfaces.services.patientManagerService) {

        }

        getCurrentPatientEmail(): interfaces.models.emailAddress {
            var emailAddress: interfaces.models.emailAddress = this.createNewEmail();
            angular.copy(this.patientManagerService.getCurrentPatient().emailAddress, emailAddress);
            return emailAddress;
        }

        setCurrentPatientEmail(email: interfaces.models.emailAddress) {
            this.patientManagerService.getCurrentPatient().emailAddress = email;
        }

        createNewEmail(): interfaces.models.emailAddress {
            var email = <interfaces.models.emailAddress>{
                isPreferred: true,
                emailAddressId: 0,
                emailValue: ""
            };
            return email;
        }
    }
    angular.module("patient").service("EmailService", EmailService);
}