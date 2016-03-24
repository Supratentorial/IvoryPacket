module patient.controllers {
    "use strict"
    export class DemographicsController {

        genderOptions: string[] = ["Male", "Female"];
        titleOptions: string[] = ["Mr", "Mrs", "Master", "Ms", "Doctor"];
        contactOptions: string[] = ["Mobile", "Home", "Work", "Email"];
        isLoading: boolean = false;
        title: string;
        givenName: string;
        middleNames: string;
        familyName: string;
        gender: string;
        dateOfBirth: Date;
        preferredName: string;
        homePhone: interfaces.phoneNumber;
        mobilePhone: interfaces.phoneNumber;
        workPhone: interfaces.phoneNumber;
        emailAddress: interfaces.emailAddress;

        static $inject = ["PatientManagerService", "moment", "PhoneNumberService", "EmailService", "DemographicsService", "$state"];
        constructor(
            private patientManagerService: interfaces.services.patientManagerService,
            private moment: moment.MomentStatic,
            private phoneNumberService: interfaces.services.phoneNumberService,
            private demographicsService: interfaces.services.demographicsService,
            private $state: angular.ui.IStateService) {

            var patientId: number = this.$state.params["patientId"];
            if (patientId) {
                this.isLoading = true;
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
                        this.emailAddress = this.demographicsService.currentPatient.emailAddress;
                    }).finally(() => {
                        this.isLoading = false;
                    });
            }
        }

        savePatient(): void {
            this.isLoading = true;
            this.demographicsService.currentPatient.givenName = this.givenName;
            this.demographicsService.currentPatient.familyName = this.familyName;
            this.demographicsService.currentPatient.title = this.title;
            this.demographicsService.currentPatient.middleNames = this.middleNames
            this.demographicsService.currentPatient.gender = this.gender;
            this.demographicsService.currentPatient.dateOfBirth = moment(this.dateOfBirth).format("YYYY/MM/DD");
            this.demographicsService.currentPatient.preferredName = this.preferredName;
            this.patientManagerService.updateCurrentPatient()
                .then(
                () => {
                    console.log("patient saved successfully");
                },
                () => { console.log("patient failed to save") })
                .finally(
                () => {
                    this.isLoading = false;
                    this.$state.go("patient.detail.demographics-view");
                })
        }

        updatePhoneNumber() {

        }
    }
    angular.module("patient").controller("DemographicsController", DemographicsController);
}