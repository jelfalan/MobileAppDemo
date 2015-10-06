function initLocations() {
    console.log("initializing locations...");
    $.getJSON("/api/LocationApi/", function (data) {
        $.when(mapper("Locations", data)).done(console.log("Locations have been initialized"));
    });
    
    //get sample is in WellLocationViewModel -> locationVM()
};

function checkStore(str, callBack1, callBack2) {
    if (store.get(str) == null) {
        callBack1(); //init
    } 
        console.log("locations already initialized");
        callBack2(); //set ko bindings
    };

//abstracted helper function for creating a new entity/object store
function mapper(entityName, data) {
    var wrapper = { 'map': '' }; //need a key for the array/map or else store returns undefined
    var mapObj = {}; //simplifies returning the object by id instead of looping thru an array
    console.log("data length: " + data.length);
    for (var i = 0; i < data.length; i++) {
        var obj = {};
        $.each(data[i], function (key, value) { //add each property
            obj[key] = value;
        });
        console.log("new obj: " + JSON.stringify(obj));
        mapObj[obj.ID] = obj;
    };
    wrapper.map = mapObj;//save the map in the wrapper
    store.set(entityName, JSON.stringify(wrapper)); //store the collection in localstorage
};

//**************************************************************
//LocationsViewModel
//***************************
function well_location(id, locationid, dry, collected, skipped, comment, timestamp) {
    var self = this;

    self.ID = id;
    self.LocationID = ko.observable(locationid);
    self.Dry = dry;
    self.Collected = collected;
    self.Skipped = skipped;
    self.Comment = comment;
    self.Timestamp = timestamp;

};

//uses data from localstorage
function locationVM() {
    var self = this;

    self.allLocations = ko.observableArray([]);
    self.getLocations = function () {

        self.allLocations.removeAll();
        var retWrapper = {};
        var objMap = {};
        if (store.get("Locations") != null) {
            retWrapper = JSON.parse(store.get("Locations"));
            objMap = retWrapper.map;
            console.log(objMap);

            $.each(objMap, function (key, value) {
                self.allLocations.push(new well_location(value.ID, value.LocationID, value.Dry, value.Collected, value.Skipped, value.Comment, value.Timestamp));
            });
        }
        else {
            console.log(Error("locations unavailable, could not be parsed"));
        }
    };
};

function setBindings() {
    $.when(ko.applyBindings(new locationVM, document.getElementById('displayNode'))).then(console.log("location bindings set"));   
};

//************************************************

$(document).ready(function () {
    //Main Checks
    $.when(checkStore("Locations", initLocations, setBindings)).done(//check to see of locations have been created locally
    setTimeout(function () {
        $('#btnGetLocations').click(); //btn must be drawn first to click, delay by .1 sec
    }, 100));  

});



