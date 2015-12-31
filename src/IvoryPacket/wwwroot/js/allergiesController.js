var patient;
(function (patient) {
    var controllers;
    (function (controllers) {
        var AllergiesController = (function () {
            function AllergiesController(allergiesService) {
                this.allergiesService = allergiesService;
                this.allergySeverityOptions = [];
                this.allergyReactionTypes = [];
                this.currentAllergy = {
                    allergyId: 0,
                    note: "",
                    type: "",
                    severity: "",
                    substance: "",
                    recordedDate: null,
                    clinicalManifestation: ""
                };
                this.getAllergySeverityOptions();
                this.getAllergyReactionTypes();
            }
            AllergiesController.prototype.getAllergySeverityOptions = function () {
                var _this = this;
                this.allergiesService.getAllergySeverityOptions().then(function (data) {
                    angular.copy(data, _this.allergySeverityOptions);
                });
            };
            AllergiesController.prototype.getAllergyReactionTypes = function () {
                var _this = this;
                this.allergiesService.getAllergyReactionTypes().then(function (data) {
                    angular.copy(data, _this.allergyReactionTypes);
                });
            };
            AllergiesController.prototype.saveAllergy = function () {
                this.allergiesService.addAllergy(this.currentAllergy);
            };
            AllergiesController.$inject = ["AllergiesService"];
            return AllergiesController;
        })();
        controllers.AllergiesController = AllergiesController;
        angular.module("patient").controller("AllergiesController", AllergiesController);
    })(controllers = patient.controllers || (patient.controllers = {}));
})(patient || (patient = {}));
