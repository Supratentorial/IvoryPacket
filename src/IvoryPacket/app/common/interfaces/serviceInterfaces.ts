module interfaces.services {
    export interface patientListService {
        getAllPatients: any;
    }

    
    

    export interface sessionService {
        getSessionTimeSlots(): interfaces.models.timeSlot[];

    }

    export interface timeSlotService {
        getTimeSlotHeight(): number;
        zoomIn(): number;
        zoomOut(): number;
    }
}