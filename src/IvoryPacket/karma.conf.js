// Karma configuration
// Generated on Thu Jan 07 2016 19:56:47 GMT+1300 (New Zealand Daylight Time)

module.exports = function (config) {
    config.set({

        // base path that will be used to resolve all patterns (eg. files, exclude)
        basePath: '',

        // frameworks to use
        // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
        frameworks: ['jasmine'],

        // list of files / patterns to load in the browser
        files: [
          "wwwroot/lib/jquery.js",
          "wwwroot/lib/angular.js",
          "wwwroot/lib/angular-mocks.js",
          "wwwroot/lib/angular-sanitize.js",
          "wwwroot/lib/adal.js",
          "wwwroot/lib/adal-angular.js",
          "wwwroot/lib/ng-lodash.js",
          "wwwroot/lib/angular-ui-router.js",
          "wwwroot/lib/bootstrap.js",
          "wwwroot/lib/moment.js",
          "wwwroot/lib/angular-moment.js",
          "wwwroot/js/utilitiesModule.js",
          "wwwroot/js/utilitiesService.js",
          "wwwroot/js/patientModule.js",
          "wwwroot/js/phoneNumberService.js",
          "wwwroot/js/patientSummaryController.js",
          "wwwroot/js/patientManagerService.js",
          "wwwroot/js/patientShellController.js",
          "wwwroot/js/patientListService.js",
          "wwwroot/js/patientListController.js",
          "wwwroot/js/patientDetailService.js",
          "wwwroot/js/modelInterfaces.js",
          "wwwroot/js/investigationsController.js",
          "wwwroot/js/encountersController.js",
          "wwwroot/js/emailService.js",
          "wwwroot/js/demographicsController.js",
          "wwwroot/js/commonModule.js",
          "wwwroot/js/appModule.js",
          "wwwroot/js/allergiesService.js",
          "wwwroot/js/allergiesController.js",
          "app/**/*Spec.js"
        ],

        // list of files to exclude
        exclude: [
        ],


        // preprocess matching files before serving them to the browser
        // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
        preprocessors: {
        },


        // test results reporter to use
        // possible values: 'dots', 'progress'
        // available reporters: https://npmjs.org/browse/keyword/karma-reporter
        reporters: ['progress'],


        // web server port
        port: 9876,


        // enable / disable colors in the output (reporters and logs)
        colors: true,


        // level of logging
        // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
        logLevel: config.LOG_INFO,


        // enable / disable watching file and executing tests whenever any file changes
        autoWatch: true,


        // start these browsers
        // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
        browsers: ['PhantomJS'],


        // Continuous Integration mode
        // if true, Karma captures browsers, runs the tests and exits
        singleRun: false,

        // Concurrency level
        // how many browser should be started simultaneous
        concurrency: Infinity
    })
}