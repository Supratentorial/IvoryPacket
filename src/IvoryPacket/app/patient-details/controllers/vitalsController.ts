module patient.controllers {
    export class VitalsController {
        static $inject: Array<string> = ["VitalsService"];
        data: Array<any> = [[65, 59, 80, 81, 56, 55, 40]];
        series: Array<string> = ["Series A"];
        labels: Array<any> = ["January", "February", "March", "April", "May", "June", "July"];
        chartOptions = { bezierCurve: false, datasetFill: false };
        vitalsDTO: interfaces.vitalSignsDTO;

        constructor(private vitalsService: interfaces.vitalsService) {
            this.getPatientVitalSigns();
        }

        getPatientVitalSigns() {
            this.vitalsService.getPatientVitalSigns().then((vitalsDTO) => {
                angular.copy(vitalsDTO, this.vitalsDTO);
            });
        }

        saveVitals() {
            this.vitalsService.saveNewVitalSigns(this.vitalsDTO);
        }

    }
    angular.module("patient").controller("VitalsController", VitalsController);
}