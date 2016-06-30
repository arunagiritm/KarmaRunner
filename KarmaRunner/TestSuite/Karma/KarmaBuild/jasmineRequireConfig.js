/**
* @fileoverview
*<p>
* Defines RequireJS configuration file to load all the dependencies
*  <ul>
*   <li> Loads all the angularjs core libraries,3rd party libraries and its dependencies 
*   <li> Use shim to add AMD module behaviour to Non-AMD libraries
*   <li> Initialize & kick starts the angular application.
* </ul>
*</p>
* @Your Project Name
* @Date
* @version 1.0
* @author 
*/


//Use to point the root directory which is one levels above the current directory
var vendorPathPrefix = "{vendor}/";

require.config({

	/* Define cache buster that is used to To invalidate the browser cache whenever 
	   new version is released .It forces the browser to fetch latest files from the
	   server instead of cache */
    urlArgs: 'bust=@Revision@',
    baseUrl: '{baseUrl}/',

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
		'ui-route': {
			deps: ['angular']
		},
		'bootstrap-ui':{
			deps: ['jquery']
		},
		'bootstrap-datetimepicker':{
			deps: ['jquery', 'moment']	
		},
		'bootstrap-select':{
			deps: ['jquery']
		},
		'bootstrap-multiselect':{
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


	// DO NOT load the bootstrap.js - angular mock has issues with ui-router
	// Load the app instead
	//deps: [
	//	'./bootstrap'
	//]
});
