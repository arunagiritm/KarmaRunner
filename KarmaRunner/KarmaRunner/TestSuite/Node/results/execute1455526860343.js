var jasmineSuite = [];
var jasmineSpec = {};
var jid=1 ;
var jpid = 0;
var jids = { jid: 0, jpid: 1 };
var jpidarr = [];


function define(functionarr,callback)
{
	callback();
}

//dummy methods for jasmine
 function describe(functionName, callback) {
    var fname = functionName.replace(/'/g, '"');
	var jsuite={
		Id:jid,
		Node:fname,
		ParentId:jpid,
		Type:"Suite",
		Active:true
	}
	jasmineSuite.push(jsuite);
    jpidarr.push(jpid);
    //console.log("Describe : " + functionName + " Id : " + jid + " Parent Id : " + jpid);
    jpid = jid;
   jid++;
    callback();
    jpid = jpidarr.pop();
}
function xdescribe(functionName, callback) {
    var jsuite={
		Id:jid,
		Node:functionName.replace(/'/g, '"'),
		ParentId:jpid,
		Type:"Suite",
		Active:false
	}
	jasmineSuite.push(jsuite);
    jpidarr.push(jpid);
    //console.log("xDescribe : " + functionName + " Id : " + jid + " Parent Id : " + jpid);
    jpid = jid;
   jid++;
    callback();
    jpid = jpidarr.pop();
}

function it(functionName, callback) {
	var jsuite={
		Id:jid,
		Node:functionName.replace(/'/g, '"'),
		ParentId:jpid,
		Type:"Spec",
		Active:true
	}
	jasmineSuite.push(jsuite);
    //console.log("---Spec : " + functionName + functionName + " Id : " + jid + " Parent Id : " + jpid);
	jid++;
}function xit(functionName, callback) {
	var jsuite={
		Id:jid,
		Node:functionName.replace(/'/g, '"'),
		ParentId:jpid,
		Type:"Spec",
		Active:false
	}
	jasmineSuite.push(jsuite);
    //console.log("---xSpec : " + functionName + functionName + " Id : " + jid + " Parent Id : " + jpid);
	jid++;
}
function beforeEach(fn) {};
function afterEach(fn){};
function beforeAll(fn){};
function afterAll(fn){};
function expect(fn){};
function inject(callback){};
//function module(fn){};
function exdefine(a,b){};
module.exports = {
        jids:jids,
        jid:jid,
        jpid:jpid,
		jasmineSuite:jasmineSuite,
		exdefine:exdefine
		 
}
 
function exdefine(a,b){
jid=a || 1;
jpid=b || 0;
define(['angular', 'angular-mock'], function() {
	
	 describe('#claims#dental#model -> basicLineFactory', function() {
		 
		 var appConfig, appUtil;
		 
		  	// executed before each "it" is run.
	        beforeEach(function() {
	            // load the module.
	            module('he');
	        });
	        
	        beforeEach(inject(function() {
	            var $injector = angular.injector(['ngMock', 'ng', 'he']);
	            basicLineFactory = $injector.get('basicLineFactory');
	            appConfig = $injector.get('appConfig');
	            appUtil = $injector.get('appUtil');
	        }));
	        
	        //Mocking the data
	        var responseMock = {
                
                    "procedureCode": "PC123",
                    "sequenceNumber": 1,
                    "lineSpecificInfoIndicator": true,
                    "diagnosisPointers": {
                        "diagnosisPointer1": null,
                        "diagnosisPointer2": null,
                        "diagnosisPointer3": null,
                        "diagnosisPointer4": null,
                        "procedureDescription": "PD",
                        "lineItemChargeAmount": "12.00",
                        "placeOfService": "24"
                    },
                    "modifiers": {
                        "modifier1": "M1",
                        "modifier2": "M2",
                        "modifier3": "M3",
                        "modifier4": "M4"
                    },
                    "oralCavityDesignation": {
                        "oralCavityDesignation1": "d",
                        "oralCavityDesignation2": "d",
                        "oralCavityDesignation3": "d",
                        "oralCavityDesignation4": "d",
                        "oralCavityDesignation5": "d",
                        "procedureCount": "22",
                        "serviceDate": "06/25/2015",
                        "orthodonticBandingDate": "06/25/2015"
                    },
                    "serviceAuthorization": {
                        "serviceAuthorization": "ssd",
                        "referral": null
                    },
                    "additionalServiceLineInformation": {
                        "replacementDate": "06/25/2015",
                        "priorPlacementDate": "06/25/2015",
                        "lineItemControlNumber": "1",
                        "prosthesisCrown": "I",
                        "salesTaxAmount": "1.00",
                        "treatmentStartDate": "06/25/2015",
                        "treatmentCompletionDate": "06/25/2015"
                    },
                    "toothInformation": [
                        {
                            "toothNumber": "11",
                            "toothSurface1": "B",
                            "toothSurface2": "B",
                            "toothSurface3": "B",
                            "toothSurface4": "B",
                            "toothSurface5": "B",
                            "toothSurface1Desc": "Buccal",
                            "toothSurface2Desc": "Buccal",
                            "toothSurface3Desc": "Buccal",
                            "toothSurface4Desc": "Buccal",
                            "toothSurface5Desc": "Buccal"
                        }
                    ],
                    "otherServiceInformation": {}
            };


             var responseMock1 = {
                    "diagnosisPointers": null,
                    "modifiers": null,
                    "oralCavityDesignation": null,
                    "serviceAuthorization": null,
                    "additionalServiceLineInformation": null,
                    "otherServiceInformation": null
            };
	        
	        
	        it('should create basicLineFactory', function() {
	            expect(basicLineFactory).toBeDefined();
	        });

	        it('should have an initServiceLineItem function', function() {
	            expect(angular.isFunction(basicLineFactory.initServiceLineItem)).toBe(true);
	        });

	        it('should have a validateLineItem function', function() {
	            var result = basicLineFactory.initServiceLineItem({});
	            expect(angular.isFunction(result.validateLineItem)).toBe(true);
	        });

	        it('should verify otherClaimFactory with null objects', function() {
	            var result = basicLineFactory.initServiceLineItem(responseMock1);
	            expect(angular.isFunction(result)).toBe(false);
	        });
	        
	        it('should have an initBasicLineItemInformation function', function() {
	            expect(angular.isFunction(basicLineFactory.initBasicLineItemInformation)).toBe(true);
	        });
	        
	        it('should have an addServiceLineItemData function', function() {
	            expect(angular.isFunction(basicLineFactory.addServiceLineItemData)).toBe(true);
	        });

	  		//this function will be used for validating
	        function validate(lineItem) {
	            var errorList = [];
	            var screenName = "";
	            lineItem.validateLineItem(screenName, errorList);
	            return errorList;
	        }

	        describe('basicLineFactory Validation', function() {
	        	var lineItem;

	            beforeEach(function() {                
	            	lineItem = basicLineFactory.initServiceLineItem(responseMock);
	            });

	            it('verify lineItem validation fields are not throwing errors', function() {	            	     
	                expect(validate(lineItem).length).toBe(0);	                
	            });
				
				it('verify treatmentCompletionDate value is invalid', function() {
	            	lineItem.additionalServiceLineInformation.treatmentCompletionDate = '25/23/1998';
	                expect(validate(lineItem)[0]).toBe(appConfig.TREATMENT_COMPLETE_DATE_INVALID);
	            });
	            
	            it('verify treatmentCompletionDate value is less that equal to current date', function() {
	            	lineItem.additionalServiceLineInformation.treatmentCompletionDate = '01/01/2016';
	                expect(validate(lineItem)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });

				it('verify treatmentStartDate value is invalid', function() {
	            	lineItem.additionalServiceLineInformation.treatmentStartDate = '25/23/1998';
	                expect(validate(lineItem)[0]).toBe(appConfig.TREATMENT_DATE_INVALID);
	            });
	            
	            it('verify treatmentStartDate value is less that equal to current date', function() {
	            	lineItem.additionalServiceLineInformation.treatmentStartDate = '01/01/2016';
	                expect(validate(lineItem)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });

				it('verify priorPlacementDate value is invalid', function() {
	            	lineItem.additionalServiceLineInformation.priorPlacementDate = '25/23/1998';
	                expect(validate(lineItem)[0]).toBe(appConfig.PRIOR_DATE_INVALID);
	            });
	            
	            it('verify priorPlacementDate value is less that equal to current date', function() {
	            	lineItem.additionalServiceLineInformation.priorPlacementDate = '01/01/2016';
	                expect(validate(lineItem)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });
	
 				it('verify replacementDate value is invalid', function() {
	            	lineItem.additionalServiceLineInformation.replacementDate  = '25/23/1998';
	                expect(validate(lineItem)[0]).toBe(appConfig.REPLACE_DATE_INVALID);
	            });
	            
	            it('verify replacementDate value is less that equal to current date', function() {
	            	lineItem.additionalServiceLineInformation.replacementDate  = '01/01/2016';
	                expect(validate(lineItem)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });

	            it('verify serviceDate value is invalid', function() {
	            	lineItem.oralCavityDesignation.serviceDate  = '25/23/1998';
	                expect(validate(lineItem)[0]).toBe(appConfig.SERVICE_DATE_INVALID);
	            });
	            
	            it('verify serviceDate value is less that equal to current date', function() {
	            	lineItem.oralCavityDesignation.serviceDate  = '01/01/2016';
	                expect(validate(lineItem)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });

	         
	            it('verify orthodonticBandingDate value is invalid', function() {
	            	lineItem.oralCavityDesignation.orthodonticBandingDate = '25/23/1998';
	                expect(validate(lineItem)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });
	            
	            it('verify orthodonticBandingDate value is less that equal to current date', function() {
	            	lineItem.oralCavityDesignation.orthodonticBandingDate = '01/01/2016';
	                expect(validate(lineItem)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });

	            it('verify lineItem validation fields are throwing errors', function() {
	            	lineItem.procedureCode = null;  
	            	lineItem.diagnosisPointers.lineItemChargeAmount = null;               
	                expect(validate(lineItem)[0]).toBe(appConfig.PROCEDURE_CODE_REQ);
	                expect(validate(lineItem)[1]).toBe(appConfig.SRVC_LN_IT_REQ);
	            });


	        });

	 });
});};