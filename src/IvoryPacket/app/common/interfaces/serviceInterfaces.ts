module interfaces.services {
    export interface patientListService {
        getAllPatients: any;
    }

    export interface allergiesService {
        getAllergySeverityOptions(): any;
        getAllergyReactionTypes(): any;
        addAllergy(allergy: interfaces.models.allergy): void;
    }

    export interface patientManagerService {
        openPatients: interfaces.models.patient[];
        currentPatient: interfaces.models.patient;
        openPatientById(patientId: number): angular.IPromise<any>;
        createNewPatient();
        setCurrentPatientById(patientId: number): void;
        savePatient(): any;
        isOpenPatient(patientId: number): boolean;
        isCurrentPatient(patientId: number): boolean;
    }

    export interface phoneNumberService {
        //getPhoneNumberByType(type: string): interfaces.models.phoneNumber;
        //addNewPatientPhoneNumber(phoneNumber: interfaces.models.phoneNumber): void;
    }

    export interface emailService {
        getCurrentPatientEmail(): interfaces.models.emailAddress;
        setCurrentPatientEmail(email: interfaces.models.emailAddress): void;
    }

    export interface addressService {

    }

    export interface demographicsService {
        getCurrentPatientFullName(): string;
        getCurrentPatientAge(): string;
        getCurrentPatientMiddleNames(): string;
    }
}