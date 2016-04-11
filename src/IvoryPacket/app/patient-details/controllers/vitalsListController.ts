module patient.controllers {
    export class VitalsListController {
        static $inject: Array<string> = ["$state", "PatientShellService", "VitalsService"];
        data: Array<any> = [[65, 59, 80, 81, 60, 65, 60]];
        series: Array<string> = ["Series A"];
        labels: Array<any> = ["January", "February", "March", "April", "May", "June", "July"];
        chartOptions = { bezierCurve: false, datasetFill: false };
        heartRateLabels: Array<string> = [];
        heartRateValues: Array<number> = [];
        
        isLoading: boolean = false;

        constructor(private $state: angular.ui.IStateService, private patientShellService: interfaces.patientShellService, private vitalsService: interfaces.vitalsService) {
            this.heartRateLabels = this.vitalsService.getHeartRateLabels();
            this.heartRateValues = this.vitalsService.getHeartRateValues();
            console.log(this.heartRateValues);
            console.log(this.heartRateLabels);
        }

    }
    angular.module("patient").controller("VitalsListController", VitalsListController);
}