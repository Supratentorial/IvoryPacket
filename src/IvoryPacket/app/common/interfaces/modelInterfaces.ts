module interfaces.models {
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

        medicareCardNumber?: number;
        medicareCardExpiry?: string;
        medicareCardPosition?: number;

        allergies: allergy[];
        addresses: address[];
        emailAddress: emailAddress;
        phoneNumbers: phoneNumber[];
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

    export interface phoneNumber {
        phoneNumberId: number;
        countryCode: string;
        areaCode: string;
        value: string;
        type: string;
        isPreferred: boolean;
    }

    export interface address {
        addressId: number;
        type: string;
        city: string;
        state: string;
        postalCode: string;
        country: string;
    }

    export interface emailAddress {
        emailAddressId: number;
        emailValue: string;
        isPreferred: boolean;
    }

    export interface encounter {
        encounterId: number;
        patientId: number;

    }
}