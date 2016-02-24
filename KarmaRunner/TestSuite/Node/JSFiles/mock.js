//Use this file to create all mocks that is defined within the describe
//Or for any function error is generated on creating tree for specs.
global.jasmine = {};
global.angular = {};
global.jasmineExtn= function jasmineExtn () {
    this.readJson = function () { this.jsonData = {}; return this.jsonData; };
}

jasmine.createSpy = function (a) { };
angular.copy = function () { };