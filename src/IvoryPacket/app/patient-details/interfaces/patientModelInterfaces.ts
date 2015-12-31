module interfaces.patient.models {
    export interface patient {
        patientId: number;
        title: string;
        givenName: string;
        middleNames: string;
        familyName: string;
        preferredName: string;
        gender: string;
        dateOfBirth: string;
        ethnicity?: string;
        isActive: boolean;
        mobilePhone: string;
        workPhone: string;
        homePhone: string;

        medicareCardNumber?: number;
        medicareCardExpiry?: Date;
        medicareCardPosition?: number;

        allergies: allergy[];
        contactPoints: contactPoint[];
    }

    export interface allergy {
        allergyId: number;
        recordedDate: Date;
        substance: string;
        severity: string; //mild | moderate | severe
        type: string; //allergy | intolerance
        note: string;
        clinicalManifestation: string;
    }

    export interface contactPoint{
        contactPointId: number;
        system: string,
        use: string,
        value: string
    }
}