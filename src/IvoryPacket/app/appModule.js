var app;
(function (app) {
    angular.module("app", ["ui.router", "ui.bootstrap", "patient", "appointment", "utilities", "common", "settings"])
        .config(function ($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
        $urlRouterProvider.when("/", "/dashboard");
        $urlRouterProvider.when("/patients", "/patients/list");
        $urlRouterProvider.when("/patients/detail/{patientId:int}", "/patients/detail/{patientId:int}/summary");
        $urlRouterProvider.when("/patients/detail/{patientId:int}/demographics", "patients/detail/{patientId:int}/demographics/view");
        $stateProvider
            .state("dashboard", {
            url: "/dashboard",
            templateUrl: "html/dashboard.html"
        })
            .state("appointments", {
            url: "/appointments",
            controller: "AppointmentShellController",
            controllerAs: "shell",
            templateUrl: "html/appointment-shell.html"
        })
            .state("appointments.month", {
            url: "/month",
            templateUrl: "html/appointment-month-view.html"
        })
            .state("appointments.week", {
            url: "/week",
            templateUrl: "html/appointment-week-view.html"
        })
            .state("appointments.day", {
            url: "/day",
            templateUrl: "html/appointment-day-view.html"
        })
            .state("appointments.details", {
            url: "/detail/{appointmentId:int}",
            templateUrl: "html/appointment-detail-view.html"
        })
            .state("appointments.details.edit", {
            url: "/edit",
            templateUrl: "html/appointment-detail-edit.html"
        })
            .state("appointments.details.view", {
            url: "/view",
            templateUrl: "html/appointment-detail-view"
        })
            .state("patient", {
            url: "/patients",
            template: "<ui-view/>"
        })
            .state("patient.list", {
            url: "/list",
            templateUrl: "html/patient-list.html",
            controller: "PatientListController",
            controllerAs: "vm"
        })
            .state("patient.detail", {
            url: "/detail/{patientId:int}",
            templateUrl: "html/patient-shell.html",
            controller: "PatientShellController",
            controllerAs: "vm"
        })
            .state("patient.detail.summary", {
            url: "/summary",
            templateUrl: "html/patient-summary.html",
            controller: "PatientSummaryController as vm"
        })
            .state("patient.detail.social-history-view", {
            url: "/social-history/view",
            templateUrl: "html/social-history-view.html",
        })
            .state("patient.detail.social-history-edit", {
            url: "/social-history/edit",
            templateUrl: "html/social-history-edit.html",
            controller: "SocialHistoryController as vm"
        })
            .state("patient.detail.substance-use-edit", {
            url: "/social-history/substance-use/edit",
            templateUrl: "html/substance-use-edit.html",
            controller: "SubstanceUseController as vm"
        })
            .state("patient.detail.family-history-edit", {
            url: "/social-history/family-history/edit",
            templateUrl: "html/family-history-edit.html"
        })
            .state("patient.detail.demographics-edit", {
            url: "/demographics/edit",
            templateUrl: "html/demographics-edit.html",
            controller: "DemographicsController as vm"
        })
            .state("patient.detail.demographics-view", {
            url: "/demographics/view",
            templateUrl: "html/demographics-view.html",
            controller: "DemographicsController as vm"
        })
            .state("patient.detail.encounters-view", {
            url: "/encounters/view",
            templateUrl: "html/encounters-view.html"
        })
            .state("patient.detail.encounters-edit", {
            url: "/encounters/edit",
            templateUrl: "html/encounters-edit.html"
        })
            .state("patient.detail.scripts-view", {
            url: "/scripts/view",
            templateUrl: "html/scripts-view.html"
        })
            .state("patient.detail.scripts-edit", {
            url: "scripts/edit",
            templateUrl: "html/scripts-edit.html"
        })
            .state("patient.detail.vitals-view", {
            url: "/vitals/view",
            templateUrl: "html/vitals-view.html",
            controller: "VitalsListController as vm"
        })
            .state("patient.detail.vitals-edit", {
            url: "/vitals/{vitalsId:int}/edit",
            templateUrl: "html/vitals-edit.html",
            controller: "VitalsDetailController as vm"
        })
            .state("patient.detail.documents-view", {
            url: "documents/view",
            templateUrl: "html/documents-view.html"
        })
            .state("patient.detail.documents-edit", {
            url: "documents/edit",
            templateUrl: "html/documents-edit.html"
        })
            .state("patient.detail.investigations-view", {
            url: "investigations/view",
            templateUrl: "html/investigations-view.html"
        })
            .state("patient.detail.investigations-edit", {
            url: "investigations/edit",
            templateUrl: "html/investigations-edit.html"
        })
            .state("patient.detail.allergies-view", {
            url: "allergies/view",
            templateUrl: "html/allergies-view.html",
            controller: "AllergiesListController as vm"
        })
            .state("patient.detail.allergies-edit", {
            url: "allergies/{allergyId:int}/edit",
            templateUrl: "html/allergies-edit.html",
            controller: "AllergyDetailsController as vm"
        })
            .state("patient.detail.immunisations-view", {
            url: "/immunisations/view",
            templateUrl: "html/immunisations-view.html"
        })
            .state("patient.detail.immunisations-edit", {
            url: "/immunisations/edit",
            templateUrl: "html/immunisations-edit.html"
        })
            .state("patient.detail.medicalhistory-view", {
            url: "/medical-history/view",
            templateUrl: "html/medical-history-view.html"
        })
            .state("patient.detail.medicalhistory.edit", {
            url: "/medical-history/edit",
            templateUrl: "html/medical-history-edit.html"
        })
            .state("settings", {
            url: "/settings",
            templateUrl: "html/settings-shell.html",
            controller: "SettingsShellController",
            controllerAs: "vm"
        })
            .state("settings.users", {
            url: "/users",
            templateUrl: "html/users-list.html",
            controller: "UsersListController",
            controllerAs: "vm"
        });
        $locationProvider.html5Mode(true);
    });
    angular.element(document).ready(function () { angular.bootstrap(document, ["app"]); });
})(app || (app = {}));
