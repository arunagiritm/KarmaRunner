function commonFaked() {

	this.values = [{
		code: '1',
		desc: 'desc1'
	}, {
		code: '2',
		desc: 'desc2'
	}];
	
	this.templates = [
		'src/common/config/languages/en.json',
		'src/common/util/partials/auth.html',
		'src/common/directives/partials/toolbar.html',
		'src/common/util/partials/session.html',
		'src/common/util/partials/postauthmessage.html',
		'src/common/util/partials/error.html',
		'src/common/home/partials/layouts/baseLayout.html',
		'src/common/home/partials/header.html',
		'src/common/home/partials/menu.html',
		'src/common/home/partials/footer.html',
		'src/common/home/partials/login.html',
		'src/common/util/partials/success.html',
		'src/common/home/data/help.json',
		'src/common/newsAndAlerts/partials/newsAndAlert.html',
		'src/provider/providerlogin/partials/provider_info_login.html',
		'src/common/home/data/help.json',
		'data/claimAdminUnitDetails.json',
		'src/provider/enrollment/partials/uploadsuccess.html',
		'src/provider/providerlogin/partials/postLogin.html',
		'src/member/memberLogin/partials/member_info_login.html',
		'src/common/home/partials/askToChangePin.html',
		'src/member/memberLogin/partials/change_pin_member.html',
		'src/member/memberLogin/partials/change_pin_confirmation.html',
		'src/common/util/partials/notifyChangePin.html',
		'src/common/home/partials/new_pin_confirmation.html',
		'src/common/home/partials/forbidden.html'
	];
}

commonFaked.prototype = {
	accordianFaked: function() {

		var errorList = [],
			values = [];

		return {
			register: function(funcName) {

				if(values.indexOf(funcName) === -1) {

					values.push(funcName);
				}
			},
			registerChild: function(name, funcName) {

				if(values.indexOf(funcName) === -1) {

					values.push(funcName);
				}
			},
			validate: function() {

				angular.forEach(values, function(funcName){

					funcName(errorList);
				});
			},
			getAllErrors: function() {

				return errorList;
			},
			clearAll: function() {

				return true;
			},
			getValidationObject: function() {

				return {
					setErrorStatus: function() {

						return true;
					}
				};
			}
		}
	},
	angularCacheFactoryFaked: {
		get: function(data) {

			return {
				get: function(data) {

					if(data === 'loggedinUserType') {

						return 'internal'
					} else if(data === 'checkRefreshBtn') {

						return true;
					}else {
						true;
					}
				},
				put: function() {
					return true;
				}
			};
		},
		put: function() {

			return true;
		}
	},
	angularCopy: function(dataToCopied) {

		return angular.copy(dataToCopied);
	},
	angularEquals: function(src, dest) {

		return angular.equals(src, dest);
	},
	angularFaked: function() {

		var positiveFunc = function() {

			return true;
		};

		return {
			addClass: positiveFunc,
			animate: positiveFunc,
			attr: positiveFunc,
			collapse: positiveFunc,
			hasClass: positiveFunc,
			html: positiveFunc,
			is: positiveFunc,
			parent: function() {

				return {
					removeClass: function() {

						return {
							addClass: positiveFunc
						}
					},
					addClass: positiveFunc,
					remove: positiveFunc
				}
			},
			prev: function() {

				return {
					find: function() {

						return {
							toggleClass: positiveFunc
						};
					}
				};
			},
			removeAttr: positiveFunc,
			removeClass: positiveFunc,
			show: positiveFunc,
			selectpicker: positiveFunc,
			toggleClass: positiveFunc
		}
	},
	commonCacheFactoryFaked: {
		getProvInfo: function() {

			return {
				providerId: '479763'
			}
		},
		getAuthUsername: function() {

			return "479763"
		}
	},
	get: function(data){

		if(data === 'cancelClaim') {

			return true;
		} else if(data === 'searchCriteria') {
			
			return {
				providerId: '479763',
				TCN: '9999999999',
				claimStatus: 'success',
				claimServicePeriodBeginDate: '04/22/1993',
				claimServicePeriodEndDate: '04/22/1993',
				memberID: '123456'
			};
		}
	},
	jqueryFaked: function() {
		
		$.fn.offset = function() {
			return {
				top: 100
			};
		};
	},
	modalInstance: {
		close: jasmine.createSpy('modalInstance.close'),
		dismiss: jasmine.createSpy('modalInstance.dismiss')
	},
	stateGo: function() {

		return true;
	},
	validateErrorMsgs: function(src, dest, appConfig) {

		var i = 0;

		if(angular.isObject(appConfig)) {

			angular.forEach(src, function(error){

				if(dest[i] === 'Please indicate whether or not the member has other insurance') {

					expect(error).toEqual(dest[i++]);
				} else {

					expect(error).toEqual(appConfig[dest[i++]]);
				}
			});
		}
	}
}
