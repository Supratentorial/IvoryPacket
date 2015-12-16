var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        var EncountersController = (function () {
            function EncountersController() {
            }
            return EncountersController;
        })();
        controllers.EncountersController = EncountersController;
        angular.module("patient").controller("EncountersController", patient.controllers.EncountersController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
