var jasmineSuite = [];
var jasmineSpec = {};
var jid=1 ;
var jpid = 0;
var jids = { jid: 0, jpid: 1 };
var jpidarr = [];
var jasmine = {};



//window.onerror(function (e) { e.preventDefault(); });
//process.on('uncaughtException', function (exception) {});
function jasmineExtn() {
    this.readJson = function () { };
}

jasmine.createSpy = function (a) { };


function define(functionarr, callback)
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
    jids.jid = jid;
    jids.jpid = jpid;
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
		jasmineSuite:jasmineSuite,
		exdefine:exdefine
		 
}
