var patient;
(function (patient) {
    var services;
    (function (services) {
        var AllergiesService = (function () {
            function AllergiesService(patientShellService, $http) {
                this.patientShellService = patientShellService;
                this.$http = $http;
            }
            AllergiesService.prototype.saveAllergy = function (allergy) {
                return this.$http.post("api/allergies", allergy).then(
                //Success
                function () {
                    console.log("Allergy successfully saved to server.");
                }, 
                //Failure
                function () { });
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
            AllergiesService.prototype.getCurrentPatientAllergies = function () {
                this.$http.get("api/allergies").then(function () { });
            };
            AllergiesService.prototype.getPatientAllergyById = function (patientId) {
            };
            AllergiesService.prototype.addPatientAllergy = function (patientId, allergy) {
            };
            AllergiesService.$inject = ["PatientShellService", "$http"];
            return AllergiesService;
        })();
        services.AllergiesService = AllergiesService;
        angular.module("patient").service("AllergiesService", patient.services.AllergiesService);
    })(services = patient.services || (patient.services = {}));
})(patient || (patient = {}));
