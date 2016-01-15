var patient;
(function (patient) {
    var services;
    (function (services) {
        var AllergiesService = (function () {
            function AllergiesService(patientManagerService, $http) {
                this.patientManagerService = patientManagerService;
                this.$http = $http;
            }
            AllergiesService.prototype.addAllergy = function (allergy) {
                this.patientManagerService.currentPatient.allergies.push(allergy);
            };
            AllergiesService.prototype.deleteAllergy = function (allergyId) {
                //Todo: change allergy status.
            };
            AllergiesService.prototype.getAllergySeverityOptions = function () {
                return this.$http.get("api/allergies/valuesets/severity").then(
                //Success
                function (response) {
                    console.log("Successfully got the data.");
                    return response.data;
                }, 
                //Failure
                function (error) {
                });
            };
            AllergiesService.prototype.getAllergyReactionTypes = function () {
                return this.$http.get("api/allergies/valuesets/reactiontypes").then(
                //Success
                function (response) {
                    console.log("Successfully got reaction types.");
                    return response.data;
                }, 
                //Failure
                function (error) {
                });
            };
            AllergiesService.$inject = ["PatientManagerService", "$http"];
            return AllergiesService;
        })();
        services.AllergiesService = AllergiesService;
        angular.module("patient").service("AllergiesService", AllergiesService);
    })(services = patient.services || (patient.services = {}));
})(patient || (patient = {}));
