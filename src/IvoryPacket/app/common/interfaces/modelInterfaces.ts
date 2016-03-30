 module interfaces.models {
    

    export interface patientSimple {
        patientId: number;
        title: string;
        fullName: string;
        givenName: string;
        familyName: string;
        preferredName: string;
        gender: string;
        dateOfBirth: string;
        isActive: boolean;
        age: string;
    }

    export interface allergy {
        allergyId: number;
        recordedDate: moment.Moment;
        substance: string;
        severity: string; //mild | moderate | severe
        type: string; //allergy | intolerance | overdose
        note: string;
        clinicalManifestation: string;
        patientId: number;
    }

    export interface encounter {
        encounterId: number;
        patientId: number;

    }

    export interface timeSlot {
        
    }

}