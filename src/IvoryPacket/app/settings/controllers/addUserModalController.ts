module settings.controllers {
    export class AddUserModalController {

        newUser: interfaces.user;
        static $inject: Array<string> = ["$uibModalInstance"];
        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) {

        }

        saveNewUser() {

        }

        cancelAddUser() {
            this.$uibModalInstance.dismiss();
        }
    }
    angular.module("settings").controller("AddUserModalController", AddUserModalController);
}