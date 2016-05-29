module settings.services {

    export class UserManagementService {
        static $inject: Array<string> = ["$http"];
        constructor(private $http: angular.IHttpService) {
            
        }

        getAllUsers() {
            return this.$http.get("api/users");
        }

        saveNewUser(newUser: interfaces.user) {
            
        }
    }
    angular.module("settings").service("UserManagementService", UserManagementService);
}