module interfaces {
    export interface patientDetailed {
        patientId: number;
        title: string;
        givenName: string;
        middleNames: string;
        familyName: string;
        fullName: string;
        preferredName: string;
        gender: string;
        dateOfBirth: string;
        isActive: boolean;
        
        emailAddress: emailAddress;

        medicareCardNumber?: number;
        medicareCardExpiry?: string;
        medicareCardPosition?: number;

        mobilePhoneNumber: phoneNumber;
        homePhoneNumber: phoneNumber;
        workPhoneNumber: phoneNumber;

        residentialAddress: address;
        socialHistory: socialHistory;
        smokingHistory: smokingHistory;
        alcoholHistory: alcoholHistory;
        drugHistory: drugHistory;
        vitalSigns : vitalSign[];
    }

    export interface emailAddress {
        emailAddressId: number;
        emailValue: string;
        isPreferred: boolean;
    }

    export interface phoneNumber {
        phoneNumberId: number;
        countryCode: string;
        areaCode?: string;
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

    
}