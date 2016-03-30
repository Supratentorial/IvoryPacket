module patient.services {
    "use strict"
    export class PatientShellService {
        openPatients: interfaces.patientDetailed[] = [];
        currentPatient: interfaces.patientDetailed;

        static $inject: Array<string> = ["PatientService"];
        constructor(private patientService: interfaces.patientService) {

        }

        addPatientToOpenList(patient: interfaces.patientDetailed): void {
            if (!this.isPatientOpen(patient.patientId)) {
                this.openPatients.push(patient);
            }
        }

        removePatientFromOpenList(patientId: number): void {
            for (var i; i < this.openPatients; i++) {
                if (patientId === this.openPatients[i].patientId) {
                    var index = this.openPatients.indexOf(this.openPatients[i]);
                    this.openPatients.splice(index, 1);
                }
            }
        }

        isPatientOpen(patientId: number): boolean {
            for (var i = 0; i < this.openPatients.length; i++) {
                if (patientId === this.openPatients[i].patientId) {
                    return true;
                }
            }
            return false;
        }

        setCurrentPatient(patientId: number): void {
            if (patientId) {
                for (var i = 0; i < this.openPatients.length; i++) {
                    if (patientId === this.openPatients[i].patientId) {
                        this.currentPatient = this.openPatients[i];
                    }
                }
            }
        }

        saveCurrentPatient(): angular.IPromise<any> {
           return this.patientService.updatePatient(this.currentPatient).then((result) => {
                angular.copy(result.data, this.currentPatient);
            })
        }

    }
    angular.module("patient").service("PatientShellService", PatientShellService);
}