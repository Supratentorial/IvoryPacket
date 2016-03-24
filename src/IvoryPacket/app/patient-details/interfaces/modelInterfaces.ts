module interfaces {
    export interface smokingDTO {
        lastUpdated: Date;
        smokingStatus: string;
        cigarettesPerDay: number;
        ageStarted: number;
        ageCeased: number;
        notes: string;
        patientId: number;
        smokingObservationId: number;
    }
    
    export interface alcoholDTO {

    }

    export interface drugDTO {

    }


    export interface vitalSignsDTO {
        vitalSignsId: number;
        heartRate: number;
        systolicBloodPressure: number;
        diastolicBloodPressure: number;
        oxygenSaturation: number;
        respiratoryRate: number;
    }
}