module patient.interfaces {
    export interface patient {
        firstName: string;
        lastName: string;

    }

    export interface allergy {
        allergyId: number;
        onset: Date;
        recordedDate: Date;
        substance: string;
        severity: string; //mild | moderate | severe
        type: string; //allergy | intolerance
        note: string;
        clinicalManifestation: string;
    }
}