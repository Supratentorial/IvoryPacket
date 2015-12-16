module patient.interfaces {
    export interface patientShellService {
        currentPatientId: number;
    }
    
    export interface allergiesService { 
        getAllergySeverityOptions(): angular.IPromise<any>;
        getAllergyReactionTypes(): angular.IPromise<any>;
        saveAllergy(allergy: patient.interfaces.allergy): void;

    }      
}