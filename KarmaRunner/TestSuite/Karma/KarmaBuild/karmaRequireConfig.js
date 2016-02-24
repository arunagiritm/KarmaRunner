/**
* @fileoverview
*<p>
* Defines RequireJS configuration file to load all the dependencies
* This is the requirejs config file used by karma
*</p>
* @Your Project Name
* @Date
* @version 1.0
* @author 
*/

/*
Logic to pull all the '.spec' files from the set of all files loaded by karma.
It is very important to load the specs from the initial set, otherwise karma does not know
the identity of the specs and throws 'no timestamp' error
*/

var filesToLoad = ['bootstrap']; //'app' is needed for all the specs, hence adding it as first dependency
for (var file in window.__karma__.files) {
    if (/spec\.js$/.test(file)) {
        filesToLoad.push(file);

    }
};



//Use to point the root directory which is two levels above the current directory
var vendorPathPrefix = "../vendor/";

require.config({
	/*Karma serves files under /base. So, on the server requests to files will
	 be served up under http://localhost:9876/base/*.  */
	baseUrl: '/base/src/common/',
	waitSeconds:0,
	// define library shortcuts
	paths: {
		'angular': vendorPathPrefix + 'angular/angular',
		'angular-animate': vendorPathPrefix + 'angular-animate/angular-animate',
		'angular-aop': vendorPathPrefix + 'angular-aop/angular-aop.min',
		'angular-cache': vendorPathPrefix + 'angular-cache/angular-cache',
		'angular-cookies': vendorPathPrefix + 'angular-cookies/angular-cookies',
		'angular-messages': vendorPathPrefix + 'angular-messages/angular-messages',
		'angular-mock': vendorPathPrefix + 'angular-mocks/angular-mocks',
		'angular-sanitize': vendorPathPrefix + 'angular-sanitize/angular-sanitize',
		'angular-touch': vendorPathPrefix + 'angular-touch/angular-touch',
		'angular-translate': vendorPathPrefix + 'angular-translate/angular-translate',
		'angular-translate-loader-static-files': vendorPathPrefix + 'angular-translate/angular-translate-loader-static-files',
		'angular-translate-loader': vendorPathPrefix + 'angular-translate/angular-translate-loader-url.min',
		'angular-ui-bootstrap': vendorPathPrefix + 'angular-ui-bootstrap-bower/ui-bootstrap-tpls',
		'angularSpinner': vendorPathPrefix + 'spinner/angular-spinner',		
		'bootstrap-ui': vendorPathPrefix + 'bootstrap/bootstrap',
		'bootstrap-datetimepicker': vendorPathPrefix + 'bootstrap/bootstrap-datetimepicker',		
		'bootstrap-select': vendorPathPrefix + 'bootstrap/bootstrap-select',
		'bootstrap-multiselect': vendorPathPrefix + 'bootstrap/bootstrap-multiselect',		
		'bootstrap-fileupload': vendorPathPrefix + 'bootstrap/bootstrap-fileupload',
		'domReady': vendorPathPrefix + 'requirejs-domready/domReady.min',
		'jquery': vendorPathPrefix + 'jquery/jquery',
		'jquery-maskedinput': vendorPathPrefix + 'jquery/jquery.maskedinput.min',
		'jquery-cookie':vendorPathPrefix + 'jquery-cookie/jquery.cookie',
		'jasmine-jquery':vendorPathPrefix + 'jquery/jasmine-jquery',
		'log4javascript': vendorPathPrefix + 'log4javascript/log4javascript',
		'angularAOP': vendorPathPrefix + 'angular-aop/angular-aop.min',
		'moment': vendorPathPrefix + 'bootstrap/moment',
		'bootstrap_css':vendorPathPrefix + 'bootstrap/bootstrap.min',
		'bootstrap-slider':vendorPathPrefix + 'misc/bootstrap-slider',
		'accordionStep':vendorPathPrefix + 'misc/accordionStep',
		'ngDataTable': vendorPathPrefix + 'ngDataTable/ngDataTable',
		'requirejs-domready': vendorPathPrefix + 'requirejs-domready/domReady',
		'restangular': vendorPathPrefix + 'restangular/restangular',
		'spin': vendorPathPrefix + 'spinner/spin',
      	'toastr': vendorPathPrefix + 'toastr/toastr',
		'underscore': vendorPathPrefix + 'underscore/underscore',
		'ui-route': vendorPathPrefix + 'angular-ui-router/angular-ui-router',
		'inputmask': vendorPathPrefix + 'inputmask/jquery.inputmask',
		'dateinputmask': vendorPathPrefix + 'inputmask/jquery.inputmask.date.extensions'
	},


    /**
	* Some libs does not support AMD out of the box.
	* Use Shim to add AMD module behaviour to Non-AMD libraries
	* Remember: only use shim config for non-AMD scripts,
    * i.e scripts that do not already call define(). The shim
    * config will not work correctly if used on AMD scripts, 
	*/
    shim: {
		'angular': {
			//Dependenct script 'jquery' should be loaded before loading 'angular' script
			deps: ['jquery'],
			//Once angular is loaded as AMD, use the global 'angular' as the module value.
			exports: 'angular'
		},
		'angular-animate':{
			deps: ['angular']
		},
		'angular-aop':{
			deps: ['angular']
		},
		'angular-cache': {
			deps: ['angular']
		},
		'angular-cookies': {
			deps: ['angular']
		},
		'angular-messages': {
			deps: ['angular']
		},
		//Test Dependency
		'angular-mock': {
          deps: ['angular']
      	},
		'angular-sanitize': {
			deps: ['angular']
		},
		'angular-touch': {
			deps: ['angular']
		},
		'angular-translate': {
			deps: ['angular']
		},
		'angular-translate-loader-static-files': {
			deps: ['angular', 'angular-translate']
		},		
		'angular-translate-loader': {
			deps: ['angular','angular-translate']
		},
		'angular-ui-bootstrap':{
			deps: ['angular']
		},
		'angularSpinner':{
			deps:['angular','jquery','spin']
		},
		'bootstrap_css':{
			deps: ['jquery']
		},
		'bootstrap-slider':{
			deps: ['jquery']
		},
		'jquery-maskedinput':{
			deps: ['jquery']
		},		
		'jasmine-jquery':{
			deps: ['jquery']
		},		
		'accordionStep':{
			deps: ['jquery']
		},
		'ui-route': {
			deps: ['angular']
		},
		'bootstrap-ui':{
			deps: ['jquery']
		},
		'bootstrap-select':{
			deps: ['jquery']
		},
		'bootstrap-multiselect':{
			deps: ['jquery']
		},
		'log4javascript':{
			exports:'log4javascript'
		},
		'angularAOP':{
			deps: ['angular']
		},		
		'ngDataTable':{
			deps: ['jquery','angular']
		},
		'restangular':{
			deps:['underscore','angular']
		},
		'underscore':{
			exports:'_'
		},
		'inputmask':{
			exports:['inputmask']			
		},
		'dateinputmask':{
			exports:['dateinputmask']			
		},
		'directives':{
			exports:'directives'
		}
		
	},

	 // ask Require.js to load all the test spec files
	deps: filesToLoad,

	// kickoff jasmine tests from karma, once require loading is complete
	callback:window.__karma__.start
});

