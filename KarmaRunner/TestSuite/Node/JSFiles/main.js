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
	var specFiles =fdata.fileinfo;
	specFiles.forEach(function(currentValue,index,array){
        var data= ConcatFiles(array[index]);
		var outfile = outputFile+new Date().getTime().toString()+".js";
		fs.writeFileSync(outfile, data );
        ExecuteFiles(array[index],outfile);
        // console.log(jsuites[0].suite);
    });
	fs.writeFileSync(jSuiteFile,JSON.stringify(jsuites));

};


function ConcatFiles(filename){
    var funcdef=" \nfunction exdefine(a,b){\njid=a || 1;\njpid=b || 0;\n";
	var f1=fs.readFileSync(inputFile,'utf8');
	var f2 =fs.readFileSync(filename,'utf8');
    var cdata = f1 + funcdef+ f2 +"};";
    return cdata;
}

function ExecuteFiles(sfile,outfile){
	var exefile = {};
	exefile =require(outfile);   
	exefile.exdefine(id,pid);
	id=exefile.jid+1;
	pid=exefile.jpid+1;
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
