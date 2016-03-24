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
        mobilePhoneCountryCode: string;
        mobilePhoneNumber: string;
        homePhoneId: number;
        homePhoneCountryCode: string;
        homePhoneAreaCode: string;
        homePhoneNumber: string;
        workPhoneId: number;
        workPhoneCountryCode: string;
        workPhoneAreaCode: string;
        workPhoneNumber: string;
        preferredContact: string;

        residentialAddressId: number;
        residentialAddressNumber: string;
        residentialAddressStreet: string;
        residentialAddressState: string;
        residentialAddressSuburb: string;
        residentialAddressPostalCode: string;
    }

    export interface emailAddress {
        emailAddressId: number;
        emailValue: string;
        isPreferred: boolean;
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
}