function jasmineExtn() {this.jsonBasePath = '../../';}

try {
    jasmineExtn.prototype = new commonFaked();
} catch(err) {
    jasmineExtn.prototype = {};
}

jasmineExtn.prototype.readJson = function (jsonfilepath) {
    var vm = this;

    if (window.jasmineRunner && this.jsonBasePath != null) {
        if (jsonfilepath.indexOf('base') >= 0) {
            jsonfilepath = jsonfilepath.replace('base', this.jsonBasePath);
        }
    }
    $.ajax({
        async: false, // must be synchronous to guarantee that no tests are run before fixture is loaded
        cache: false,
        //dataType: 'json',
        url: jsonfilepath,
        success: function (data) {
            vm.jsonData = data;
        },
        error: function ($xhr, status, err) {
            throw new Error('JSONFixture could not be loaded: ' + jsonfilepath + ' (status: ' + status + ', message: ' + err.message + ')')
        }
    });
    if (vm.jsonData) {
        return vm.jsonData;
    } else {
        return null;
    }
}