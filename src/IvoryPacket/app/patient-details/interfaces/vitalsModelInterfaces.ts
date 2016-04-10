module interfaces {
    export interface vitalSign {
        vitalSignId: number;
        dateRecorded: Date;
        temperature: number;
        heartRate: number;
        respiratoryRate: number;
        oxygenSaturation: number;
        systolicBloodPressure: number;
        diastolicBloodPressure: number;
        height: number;
        weight: number;
        bmi: number;
    }
}