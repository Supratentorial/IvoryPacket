module interfaces {

    export interface vitalsService {
        createNewVitalSigns(): interfaces.vitalSign;
        getVitalsById(vitalsId: number): interfaces.vitalSign;
        saveVitalSigns(vitalSign): void;
        getHeartRateValues(): Array<number>;
        getHeartRateLabels(): Array<string>;
    }

    export interface socialHistoryService {
        createNewSocialHistory(): interfaces.socialHistory;
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

    export interface demographicsService {
        createNewPhoneNumber(type: string): interfaces.phoneNumber;
        createNewAddress(type: string): interfaces.address;
        isValidPhoneNumber(phoneNumber: interfaces.phoneNumber): boolean;
    }

}