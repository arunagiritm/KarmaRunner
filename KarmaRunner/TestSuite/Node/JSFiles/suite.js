var jasmineSuite = [];
var jasmineSpec = {};
var jid ;
var jpid;
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
 module.exports ={
        jid:jid,
     jpid:jpid,
		jasmineSuite:jasmineSuite,
		 exdefine:exdefine
		 
}
