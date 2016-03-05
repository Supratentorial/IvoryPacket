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
        openPatients: interfaces.models.patient[];
        currentPatientId: number;
        openPatientById(patientId: number): angular.IPromise<any>;
        createNewPatient();
        getCurrentPatient(): interfaces.models.patient;
        setCurrentPatientById(patientId: number): void;
        saveCurrentPatient(): any;
        isPatientOpen(patientId: number): boolean;
        isCurrentPatient(patientId: number): boolean;
    }

    export interface phoneNumberService {
        getCurrentPatientMobileNumber(): interfaces.models.phoneNumber;
        currentPatientHasMobileNumber(): boolean;
        createNewMobileNumber(): interfaces.models.phoneNumber;
        setCurrentPatientMobileNumber(mobileNumber: interfaces.models.phoneNumber): void;
        //addNewPatientPhoneNumber(phoneNumber: interfaces.models.phoneNumber): void;
    }

    export interface emailService {
        getCurrentPatientEmail(): interfaces.models.emailAddress;
        setCurrentPatientEmail(email: interfaces.models.emailAddress): void;
    }

    export interface addressService {

    }

    export interface demographicsService {
        getCurrentPatientFullName();
        getCurrentPatientAge();
        getCurrentPatient(): void;
        currentPatient: interfaces.models.patient;
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