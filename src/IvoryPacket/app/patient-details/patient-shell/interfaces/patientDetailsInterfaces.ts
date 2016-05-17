module interfaces {
    export interface patientService {
        createNewPatient(): interfaces.patientDetailed;
        getPatientById(patientId: number): angular.IPromise<any>;
        saveNewPatient(newPatient: interfaces.patientDetailed): angular.IPromise<any>;
        updatePatient(updatedPatient: interfaces.patientDetailed): angular.IPromise<any>;
        searchPatients(searchTerm: string): angular.IPromise<any>;
    }

    export interface patientShellService {
        openPatients: interfaces.patientDetailed[];
        currentPatient: interfaces.patientDetailed;
        isPatientOpen(patientId: number): boolean;
        setCurrentPatient(patientId: number): void;
        removePatientFromOpenList(patientId: number): void;
        addPatientToOpenList(patientId: number): void;
        saveCurrentPatient(): angular.IPromise<any>;
    }
}