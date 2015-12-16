module patient.services {
    export class PatientShellService implements patient.interfaces.patientShellService {

        currentPatientId: number;
        constructor() {

        }
    }
    angular.module("patient").service("PatientShellService", patient.services.PatientShellService);
}