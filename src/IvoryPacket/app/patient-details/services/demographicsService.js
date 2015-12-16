var patient;
(function (patient) {
    var services;
    (function (services) {
        var DemographicsService = (function () {
            function DemographicsService() {
            }
            DemographicsService.$inject = [];
            return DemographicsService;
        })();
        services.DemographicsService = DemographicsService;
        angular.module("patient").service("DemographicsService", DemographicsService);
    })(services = patient.services || (patient.services = {}));
})(patient || (patient = {}));
