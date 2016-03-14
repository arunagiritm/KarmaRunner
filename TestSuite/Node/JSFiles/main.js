var fs = require('fs');
var path = require('path');
var id,pid;
var jsuites=[];
var inputFile="./suite.js";
var outputFile="../results/execute";
var jSuiteFile="../output/jsuite.json";
//Function  to read json file
function ReadSpecJson(filename){
	
	//var fdata = ReadFile(filename);
	var fdata=require(filename);
	
    if (fdata==null){
        console.log("Error in reading file : " + filename);
        return;
       }
    //loop through the object
    var specFiles = fdata.fileinfo;
    var outfile;
	specFiles.forEach(function(currentValue,index,array){
        var data= ConcatFiles(array[index]);
		outfile = outputFile+new Date().getTime().toString()+".js";
		fs.writeFileSync(outfile, data );
        ExecuteFiles(array[index],outfile);
	    // console.log(jsuites[0].suite);
        fs.unlinkSync(outfile);
    });
	fs.writeFileSync(jSuiteFile, JSON.stringify(jsuites));
	

};


function ConcatFiles(filename){
    var funcdef = " \nfunction exdefine(a,b,specfile){\njid=a || 1;\njpid=b || 0;\n  sfile=specfile || '';";
	var f1=fs.readFileSync(inputFile,'utf8');
	var f2 =fs.readFileSync(filename,'utf8');
    var cdata = f1 + funcdef+ f2 +"};";
    return cdata;
}

function ExecuteFiles(sfile,outfile){
	var exefile = {};
	exefile =require(outfile);   
	exefile.exdefine(id,pid,sfile);
	id=exefile.jids.jid+2;
	pid=exefile.jids.jid+1;
	var jsuite={};
	jsuite ={
		file:sfile,
        suite:exefile.jasmineSuite
	}
	// console.log(jsuite);
	jsuites.push(jsuite);
}

function ReadFile(filename){
    fs.readFile(filename,{encoding: 'utf-8'}, function(err,data) {
	  if (err){
		 console.log(err);
		 return null;
	  }
    return data;
    
});
}


    
module.exports={
    
    ReadSpecJson:ReadSpecJson,
	jsuites:jsuites
    
}
