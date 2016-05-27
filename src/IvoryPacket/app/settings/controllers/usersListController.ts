module settings.controllers {
    export class UsersListController {
        static $inject: Array<string> = ["$uibModal"];
        constructor(private $uibModal: angular.ui.bootstrap.IModalService) {

        }
        addNewUser() {
            this.$uibModal.open({
                templateUrl: "html/add-user-modal.html",
                backdrop: "static",
                controllerAs: "vm",
                controller: "AddUserModalController"
            })
        }
    }

    angular.module("settings").controller("UsersListController", UsersListController)
}