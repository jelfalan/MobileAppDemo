using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileAppDemo.Models;
using System.Data.Objects;
using System.Diagnostics;

namespace MobileAppDemo.Controllers
{
    //http://blogs.msdn.com/b/amar/archive/2012/12/12/hello-world-with-knockout-js-and-asp-net-mvc-4.aspx

    public class CustomerController : ApiController
    {
        // GET api/customer
        public IEnumerable<Customer> Get()
        {
            var cust = CustomerRepository.GetCustomers();
            return cust.ToList();
        }

        // GET api/customer/5
        public Customer Get(int id)
        {
            return CustomerRepository.GetCustomers().Where((c) => c.ID == id).FirstOrDefault();
        }

        // POST api/customer
        public HttpResponseMessage Post(Customer value)
        {
            CustomerRepository.InsertCustomer(value);

            var response = Request.CreateResponse<Customer>(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = value.ID });

            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT api/customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customer/5
        public void Delete(int id)
      
    {
            Debug.WriteLine("recieved id: " + id);
            Customer cust = Get(id);
            CustomerRepository.DeleteCustomer(cust);

        }
    }
}
