/**
* @fileoverview
*<p>
* Defines Karma  configuration file to run unit testing using Jasmine and RequireJS
* frameworks
*</p>
* @Your Project Name
* @Date
* @version 1.0
* @author 
*/
//basePath: '../',
var vendorPathPrefix = '{vendorPlaceholder}/';
module.exports = function(config) {
  config.set({

    // base path that will be used to resolve all patterns (eg. files, exclude)
    // refer two folders above because this config is under /test/unit
	//this file will be available under KarmaBuild which is one level deeper to base directory
      basePath: '{basePathPlaceholder}',


    // Karma plugins - adapters for Jasmine testing framework & RequireJS framework
    frameworks: ['jasmine','requirejs'],
    waitSeconds:0,

        // list of files / patterns to load in the browser
        // though these files will be loaded by requirejs, adding and entry here
        // and explicitly marking them as 'included:false' is mandatory for the tests to work
    files: [
        //External Library Files
            {pattern: 'build/unit/CommonFaked.js',included: true}, 
            {pattern: 'build/unit/Jasmine-extn.js',included: true},
            {pattern: 'vendor/jquery/jasmine-jquery.js',included: false}, 
            {pattern: 'vendor/jquery/jquery.js',included: true}, 
            {pattern: 'vendor/angular/angular.js',included: true}, 
            {pattern: 'vendor/angular-animate/angular-animate.js',included: false},
            {pattern: 'vendor/angular-aop/angular-aop.min.js',included: false}, 
            {pattern: 'vendor/angular-cache/angular-cache.js',included: false},
            {pattern: 'vendor/angular-cookies/angular-cookies.js',included: false},
            {pattern: 'vendor/angular-messages/angular-messages.js',included: false},
            {pattern: 'vendor/angular-mocks/angular-mocks.js',included: false},
            {pattern: 'vendor/angular-sanitize/angular-sanitize.js',included: false},
            {pattern: 'vendor/angular-touch/angular-touch.js',included: false},
            {pattern: 'vendor/angular-translate/angular-translate.js',included: false}, 
            {pattern: 'vendor/angular-translate/angular-translate-loader-static-files.js',included: false}, 
            {pattern: 'vendor/angular-translate/angular-translate-loader-url.min.js',included: false}, 
            {pattern: 'vendor/angular-ui-bootstrap-bower/ui-bootstrap-tpls.js',included: false}, 
            {pattern: 'vendor/angular-ui-router/angular-ui-router.js',included: false}, 
            {pattern: 'vendor/spinner/angular-spinner.js',included: false}, 
            {pattern: 'vendor/bootstrap/bootstrap.js',included: false}, 
            {pattern: 'vendor/bootstrap/bootstrap-datetimepicker.js',included: false}, 
            {pattern: 'vendor/bootstrap/bootstrap-select.js',included: false}, 
            {pattern: 'vendor/bootstrap/bootstrap-multiselect.js',included: false}, 
            {pattern: 'vendor/bootstrap/bootstrap-fileupload.js',included: false}, 
            {pattern: 'vendor/bootstrap/moment.js',included: false}, 
            {pattern: 'vendor/requirejs-domready/domReady.min.js',included: false}, 
            {pattern: 'vendor/bootstrap/bootstrap.min.js',included: false}, 
            {pattern: 'vendor/misc/bootstrap-slider.js',included: false}, 
            {pattern: 'vendor/jquery-cookie/jquery.cookie.js',included: false}, 
            {pattern: 'vendor/jquery/jquery.maskedinput.min.js',included: false}, 
            {pattern: 'vendor/misc/accordionStep.js',included: false}, 
            {pattern: 'vendor/log4javascript/log4javascript.js',included: false}, 
            {pattern: 'vendor/angular-aop/angular-aop.min.js',included: false}, 
            {pattern: 'vendor/ngDataTable/ngDataTable.js',included: false}, 
            {pattern: 'vendor/requirejs-domready/domReady.js',included: false}, 
            {pattern: 'vendor/restangular/restangular.js',included: false}, 
            {pattern: 'vendor/spinner/spin.js',included: false}, 
            {pattern: 'vendor/toastr/toastr.js',included: false}, 
            {pattern: 'vendor/underscore/underscore.js',included: false}, 
            {pattern: 'vendor/inputmask/jquery.inputmask.js',included: false}, 
            {pattern: 'vendor/inputmask/jquery.inputmask.date.extensions.js',included: false},
		//Source javascript and html files	
			{pattern: 'src/**/*.js',included: false}, 
			{pattern: 'src/**/*.html',included: true},
        //Test Spec files. 
			{specsPlaceholder} //Do not modify this line
        //configuration files
            //{pattern: 'build/unit/karmaRequireConfig.js',included: true}
             {pattern: '{karmaRequireConfigPlaceholder}',included: true}
        ],

    // list of files to exclude
    // exclude all requirejs config files - to avoid duplicate reference
    exclude: [
                {excludePlaceholder}
    ],

   //Karma plugins to report results in junit xml format and HTML format.
    reporters: ['progress','junit','html','coverage'],

    //Junit XML format
    junitReporter: {
    //   suite: 'unit',
        outputFile: '{junitReporterPlaceholder}' //Do not modify this line
    },
    // HTML format
    htmlReporter: {
        outputFile: '{htmlReporterPlaceholder}' //Do not modify this line
    },

    // Karma web server(using nodejs socket IO ) default port
    port: 9876,

    // enable / disable colors in the output (reporters and logs)
    colors: true,

    // level of logging
    // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
    logLevel: config.LOG_ERROR,


    // Karma plugins for multile browers launcher
   // temporarily disable due to some issue with opera browser
    browsers: ['Chrome'],
    // browsers: ['Chrome','PhantomJS','Firefox','IE'],

    browserDisconnectTimeout : 2000,
    browserNoActivityTimeout: 100000,
   

    preprocessors: {
      'src/**/*.js': ['coverage'],
      'src/**/*.html': ['ng-html2js']
    },
    ngHtml2JsPreprocessor: {
      //stripPrefix : /WebContent\//, //stripPrefix does not work
      moduleName: 'templates',
      cacheIdFromPath: function(filepath) {
        //Templates for directives have urls starting with /WebContent/partials
        //Whereas templates for router have urls starting with partials/..
        if( !filepath.match(/directives/)) {
          //If the url is not from directive templates, remove WebContent/ from all other urls
          filepath = filepath.replace('src/', '');
        } else {
          //Else prefix /
          filepath = '/' + filepath;
        }
        return filepath;
      }
    },

    coverageReporter: {
      reporters: [
        { type : 'cobertura', dir:'{coberturaPlaceholder}'}, //Do not modify this line
        { type : 'lcov', dir:'{lcovPlaceholder}'}      //Do not modify this line
      ]

    },

    // If browser does not capture in given timeout [ms], kill it
    captureTimeout: 200000,

    // if true, Karma runs the tests once and exits
    singleRun: true,

    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: false,

    // report which specs are slower than 500ms
    reportSlowerThan: 500,

    // required plugins to run unit testing using Karma & jasmin
    plugins: [
      'karma-jasmine',
      'karma-requirejs',
      'karma-junit-reporter',
      'karma-commonjs',
      'karma-coverage',
      'karma-ng-html2js-preprocessor',
      'karma-chrome-launcher',
      'karma-firefox-launcher',
      'karma-safari-launcher',
      'karma-ie-launcher',
      'karma-opera-launcher',
      'karma-phantomjs-launcher',
      'karma-htmlfile-reporter'
    ]

  });
};
