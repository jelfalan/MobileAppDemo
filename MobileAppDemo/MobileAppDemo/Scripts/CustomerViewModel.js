function customer(id, name, age, comments) {
    var self = this;

    self.ID = id;
    self.Name = name;
    self.Age = age;
    self.Comments = comments;

    self.addCustomer = function () {
        $.ajax({
            url: "/api/customer/",
            type: 'post',
            data: ko.toJSON(this),
            contentType: 'application/json',
            success: function (result) {
                $('#btnGetCustomers').click(); //refresh the table view
            }
            });
    }

    self.deleteCustomer = function (cust) {
        // The current item will be passed as the first parameter, so we know which customer to remove
        var custId = parseInt(cust.ID);
        alert("deleting customer:" + cust.Name + "; id: " + custId);
        
        $.ajax({
                 url: "/Home/DeleteCust",
           // url: '@Url.Action("DeleteCust","Home")',
           // url: '<%= Url.Action("DeleteCust", "Home") %>',
            type: 'post',
            dataType: 'json',
          //  cache: false,
            async: false,
            data: { id: custId } ,
           // contentType: 'application/json',
            success: function (result) {
                $('#btnGetCustomers').click(); //refresh the table view
            }
        });
    }

}

function customerVM() {
    var self = this;

    self.customers = ko.observableArray([]);
    self.getCustomers = function () {
        self.customers.removeAll();
        $.getJSON("/api/customer/", function (data) {
            $.each(data, function (key, val) {
                self.customers.push(new customer(val.ID, val.Name, val.Age, val.Comments));
            });
        });
    };
}

$(document).ready(function () {
    ko.applyBindings(new customerVM, document.getElementById('displayNode'));
    ko.applyBindings(new customer, document.getElementById('createNode'));

    $('#btnGetCustomers').click();//refresh on page load

});