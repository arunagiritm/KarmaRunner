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
 
function exdefine(a,b){
jid=a || 1;
jpid=b || 0;
describe("Player", function() {
  var player;
  var song;

  beforeEach(function() {
    player = new Player();
    song = new Song();
  });

  it("should be able to play a Song", function() {
    player.play(song);
    expect(player.currentlyPlayingSong).toEqual(song);

    //demonstrates use of custom matcher
    expect(player).toBePlaying(song);
  });

  describe("when song has been paused", function() {
    beforeEach(function() {
      player.play(song);
      player.pause();
    });

    it("should indicate that the song is currently paused", function() {
      expect(player.isPlaying).toBeFalsy();

      // demonstrates use of 'not' with a custom matcher
      expect(player).not.toBePlaying(song);
    });

    it("should be possible to resume", function() {
      player.resume();
      expect(player.isPlaying).toBeTruthy();
      expect(player.currentlyPlayingSong).toEqual(song);
    });
  });

  // demonstrates use of spies to intercept and test method calls
  it("tells the current song if the user has made it a favorite", function() {
    spyOn(song, 'persistFavoriteStatus');

    player.play(song);
    player.makeFavorite();

    expect(song.persistFavoriteStatus).toHaveBeenCalledWith(true);
  });

  //demonstrates use of expected exceptions
  describe("#resume", function() {
    it("should throw an exception if song is already playing", function() {
      player.play(song);

      expect(function() {
        player.resume();
      }).toThrowError("song is already playing");
    });
  });
});
};