/// <reference path="../typings/angular-material/angular-material.d.ts" />
/// <reference path="../typings/angular-ui-router/angular-ui-router.d.ts" />
/// <reference path="../typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    angular.module("app", ["ui.router", "patient", "ngMaterial"]).config(function ($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider, $mdThemingProvider) {
        $urlRouterProvider.when("/", "/");
        $stateProvider
            .state("patient", {
            url: "/patients",
            template: "<ui-view/>",
            abstract: true
        })
            .state("patient.list", {
            url: "/list",
            templateUrl: "html/patient-list.html",
            controller: "PatientListController as vm"
        })
            .state("patient.detail", {
            url: "/detail/{patientId:int}",
            templateUrl: "html/patient-shell.html"
        })
            .state("patient.detail.summary", {
            url: "/summary",
            templateUrl: "html/patient-summary.html",
            controller: "PatientSummaryController as vm"
        })
            .state("patient.detail.socialhistory", {
            url: "/social-history",
            abstract: true,
            templateUrl: "html/social-history-view.html"
        })
            .state("patient.detail.socialhistory.view", {
            url: "/view",
            templateUrl: "html/social-history-view.html"
        })
            .state("patient.detail.demographics", {
            url: "/demographics",
            abstract: true,
            template: "<ui-view/>"
        })
            .state("patient.detail.demographics.edit", {
            url: "/edit",
            templateUrl: "html/demographics-edit.html",
            controller: "DemographicsController as vm"
        })
            .state("patient.detail.demographics.view", {
            url: "/view",
            templateUrl: "html/demographics-view.html"
        })
            .state("patient.detail.encounters", {
            url: "/encounters",
            abstract: true,
            template: "<ui-view/>"
        })
            .state("patient.detail.encounters.view", {
            url: "/view",
            templateUrl: "html/encounters-view.html"
        })
            .state("patient.detail.encounters.edit", {
            url: "/edit",
            templateUrl: "html/encounters-edit.html"
        })
            .state("patient.detail.documents", {
            url: "/documents",
            abstract: true,
            template: "<ui-view/>"
        })
            .state("patient.detail.documents.view", {
            url: "/view",
            templateUrl: "html/documents-view.html"
        })
            .state("patient.detail.documents.edit", {
            url: "/edit",
            templateUrl: "html/documents-edit.html"
        })
            .state("patient.detail.pathology", {
            url: "/pathology",
            abstract: true,
            template: "<ui-view/>"
        })
            .state("patient.detail.pathology.view", {
            url: "/view",
            templateUrl: "html/pathology-view.html"
        })
            .state("patient.detail.pathology.edit", {
            url: "/edit",
            templateUrl: "html/pathology-edit.html"
        })
            .state("patient.detail.allergies", {
            url: "/allergies",
            abstract: true,
            template: "<ui-view/>"
        })
            .state("patient.detail.allergies.view", {
            url: "/view",
            templateUrl: "html/allergies-view.html",
            controller: "AllergyController as vm"
        })
            .state("patient.detail.allergies.edit", {
            url: "/edit",
            templateUrl: "html/allergies-edit.html"
        })
            .state("patient.detail.immunisations", {
            url: "/immunisations",
            abstract: true,
            template: "<ui-view/>"
        })
            .state("patient.detail.immunisations.view", {
            url: "/view",
            templateUrl: "html/immunisations-view.html"
        })
            .state("patient.detail.immunisations.edit", {
            url: "/edit",
            templateUrl: "html/immunisations-edit.html"
        })
            .state("patient.detail.medicalhistory", {
            url: "/medical-history",
            template: "<ui-view/>",
            abstract: true
        })
            .state("patient.detail.medicalhistory.view", {
            url: "/view",
            templateUrl: "html/medical-history-view.html"
        })
            .state("patient.detail.medicalhistory.edit", {
            url: "/edit",
            templateUrl: "html/medical-history-edit.html"
        });
        $locationProvider.html5Mode(true);
        $mdThemingProvider.theme("default").primaryPalette("blue-grey", {
            "default": "800"
        });
    });
    angular.element(document).ready(function () { angular.bootstrap(document, ["app"]); });
})(app || (app = {}));
