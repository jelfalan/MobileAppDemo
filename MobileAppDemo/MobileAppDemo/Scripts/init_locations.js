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

            var wrapper  = { 'items': [] }; //need a key 'items' for the array or else store returns undefined

            for (var i = 0; i < data.length; i++) {
                var obj = {};
                $.each(data[i], function (key, value) { //add each property
                    obj[key] = value;
                });
                console.log("new obj: " + JSON.stringify(obj));
                wrapper.items.push(obj);  //push to item array
            };
       
           store.set("Locations", JSON.stringify(wrapper));
        });

       // var retWrapper = JSON.parse(store.get("Locations"));
        //var retWrapper = JSON.parse(localStorage.getItem("Locations"));
          //  console.log(retWrapper);

    };

    function checkStore(str, callBack) {
        if (store.get(str) == null) {
            callBack();
        }
        else {
            console.log(str + " already initialized"); //debug
        }
    };
   
    checkStore("Locations", initLocations);



});

