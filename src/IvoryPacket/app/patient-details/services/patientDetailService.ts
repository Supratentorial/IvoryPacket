﻿module patient.services {
    export class PatientDetailService {
        
        static $inject = ["$http", "PatientShellService"];
        constructor(private $http: angular.IHttpService, private patientShellService: interfaces.patient.services.patientShellService) {
            
        }
    }
    angular.module("patient").service("PatientDetailService", PatientDetailService);
}