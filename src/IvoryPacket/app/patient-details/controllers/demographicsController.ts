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
        age: string;
        preferredName: string;
        homePhone: string;
        mobilePhone: string;
        workPhone: string;
        constructor(private patientShellService: interfaces.patient.services.patientShellService) {
            this.givenName = this.patientShellService.currentPatient.givenName;
            this.middleNames = this.patientShellService.currentPatient.middleNames;
            this.familyName = this.patientShellService.currentPatient.familyName;
            this.title = this.patientShellService.currentPatient.title;
            this.preferredName = this.patientShellService.currentPatient.preferredName;
            this.gender = this.patientShellService.currentPatient.gender;
            this.dateOfBirth = this.parseDate(this.patientShellService.currentPatient.dateOfBirth);
            this.mobilePhone = this.patientShellService.currentPatient.mobilePhone;
            this.workPhone = this.patientShellService.currentPatient.workPhone;
            this.homePhone = this.patientShellService.currentPatient.homePhone;
            this.age = this.calculateAge(this.dateOfBirth);
        }

        parseDate(dateOfBirthString: string): Date {
            var dateOfBirth: Date;
            if (!dateOfBirthString || 0 === dateOfBirthString.length) {
                return;
            }
            try {
                dateOfBirth = new Date(dateOfBirthString);
            }
            catch (e) {
                console.log(e.message);
                return;
            }
            return dateOfBirth;
        }

        calculateAge(dateOfBirth: Date): string {
            if (!dateOfBirth) { return; }
            var today = new Date();
            var age: number = today.getFullYear() - dateOfBirth.getFullYear();
            var m: number = today.getMonth() - dateOfBirth.getMonth();
            if (m < 0 || (m === 0 && today.getDate() < dateOfBirth.getDate())) {
                age--;
            }
            var ageString: string = age.toString() + " years, " + m.toString() + " months";
            return ageString;
        }

        updateDemographics(): void {
            this.isBusy = true;
            this.patientShellService.currentPatient.givenName = this.givenName;
            this.patientShellService.currentPatient.middleNames = this.middleNames;
            this.patientShellService.currentPatient.familyName = this.familyName;
            this.patientShellService.currentPatient.title = this.title;
            this.patientShellService.currentPatient.gender = this.gender;
            //this.patientShellService.currentPatient.dateOfBirth = this.dateOfBirth.to;
            this.patientShellService.currentPatient.preferredName = this.preferredName;
            this.patientShellService.currentPatient.mobilePhone = this.mobilePhone;
            this.patientShellService.currentPatient.workPhone = this.workPhone;
            this.patientShellService.currentPatient.homePhone = this.homePhone;
            this.patientShellService.savePatient().then(() => { this.isBusy = false; });
        }
    }
    angular.module("patient").controller("DemographicsController", DemographicsController);
}