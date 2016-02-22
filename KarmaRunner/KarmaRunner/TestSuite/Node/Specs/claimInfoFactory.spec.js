define(['angular', 'angular-mock'], function() {
	 describe('#claims#dental#model -> claimInfoFactory', function() {
		 
		 var appConfig, appUtil;
		 
		  	// executed before each "it" is run.
	        beforeEach(function() {
	            // load the module.
	            module('he');
	        });
	        
	        beforeEach(inject(function() {
	            var $injector = angular.injector(['ngMock', 'ng', 'he']);
	            claimInfoFactory = $injector.get('claimInfoFactory');
	            appConfig = $injector.get('appConfig');
	            appUtil = $injector.get('appUtil');
	        }));

	         var responseMock1 = {
			            "claimData": null,
			            "additionalClaimData": null,
			            "seviceAuth": null,
			            "claimNote": null,
			            "attachment": [{}],
			            "accidentRelatedInformation": null,
			            "serviceAuth": null
	       			 };  

	        it('should create claimInfoFactory', function() {
	            expect(claimInfoFactory).toBeDefined();
	        });

	        it('should have an initClaimInformation function', function() {
	            expect(angular.isFunction(claimInfoFactory.initClaimInformation)).toBe(true);
	        });

	        xit('should have a validateClaimInfo function', function() {
	            var result = claimInfoFactory.initClaimInformation({});
	            expect(angular.isFunction(result.validateClaimInfo)).toBe(true);
	        });

	        it('should have a validateClaimInfo with null objects', function() {
	            var result = claimInfoFactory.initClaimInformation(responseMock1);
	            expect(angular.isFunction(result.validateClaimInfo)).toBe(true);
	        });

	        xit('should have an initAttachments function', function() {
	            expect(angular.isFunction(claimInfoFactory.initAttachments)).toBe(true);
	        });

			it('should have a validateAttachmentInfo function', function() {
	            var result = claimInfoFactory.initAttachments({});
	            expect(angular.isFunction(result.validateAttachmentInfo)).toBe(true);
	        });

			it('should have an attachment function', function() {
	            expect(angular.isFunction(claimInfoFactory.attachment)).toBe(true);
	        });

	  		//this function will be used for validating
	        function validate(claimInfo) {
	            var errorList = [];
	            var screenName = ""
	            claimInfo.validateClaimInfo(screenName, errorList);
	            return errorList;
	        }

     	 	xdescribe('claimInfoFactory Validation', function() {
	        	var claimInfo;

	            beforeEach(function() {   
	                //Mocking the data             
					var responseMock = {
			            "claimData": {
			                "patientAccount": "1223",
			                "serviceDate": "06/25/2015",
			                "placeOfService": "42",
			                "benefitsAssignmentCertification": "N",
			                "assignmentCode": "C",
			                "releaseOfInfo": "Y"
			            },
			            "additionalClaimData": {
			                "applianceDate": "06/25/2015",
			                "delayReasonCode": "10",
			                "specialProgramTypeCode": "05",
			                "predeterminationBenefitIdNumber": "2",
			                "serviceAuthorizationExceptionCode": "1",
			                "patientPaidAmount": "2.00",
			                "repricedClaimNumber": "2",
			                "adjustedRepricedClaim": "d",
			                "repricerReceivedDate": "06/25/2015"
			            },
			            "seviceAuth": {
			                "serviceAuthorization": null,
			                "referral": null
			            },
			            "claimNote": {
			                "note": "Claim notesss"
			            },
			            "attachmentIndicator": true,
			            "attachment": [
			                {
			                    "sequenceNumber": null,
			                    "typeAttachment": "DA",
			                    "deliveryMethod": "EL",
			                    "attachmentControl": "dd",
			                    "typeAttachmentDesc": "Dental Models",
			                    "deliveryMethodDesc": "Electronic Only"
			                }
			            ],
			            "isThisClaimAccidentRelated": true,
			            "accidentRelatedInformation": {
			                "relatedCause1": "AP",
			                "relatedCause2": null,
			                "autoAccidentState": "PP",
			                "autoAccidentCountry": "SSS",
			                "accidentDate": "01/01/1990",
			            },
			            "serviceAuth": {
			                "serviceAuthorization": "s",
			                "referral": "s"
			            }
	       			 };  

	       			claimInfo = claimInfoFactory.initClaimInformation(responseMock);
	            });
				
				// checking with valid values shoud not throw any errors
	            it('shoud verify claimInfoFactory validateClaimInfo fields are not throwing errors', function() {	            	     
	                expect(validate(claimInfo).length).toBe(0);	                
	            });

	            it('shoud verify isThisClaimAccidentRelated value is null', function() {
	            	claimInfo.isThisClaimAccidentRelated = null;                
	                expect(validate(claimInfo)[0]).toBe(appConfig.IS_THIS_ACC_REQ );
	            });

	            it('shoud verify relatedCause1 value is null', function() {
	            	claimInfo.accidentRelatedInformation.relatedCause1 = null;                
	                expect(validate(claimInfo)[0]).toBe(appConfig.DEN_ACC_RCAUSE1 );
	            });

	 			it('shoud test relatedCause1 validations for all conditional fields are throwing errors', function() {
	           		claimInfo.accidentRelatedInformation.autoAccidentCountry = null;  
	            	claimInfo.accidentRelatedInformation.accidentDate = null;
	            	claimInfo.accidentRelatedInformation.autoAccidentState = null;   
	                
	                expect(validate(claimInfo)[0]).toBe(appConfig.DEN_ACC_COUNTY);
	                expect(validate(claimInfo)[1]).toBe(appConfig.DEN_ACC_DATE);
	                expect(validate(claimInfo)[2]).toBe(appConfig.DEN_ACC_STATE);
	            });

	    		it('shoud verify accidentDate value is invalid', function() {
	            	claimInfo.accidentRelatedInformation.accidentDate = '25/23/1998';
	                expect(validate(claimInfo)[0]).toBe(appConfig.DEN_ACC_DATE_INVALID);
	            });

	        	it('shoud verify accidentDate  value is less that equal to current date', function() {
	        		claimInfo.accidentRelatedInformation.accidentDate = '01/01/2016';
	           		expect(validate(claimInfo)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });

	            it('shoud verify serviceDate value is invalid', function() {
	            	claimInfo.claimData.serviceDate = '25/23/1998';
	                expect(validate(claimInfo)[0]).toBe(appConfig.SRVC_DATE + appConfig.DATE_INVALID);
	            });

	        	it('shoud verify serviceDate  value is less that equal to current date', function() {
	        		claimInfo.claimData.serviceDate = '01/01/2016';
	           		expect(validate(claimInfo)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });

	        	it('shoud verify claimData validations for all conditional fields are throwing errors', function() {
	        		claimInfo.claimData.patientAccount = null;
	        		claimInfo.claimData.serviceDate = null;
	        		claimInfo.claimData.placeOfService = null;
	        		claimInfo.claimData.benefitsAssignmentCertification = null;
	        		claimInfo.claimData.assignmentCode = null;
	        		claimInfo.claimData.releaseOfInfo = null;

	           		expect(validate(claimInfo)[0]).toBe(appConfig.PATIENT_ACC );
	           		expect(validate(claimInfo)[1]).toBe(appConfig.PATIENT_SER_DATE);
	           		expect(validate(claimInfo)[2]).toBe(appConfig.PLACE_OF_SRVC);
	           		expect(validate(claimInfo)[3]).toBe(appConfig.BENF_ASGN_CERT);
	           		expect(validate(claimInfo)[4]).toBe(appConfig.ASGN_CODE);
	           		expect(validate(claimInfo)[5]).toBe(appConfig.REL_INFO_CODE);
	            });

 				it('shoud verify applianceDate value is invalid', function() {
	            	claimInfo.additionalClaimData.applianceDate = '25/23/1998';
	                expect(validate(claimInfo)[0]).toBe(appConfig.APPLICATION_DATE + appConfig.DATE_INVALID);
	            });

	        	it('shoud verify applianceDate  value is less that equal to current date', function() {
	        		claimInfo.additionalClaimData.applianceDate = '01/01/2016';
	           		expect(validate(claimInfo)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });

	            it('shoud verify repricerReceivedDate value is invalid', function() {
	            	claimInfo.additionalClaimData.repricerReceivedDate = '25/23/1998';
	                expect(validate(claimInfo)[0]).toBe(appConfig.REPRICE_RCV_DATE + appConfig.DATE_INVALID);
	            });

	        	it('shoud verify repricerReceivedDate  value is less that equal to current date', function() {
	        		claimInfo.additionalClaimData.repricerReceivedDate = '01/01/2016';
	           		expect(validate(claimInfo)[0]).toBe(appConfig.SRVC_BGN_DATE_VLD);
	            });
				describe('claimInfo attachment Validation', function() {
	        	var claimAttachment;

 				beforeEach(function() {
 					claimAttachment = claimInfoFactory.initAttachments(mockeAttachment);
 				})   

				// checking with valid values shoud not throw any errors
	            it('shoud verify attachment validateClaimInfo fields are not throwing errors', function() {	            	     
	                expect(validateAttachement(claimAttachment).length).toBe(0);	                
	            });

	 			it('to test attachment validations for all conditional fields are throwing errors', function() {
	           		claimAttachment.typeAttachment = null;  
	            	claimAttachment.deliveryMethod = null; 
	                
	                expect(validateAttachement(claimAttachment)[0]).toBe(appConfig.ATTACHMENT_TYPEATTACH_REQ);
	                expect(validateAttachement(claimAttachment)[1]).toBe(appConfig.DELIVERY_METHOD_REQ);
	            });
				
			});
       		 });


				var mockeAttachment = {
					"sequenceNumber": "1",
                    "typeAttachment": "DA",
                    "deliveryMethod": "EL",
                    "attachmentControl": "dd",
                    "typeAttachmentDesc": "Dental Models",
                    "deliveryMethodDesc": "Electronic Only"
				}
		  		//this function will be used for validating
		        function validateAttachement(claimAttachment) {
		            var errorList = [];
		            var screenName = ""
		            claimAttachment.validateAttachmentInfo(screenName, errorList);
		            return errorList;
		        }
				

	 });
});