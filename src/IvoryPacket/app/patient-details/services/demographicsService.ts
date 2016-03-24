module patient.services {
    export class DemographicsService implements interfaces.services.demographicsService {
        static $inject = ["$http", "PatientManagerService"];
        currentPatient: interfaces.patientDetailed;

        constructor(private $http: angular.IHttpService, private patientManagerService: interfaces.services.patientManagerService) {
              
        }

        getCurrentPatient() : void {
            this.currentPatient = this.patientManagerService.getCurrentPatient();
        }


    }

    angular.module("patient").service("DemographicsService", DemographicsService);
}