module app {
    "use strict"
    export class NavLinkController {

        static $inject = ["$state"];

        constructor(private $state: angular.ui.IStateService) {

        }

        isActive(viewLocation): boolean {
            var isActive: boolean = false;
            if (this.$state.includes(viewLocation)) {
                isActive = true;
            }
            return isActive;
        }
    }
    angular.module("app").controller("NavLinkController", app.NavLinkController);
}