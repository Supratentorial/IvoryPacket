module interfaces {
    export interface patientDetailed {
        patientId: number;
        title: string;
        givenName: string;
        middleNames: string;
        familyName: string;
        preferredName: string;
        gender: string;
        dateOfBirth: string;
        isActive: boolean;
        
        emailAddress: emailAddress;

        medicareCardNumber?: number;
        medicareCardExpiry?: string;
        medicareCardPosition?: number;

        mobilePhoneId: number;
        mobilePhoneCountryCode: number;
        mobilePhoneNumber: number;
        homePhoneId: number;
        homePhoneCountryCode: number;
        homePhoneAreaCode: number;
        homePhoneNumber: number;
        workPhoneId: number;
        workPhoneCountryCode: number;
        workPhoneAreaCode: number;
        workPhoneNumber: number;
        preferredContact: string;

        residentialAddressId: number;
        residentialAddressLine1: string;
        residentialAddressLine2: string;
        residentialAddressState: string;
        residentialAddressSuburb: string;
        residentialAddressPostalCode: string;
        residentialAddressCountry: string;
    }

    export interface emailAddress {
        emailAddressId: number;
        emailValue: string;
        isPreferred: boolean;
    }

    export interface phoneNumber {
        phoneNumberId: number;
        countryCode: number;
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
}