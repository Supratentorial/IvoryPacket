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
}