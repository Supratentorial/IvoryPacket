module interfaces {
    export interface substanceUseService {
        saveSmokingObservation(smokingDTO: smokingDTO): angular.IPromise<any>;
        getSmokingObservation(): angular.IPromise<any>;
        getAlcoholObservation(): angular.IPromise<any>;
        saveAlcoholObservation(alcoholDTO: alcoholDTO): angular.IPromise<any>;
        saveDrugObservation(drugDTO: drugDTO): angular.IPromise<any>;
        getDrugObservation(): angular.IPromise<any>;
        createNewSmokingObservation(): smokingDTO;
    }

    export interface vitalsService {
        saveNewVitalSigns(vitalSignsDTO: vitalSignsDTO): angular.IPromise<any>;
        getPatientVitalSigns(): angular.IPromise<any>;
    }

    export interface patientService {
        createNewPatient(): interfaces.patientDetailed;
        getPatientById(patientId: number): angular.IPromise<any>;
        saveNewPatient(newPatient: interfaces.patientDetailed): angular.IPromise<any>;
        updatePatient(updatedPatient: interfaces.patientDetailed): angular.IPromise<any>;
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

    export interface demographicsService {
        getCurrentPatient(): void;
        currentPatient: interfaces.patientDetailed;
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

    export interface phoneNumberService {
        createNewMobileNumber(): interfaces.phoneNumber;
        createNewHomeNumber(): interfaces.phoneNumber;
        createNewWorkNumber(): interfaces.phoneNumber;
    }

}