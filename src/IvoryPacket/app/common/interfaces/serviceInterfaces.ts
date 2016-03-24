module interfaces.services {
    export interface patientListService {
        getAllPatients: any;
    }

    export interface allergiesDetailService {
        getAllergySeverityOptions(): any;
        getAllergyReactionTypes(): any;

        addNewAllergy(allergy: interfaces.models.allergy): angular.IHttpPromise<any>;
        updateExistingAllergy(allergy: interfaces.models.allergy): angular.IHttpPromise<any>;
        getAllergyById(allergyId: number): angular.IHttpPromise<any>;

        allergySeverityOptions: string[];
        allergyReactionTypes: string[];
    }

    export interface allergiesListService {
        getCurrentPatientAllergies(): void;
    }

    export interface patientManagerService {
        openPatients: interfaces.patientDetailed[];
        currentPatientId: number;
        openPatientById(patientId: number): angular.IPromise<any>;
        createNewPatient(): interfaces.patientDetailed;
        saveNewPatient(newPatient: interfaces.patientDetailed);
        getCurrentPatient(): interfaces.patientDetailed;
        setCurrentPatientById(patientId: number): void;
        updateCurrentPatient(): any;
        isPatientOpen(patientId: number): boolean;
        isCurrentPatient(patientId: number): boolean;
    }

    export interface phoneNumberService {
        createNewMobileNumber(): interfaces.phoneNumber;
    }

    export interface demographicsService {
        getCurrentPatient(): void;
        currentPatient: interfaces.patientDetailed;
    }

    export interface sessionService {
        getSessionTimeSlots(): interfaces.models.timeSlot[];
        
    }

    export interface timeSlotService {
        getTimeSlotHeight(): number;
        zoomIn(): number;
        zoomOut(): number;
    }
}