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
        expect(patientManagerService.isOpenPatient(1)).toBe(false);
    });

    it("should return true if there is an new unsaved patient", () => {
        patientManagerService.createNewPatient();
        expect(patientManagerService.isOpenPatient(0)).toBe(true);
    });
});