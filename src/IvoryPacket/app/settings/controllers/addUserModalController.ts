module settings.controllers {
    export class AddUserModalController {
        static $inject: Array<string> = ["$uibModalInstance"];
        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) {

        }

        cancelAddUser() {
            this.$uibModalInstance.dismiss();
        }
    }
    angular.module("settings").controller("AddUserModalController", AddUserModalController);
}