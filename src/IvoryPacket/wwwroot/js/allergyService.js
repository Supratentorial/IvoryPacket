var patient;
(function (patient) {
    var services;
    (function (services) {
        var AllergyService = (function () {
            function AllergyService() {
            }
            AllergyService.prototype.getPatientAllergyById = function (patientId) {
            };
            AllergyService.prototype.addPatientAllergy = function (patientId, allergy) {
            };
            AllergyService.$inject = [];
            return AllergyService;
        })();
        services.AllergyService = AllergyService;
        angular.module("patient").service("AllergyService", patient.services.AllergyService);
    })(services = patient.services || (patient.services = {}));
})(patient || (patient = {}));
