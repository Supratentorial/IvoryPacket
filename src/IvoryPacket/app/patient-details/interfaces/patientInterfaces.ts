module patient.interfaces {
    interface Patient {
        
    }

    export interface Allergy {
        id: number;
        onset: Date;
        recordedDate: Date;
        substance: string;
        severity: string; //mild | moderate | severe
        type: string; //allergy | intolerance
        category: string; 
        note: string;
        reaction: string;
    }
}