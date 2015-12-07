var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        var AllergyController = (function () {
            function AllergyController() {
            }
            AllergyController.prototype.construction = function () {
            };
            AllergyController.$inject = [];
            return AllergyController;
        })();
        controllers.AllergyController = AllergyController;
        angular.module("patient").controller("AllergyController", patient.controllers.AllergyController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
