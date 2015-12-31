module interfaces.patient.services {
    export interface PatientListService {
        getAllPatients: any;
    }

    export interface allergiesService {
        getAllergySeverityOptions(): any;
        getAllergyReactionTypes(): any;
        addAllergy(allergy: interfaces.patient.models.allergy): void;
    }

    export interface patientShellService {
        openPatients: interfaces.patient.models.patient[];
        currentPatient: interfaces.patient.models.patient;
        getPatientById(patientId: number): any;
        activatePatient(): void;
        savePatient(): any;
    }
}