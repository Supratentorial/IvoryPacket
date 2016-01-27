module patient.controllers {
    "use strict"
    export class DemographicsController {

        genderOptions: string[] = ["Male", "Female"];
        titleOptions: string[] = ["Mr", "Mrs", "Master", "Ms", "Doctor"];
        contactOptions: string[] = ["Mobile", "Home", "Work", "Email"];
        isBusy: boolean = false;
        title: string;
        givenName: string;
        middleNames: string;
        familyName: string;
        gender: string;
        dateOfBirth: Date;
        preferredName: string;
        homePhone: interfaces.models.phoneNumber;
        mobilePhone: interfaces.models.phoneNumber;
        workPhone: interfaces.models.phoneNumber;
        emailAddress: interfaces.models.emailAddress;

        static $inject = ["PatientManagerService", "moment", "PhoneNumberService", "EmailService", "DemographicsService", "$state"];
        constructor(
            private patientManagerService: interfaces.services.patientManagerService,
            private moment: moment.MomentStatic,
            private phoneNumberService: interfaces.services.phoneNumberService,
            private emailService: interfaces.services.emailService,
            private demographicsService: interfaces.services.demographicsService,
            private $state: angular.ui.IStateService) {

            var patientId: number = this.$state.params["patientId"];
            if (patientId) {
                this.patientManagerService.openPatientById(patientId).then(
                    (response) => {
                        this.demographicsService.getCurrentPatient();
                        this.givenName = this.demographicsService.currentPatient.givenName;
                        this.middleNames = this.demographicsService.currentPatient.middleNames;
                        this.familyName = this.demographicsService.currentPatient.familyName;
                        this.title = this.demographicsService.currentPatient.title;
                        this.preferredName = this.demographicsService.currentPatient.preferredName;
                        this.gender = this.demographicsService.currentPatient.gender;
                        this.dateOfBirth = new Date(this.demographicsService.currentPatient.dateOfBirth);
                        this.emailAddress = this.emailService.getCurrentPatientEmail();
                        if (this.phoneNumberService.currentPatientHasMobileNumber()) {
                            this.mobilePhone = <interfaces.models.phoneNumber>{};
                            angular.copy(this.phoneNumberService.getCurrentPatientMobileNumber(), this.mobilePhone);
                            console.log(this.mobilePhone);
                        }
                        else {
                            this.mobilePhone = this.phoneNumberService.createNewMobileNumber();
                        }
                    });
            } else {
                this.patientManagerService.createNewPatient();
                this.patientManagerService.setCurrentPatientById(0);
                this.demographicsService.getCurrentPatient();
            }
        }

        savePatient(): void {
            this.isBusy = true;
            this.demographicsService.currentPatient.givenName = this.givenName;
            this.demographicsService.currentPatient.familyName = this.familyName;
            this.demographicsService.currentPatient.title = this.title;
            this.demographicsService.currentPatient.middleNames = this.middleNames
            this.demographicsService.currentPatient.gender = this.gender;
            this.demographicsService.currentPatient.dateOfBirth = moment(this.dateOfBirth).format("YYYY/MM/DD");
            this.demographicsService.currentPatient.preferredName = this.preferredName;
            this.emailService.setCurrentPatientEmail(this.emailAddress);
            this.phoneNumberService.setCurrentPatientMobileNumber(this.mobilePhone);
            this.patientManagerService.saveCurrentPatient()
                .then(
                () => {
                    this.$state.go("patient.detail.demographics.view");
                },
                () => { console.log("patient failed to save") })
                .finally(
                () => { this.isBusy = false; })
        }

        updatePhoneNumber() {

        }
    }
    angular.module("patient").controller("DemographicsController", DemographicsController);
}