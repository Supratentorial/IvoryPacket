﻿/// <reference path="../typings/angular-ui-router/angular-ui-router.d.ts" />
/// <reference path="../typings/angularjs/angular.d.ts" />

module app {
    angular.module("app", ["ui.router", "ui.bootstrap", "patient", "appointment", "utilities", "angularMoment", "chart.js"])
        .config(($stateProvider: angular.ui.IStateProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider, $locationProvider: angular.ILocationProvider, $httpProvider: angular.IHttpProvider) => {
            $urlRouterProvider.when("/", "/dashboard");
            $urlRouterProvider.when("/patients", "/patients/list");
            $urlRouterProvider.when("/patients/detail/{patientId:int}", "/patients/detail/{patientId:int}/summary");
            $urlRouterProvider.when("/patients/detail/{patientId:int}/demographics", "patients/detail/{patientId:int}/demographics/view");
            $stateProvider
                .state("dashboard", <angular.ui.IState>{
                    url: "/dashboard",
                    templateUrl: "html/dashboard.html"
                })
                .state("appointments", <angular.ui.IState>{
                    url: "/appointments",
                    controller: "AppointmentShellController",
                    controllerAs: "shell",
                    templateUrl: "html/appointment-shell.html"
                })
                .state("appointments.month", <angular.ui.IState>{
                    url: "/month",
                    templateUrl: "html/appointment-month-view.html"
                })
                .state("appointments.week", <angular.ui.IState>{
                    url: "/week",
                    templateUrl: "html/appointment-week-view.html"
                })
                .state("appointments.day", <angular.ui.IState>{
                    url: "/day",
                    templateUrl: "html/appointment-day-view.html"
                })
                .state("appointments.details", <angular.ui.IState>{
                    url: "/detail/{appointmentId:int}",
                    templateUrl: "html/appointment-detail-view.html"
                })
                .state("appointments.details.edit", <angular.ui.IState>{
                    url: "/edit",
                    templateUrl: "html/appointment-detail-edit.html"
                })
                .state("appointments.details.view", <angular.ui.IState>{
                    url: "/view",
                    templateUrl: "html/appointment-detail-view"
                })
                .state("patient", <angular.ui.IState>{
                    url: "/patients",
                    template: "<ui-view/>"
                })
                .state("patient.list", <angular.ui.IState>{
                    url: "/list",
                    templateUrl: "html/patient-list.html",
                    controller: "PatientListController",
                    controllerAs: "vm"
                })
                .state("patient.detail", <angular.ui.IState>{
                    url: "/detail/{patientId:int}",
                    templateUrl: "html/patient-shell.html",
                    controller: "PatientShellController",
                    controllerAs: "vm"
                })
                .state("patient.detail.summary", <angular.ui.IState>{
                    url: "/summary",
                    templateUrl: "html/patient-summary.html",
                    controller: "PatientSummaryController as vm"
                })
                .state("patient.detail.social-history-view", <angular.ui.IState>{
                    url: "/social-history/view",
                    templateUrl: "html/social-history-view.html",
                })
                .state("patient.detail.social-history-edit", <angular.ui.IState>{
                    url: "/social-history/edit",
                    templateUrl: "html/social-history-edit.html"
                })
                .state("patient.detail.substance-use-edit", <angular.ui.IState>{
                    url: "/social-history/substance-use/edit",
                    templateUrl: "html/substance-use-edit.html",
                    controller: "SubstanceUseController as vm"
                })
                .state("patient.detail.family-history-edit", <angular.ui.IState>{
                    url: "/social-history/family-history/edit",
                    templateUrl: "html/family-history-edit.html"
                })
                .state("patient.detail.demographics-edit", <angular.ui.IState>{
                    url: "/demographics/edit",
                    templateUrl: "html/demographics-edit.html",
                    controller: "DemographicsController as vm"
                })
                .state("patient.detail.demographics-view", <angular.ui.IState>{
                    url: "/demographics/view",
                    templateUrl: "html/demographics-view.html",
                    controller: "DemographicsController as vm"
                })
                .state("patient.detail.encounters-view", <angular.ui.IState>{
                    url: "/encounters/view",
                    templateUrl: "html/encounters-view.html"
                })
                .state("patient.detail.encounters-edit", <angular.ui.IState>{
                    url: "/encounters/edit",
                    templateUrl: "html/encounters-edit.html"
                })
                .state("patient.detail.scripts-view", <angular.ui.IState>{
                    url: "/scripts/view",
                    templateUrl: "html/scripts-view.html"
                })
                .state("patient.detail.scripts-edit", <angular.ui.IState>{
                    url: "scripts/edit",
                    templateUrl: "html/scripts-edit.html"
                })
                .state("patient.detail.vitals-view", <angular.ui.IState>{
                    url: "/vitals/view",
                    templateUrl: "html/vitals-view.html",
                    controller: "VitalsController as vm"
                })
                .state("patient.detail.vitals-edit", <angular.ui.IState>{
                    url: "/vitals/edit",
                    templateUrl: "html/vitals-edit.html",
                    controller: "VitalsController as vm"
               })
                .state("patient.detail.documents-view", <angular.ui.IState>{
                    url: "documents/view",
                    templateUrl: "html/documents-view.html"
                })
                .state("patient.detail.documents-edit", <angular.ui.IState>{
                    url: "documents/edit",
                    templateUrl: "html/documents-edit.html"
                })
                .state("patient.detail.investigations-view", <angular.ui.IState>{
                    url: "investigations/view",
                    templateUrl: "html/investigations-view.html"
                })
                .state("patient.detail.investigations-edit", <angular.ui.IState>{
                    url: "investigations/edit",
                    templateUrl: "html/investigations-edit.html"
                })
                .state("patient.detail.allergies-view", <angular.ui.IState>{
                    url: "allergies/view",
                    templateUrl: "html/allergies-view.html",
                    controller: "AllergiesListController as vm"
                })
                .state("patient.detail.allergies-edit", <angular.ui.IState>{
                    url: "allergies/{allergyId:int}/edit",
                    templateUrl: "html/allergies-edit.html",
                    controller: "AllergyDetailsController as vm"
                })
                .state("patient.detail.immunisations-view", <angular.ui.IState>{
                    url: "/immunisations/view",
                    templateUrl: "html/immunisations-view.html"
                })
                .state("patient.detail.immunisations-edit", <angular.ui.IState>{
                    url: "/immunisations/edit",
                    templateUrl: "html/immunisations-edit.html"
                })
                .state("patient.detail.medicalhistory-view", <angular.ui.IState>{
                    url: "/medical-history/view",
                    templateUrl: "html/medical-history-view.html"
                })
                .state("patient.detail.medicalhistory.edit", <angular.ui.IState>{
                    url: "/medical-history/edit",
                    templateUrl: "html/medical-history-edit.html"
                })

            $locationProvider.html5Mode(true);
        });
    angular.element(document).ready(() => { angular.bootstrap(document, ["app"]) });
}