var app;
(function (app) {
    "use strict";
    var NavLinkController = (function () {
        function NavLinkController($state) {
            this.$state = $state;
        }
        NavLinkController.prototype.isActive = function (viewLocation) {
            var isActive = false;
            if (this.$state.includes(viewLocation)) {
                isActive = true;
            }
            return isActive;
        };
        NavLinkController.$inject = ["$state"];
        return NavLinkController;
    })();
    app.NavLinkController = NavLinkController;
    angular.module("app").controller("NavLinkController", app.NavLinkController);
})(app || (app = {}));
