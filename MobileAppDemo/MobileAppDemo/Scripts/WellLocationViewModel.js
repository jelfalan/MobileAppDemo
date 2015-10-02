function well_location(id, locationid, dry, collected, skipped, comment, timestamp) {
    var self = this;

    self.ID = id;
    self.LocationID = locationid;
    self.Dry = dry;
    self.Collected = collected;
    self.Skipped = skipped;
    self.Comment = comment;
    self.Timestamp = timestamp;

}

//function locationVM() {
//    var self = this;

//    self.allLocations = ko.observableArray([]);
//    self.getLocations = function () {

//        self.allLocations.removeAll();

//        $.getJSON("/api/LocationApi/", function (data) {
//            $.each(data, function (key, val) {
//                self.allLocations.push(new well_location(val.ID, val.LocationID, val.Dry, val.Collected, val.Skipped,                   val.Comment, val.Timestamp));
//            });
//        });
//    }
//}

//uses data from localstorage
function locationVM() {
    var self = this;

    self.allLocations = ko.observableArray([]);
    self.getLocations = function () {

        self.allLocations.removeAll();
        var retWrapper = JSON.parse(store.get("Locations"));
        var objMap = retWrapper.map;
        console.log(objMap);

        $.each(objMap, function (key, value) {
            self.allLocations.push(new well_location(value.ID, value.LocationID, value.Dry, value.Collected, value.Skipped, value.Comment, value.Timestamp));
        });

    }
}


$(document).ready(function () {
    ko.applyBindings(new locationVM, document.getElementById('displayNode'));
    //  ko.applyBindings(new well_location, document.getElementById('createNode'));
    $(window).load(function () {
        $('#btnGetLocations').click();//refresh on page load
    });
    //$('#locationsList')

});
