﻿module patient.controllers {
    export class CreateAppointmentModalController {

        showCreateAppointment: boolean = false;
        newAppointment: interfaces.appointment = {
            appointmentId: 0,
            appointmentType: null,
            patientId: null,
            appointmentDateTime: null
        };

        static $inject: Array<string> = ["AppointmentService", "PatientService"]
        constructor(private appointmentService: interfaces.appointmentService, private patientService: interfaces.patientService) {

        }

        searchPatients(searchString) {
            return this.patientService.searchPatients(searchString).then((response) => {
                return response.data;
            }); 
        }

        createAppointment() {
            this.appointmentService.saveNewAppointment(this.newAppointment);
        }

        patientSelected() {
            this.showCreateAppointment = true;
        }
        
    }
    angular.module("patient").controller("CreateAppointmentModalController", CreateAppointmentModalController);
}