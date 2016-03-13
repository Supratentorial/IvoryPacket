"use strict"
describe("patientManagerService", () => {

    var httpBackend: angular.IHttpBackendService;
    var patientManagerService: interfaces.services.patientManagerService;
    beforeEach(angular.mock.module("app"));
    beforeEach(angular.mock.module("patient"));

    beforeEach(inject(function (_patientManagerService_, $httpBackend) {
        patientManagerService = _patientManagerService_;
        httpBackend = $httpBackend;
    }));

    it("should return false if there are no open patients", () => {
        expect(patientManagerService.isPatientOpen(1)).toBe(false);
    });
});