$(document).ready(function () {
    var status = $(".onlineStatus");
    if (isOnline()) {
        status.text("Online");
        status.
            removeClass("offline").
            addClass("online");
    } else {
        status.text("Offline");
        status.
            removeClass("online").
            addClass("offline");
    }
});

function isOnline() {
    return navigator.onLine;
}