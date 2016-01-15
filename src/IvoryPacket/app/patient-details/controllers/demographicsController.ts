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
        fullName: string;
        gender: string;
        dateOfBirth: Date;
        age: string;
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
            this.patientManagerService.openPatientById(patientId).then(
                (response) => {
                    this.givenName = this.patientManagerService.currentPatient.givenName;
                    this.middleNames = this.demographicsService.getCurrentPatientMiddleNames();
                    this.familyName = this.patientManagerService.currentPatient.familyName;
                    this.title = this.patientManagerService.currentPatient.title;
                    this.preferredName = this.patientManagerService.currentPatient.preferredName;
                    this.gender = this.patientManagerService.currentPatient.gender;
                    this.dateOfBirth = new Date(this.patientManagerService.currentPatient.dateOfBirth);
                    this.age = this.demographicsService.getCurrentPatientAge();
                    this.fullName = this.demographicsService.getCurrentPatientFullName();
                    //this.mobilePhone = this.phoneNumberService.getPhoneNumberByType("mobile");
                    //this.homePhone = this.phoneNumberService.getPhoneNumberByType("home");
                    //this.workPhone = this.phoneNumberService.getPhoneNumberByType("work");
                    this.emailAddress = this.emailService.getCurrentPatientEmail();
                });
        }

        savePatient(): void {
            this.isBusy = true;
            this.patientManagerService.currentPatient.givenName = this.givenName;
            this.patientManagerService.currentPatient.middleNames = this.middleNames;
            this.patientManagerService.currentPatient.familyName = this.familyName;
            this.patientManagerService.currentPatient.title = this.title;
            this.patientManagerService.currentPatient.gender = this.gender;
            this.patientManagerService.currentPatient.dateOfBirth = moment(this.dateOfBirth).format("YYYY/MM/DD");
            this.patientManagerService.currentPatient.preferredName = this.preferredName;
            this.emailService.setCurrentPatientEmail(this.emailAddress);
            //this.phoneNumberService.addNewPatientPhoneNumber(this.mobilePhone)
            
            this.patientManagerService.savePatient()
                .then(
                () => {
                    console.log(this.demographicsService.getCurrentPatientMiddleNames());
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