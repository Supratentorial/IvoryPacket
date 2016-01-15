/// <reference path="../typings/angular-ui-router/angular-ui-router.d.ts" />
/// <reference path="../typings/angularjs/angular.d.ts" />

module app {
    angular.module("app", ["ui.router", "patient", "utilities", "angularMoment", "angular-loading-bar"]).config(($stateProvider: angular.ui.IStateProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider, $locationProvider: angular.ILocationProvider, $httpProvider: angular.IHttpProvider) => {
        $urlRouterProvider.when("/", "/");
        $urlRouterProvider.when("patients/detail/{patientId:int}/demographics", "patients/detail/{patientId:int}/demographics/view");
        $stateProvider
            .state("dashboard", <angular.ui.IState>{
                url: "/dashboard",
                temlateUrl: "html/dashboard.html"
            })
            .state("appointments", <angular.ui.IState>{
                url: "/appointments",
                abstract: true,
                templateUrl: "<ui-view/>"
            })
            .state("appointments.list", <angular.ui.IState>{
                url: "/list",
                templateUrl: "html/appointments-list.html"
            })
            .state("patient", <angular.ui.IState>{
                url: "/patients",
                template: "<ui-view/>",
                abstract: true
            })
            .state("patient.list", <angular.ui.IState>{
                url: "/list",
                templateUrl: "html/patient-list.html",
                controller: "PatientListController as vm"
            })
            .state("patient.detail", <angular.ui.IState>{
                url: "/detail/{patientId:int}",
                templateUrl: "html/patient-shell.html",
                controller: "PatientShellController as vm"
            })
            .state("patient.detail.summary", <angular.ui.IState>{
                url: "/summary",
                templateUrl: "html/patient-summary.html",
                controller: "PatientSummaryController as vm"
            })
            .state("patient.detail.socialhistory", <angular.ui.IState>{
                url: "/social-history",
                abstract: true,
                templateUrl: "html/social-history-view.html"
            })
            .state("patient.detail.socialhistory.view", <angular.ui.IState>{
                url: "/view",
                templateUrl: "html/social-history-view.html"
            })
            .state("patient.detail.demographics", <angular.ui.IState>{
                url: "/demographics",
                abstract: true,
                template: "<ui-view/>"
            })
            .state("patient.detail.demographics.edit", <angular.ui.IState>{
                url: "/edit",
                templateUrl: "html/demographics-edit.html",
                controller: "DemographicsController as vm"
            })
            .state("patient.detail.demographics.view", <angular.ui.IState>{
                url: "",
                templateUrl: "html/demographics-view.html",
                controller: "DemographicsController as vm"

            })
            .state("patient.detail.encounters", <angular.ui.IState>{
                url: "/encounters",
                abstract: true,
                template: "<ui-view/>"
            })
            .state("patient.detail.encounters.view", <angular.ui.IState>{
                url: "/view",
                templateUrl: "html/encounters-view.html"
            })
            .state("patient.detail.encounters.edit", <angular.ui.IState>{
                url: "/edit",
                templateUrl: "html/encounters-edit.html"
            })
            .state("patient.detail.documents", <angular.ui.IState>{
                url: "/documents",
                abstract: true,
                template: "<ui-view/>"
            })
            .state("patient.detail.documents.view", <angular.ui.IState>{
                url: "/view",
                templateUrl: "html/documents-view.html"
            })
            .state("patient.detail.documents.edit", <angular.ui.IState>{
                url: "/edit",
                templateUrl: "html/documents-edit.html"
            })
            .state("patient.detail.investigations", <angular.ui.IState>{
                url: "/investigations",
                abstract: true,
                template: "<ui-view/>"
            })
            .state("patient.detail.investigations.view", <angular.ui.IState>{
                url: "/view",
                templateUrl: "html/investigations-view.html"
            })
            .state("patient.detail.investigations.edit", <angular.ui.IState>{
                url: "/edit",
                templateUrl: "html/investigations-edit.html"
            })
            .state("patient.detail.allergies", <angular.ui.IState>{
                url: "/allergies",
                abstract: true,
                template: "<ui-view/>"
            })
            .state("patient.detail.allergies.view", <angular.ui.IState>{
                url: "/view",
                templateUrl: "html/allergies-view.html",
                controller: "AllergiesController as vm"
            })
            .state("patient.detail.allergies.edit", <angular.ui.IState>{
                url: "/edit",
                templateUrl: "html/allergies-edit.html",
                controller: "AllergiesController as vm"
            })
            .state("patient.detail.immunisations", <angular.ui.IState>{
                url: "/immunisations",
                abstract: true,
                template: "<ui-view/>"
            })
            .state("patient.detail.immunisations.view", <angular.ui.IState>{
                url: "/view",
                templateUrl: "html/immunisations-view.html"
            })
            .state("patient.detail.immunisations.edit", <angular.ui.IState>{
                url: "/edit",
                templateUrl: "html/immunisations-edit.html"
            })
            .state("patient.detail.medicalhistory", <angular.ui.IState>{
                url: "/medical-history",
                template: "<ui-view/>",
                abstract: true
            })
            .state("patient.detail.medicalhistory.view", <angular.ui.IState>{
                url: "/view",
                templateUrl: "html/medical-history-view.html"
            })
            .state("patient.detail.medicalhistory.edit", <angular.ui.IState>{
                url: "/edit",
                templateUrl: "html/medical-history-edit.html"
            })

        $locationProvider.html5Mode(true);
    });
    angular.element(document).ready(() => { angular.bootstrap(document, ["app"]) });
}