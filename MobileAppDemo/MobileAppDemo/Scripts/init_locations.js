$(document).ready(function () {

    // var store = new Lawnchair({ name: 'Locations' }, function (store) { });

    //initLocations = function (Locations){

    //  //  var Locations = loc;
    //    var key = "";

    //    for (var i = 0; i < Locations.length; i++) {

    //        key = "loc_" + Locations[i].ID;

    //        var newLocation = {
    //            key: key,
    //            type: 'Location',
    //            ID : Locations[i].ID,
    //            LocationID : Locations[i].LocationID,
    //            Dry : Locations[i].Dry,
    //            Collected : Locations[i].Collected,
    //            Skipped : Locations[i].Skipped,
    //            Comment : Locations[i].Comment,
    //            timestamp : Locations[i].timestamp,
    //            geostamp_lat : Locations[i].geostamp_lat,
    //            geostamp_lon : Locations[i].geostamp_lon
    //        };

    //        console.log("Saving newlocation with key: " + newLocation.key);

    //        //lawnchair_store.save(newLocation);
    //        store.set(newLocation.key,newLocation);

    //    };
    //}

    function initLocations() {
        console.log("initializing locations...");
        $.getJSON("/api/LocationApi/", function (data) {
            mapper("Locations", data);
        });
        //get sample is in WellLocationViewModel -> locationVM()
    };

    function checkStore(str, callBack) {
        if (store.get(str) == null) { callBack(); }
        else { console.log(str + " already initialized") } //debug
    };

    //abstracted helper function for creating a new entity/object store
    function mapper(entityName, data) {
        var wrapper = { 'map': '' }; //need a key for the array/map or else store returns undefined
        var mapObj = {}; //simplifies returning the object by id instead of looping thru an array

        for (var i = 0; i < data.length; i++) {
            var obj = {};
            $.each(data[i], function (key, value) { //add each property
                obj[key] = value;
            });
            console.log("new obj: " + JSON.stringify(obj));
            mapObj[obj.ID] = obj;
        };
        wrapper.map = mapObj;
        store.set(entityName, JSON.stringify(wrapper)); //store the new entity in localstorage
    }

    //Main Checks
    checkStore("Locations", initLocations); //check to see of locations have been created locally

});

