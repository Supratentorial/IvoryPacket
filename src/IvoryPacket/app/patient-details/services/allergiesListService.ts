module patient.services {
    export class AllergiesListService {
        static $inject = ["$http", "$q", "PatientManagerService"];
        currentPatientAllergies: interfaces.models.allergy[];
        constructor(private $http: angular.IHttpService, private $q: angular.IQService, private patientManagerService: interfaces.services.patientManagerService) {
            this.currentPatientAllergies = [];
        }

        getCurrentPatientAllergies(): angular.IPromise<any> {
            var deferred = this.$q.defer();
            return this.$http.get("api/patients/" + this.patientManagerService.currentPatientId + "/allergies").then(
                (response) => {
                    angular.copy(response.data, this.currentPatientAllergies);
                    deferred.resolve();
                },
                (error) => {

                    deferred.reject();
                });
            return deferred.promise;
        }
    }

    angular.module("patient").service("AllergiesListService", AllergiesListService);
}