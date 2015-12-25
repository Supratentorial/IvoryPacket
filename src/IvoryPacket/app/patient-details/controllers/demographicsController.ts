module patient.controllers {
    "use strict"
    export class DemographicsController {
        static $inject = ["PatientShellService"];
        genderOptions: string[] = ["Male", "Female"];
        titleOptions: string[] = ["Mr", "Mrs", "Master", "Ms", "Doctor"]
        isBusy: boolean = false;
        title: string;
        givenName: string;
        middleNames: string;
        familyName: string;
        gender: string;
        dateOfBirth: Date;
        preferredName: string;
        constructor(private patientShellService: patient.services.patientShellService) {
            this.givenName = this.patientShellService.currentPatient.givenName;
            this.middleNames = this.patientShellService.currentPatient.middleNames;
            this.familyName = this.patientShellService.currentPatient.familyName;
            this.title = this.patientShellService.currentPatient.title;
            this.preferredName = this.patientShellService.currentPatient.preferredName;
            this.gender = this.patientShellService.currentPatient.gender;
            this.dateOfBirth = this.patientShellService.currentPatient.dateOfBirth;
        }

        updateDemographics(): void {
            this.isBusy = true;
            this.patientShellService.currentPatient.givenName = this.givenName;
            this.patientShellService.currentPatient.middleNames = this.middleNames;
            this.patientShellService.currentPatient.familyName = this.familyName;
            this.patientShellService.currentPatient.title = this.title;
            this.patientShellService.currentPatient.gender = this.gender;
            this.patientShellService.currentPatient.dateOfBirth = this.dateOfBirth;
            this.patientShellService.currentPatient.preferredName = this.preferredName;
            this.patientShellService.savePatient().then(() => { this.isBusy = false; });
        }
    }
    angular.module("patient").controller("DemographicsController", patient.controllers.DemographicsController);
}