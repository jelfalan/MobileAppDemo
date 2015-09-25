using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MobileAppDemo.Models;

namespace MobileAppDemo.Models
{
    public class CustomerRepository
    {
     
        public static IEnumerable<Customer> GetCustomers()
        {
           TestDBContext _db = new TestDBContext();

            var query = from cust in _db.Customers
                        select cust;
            return query.ToList();
        }

        public static void InsertCustomer(Customer cust)
        {
            TestDBContext _db = new TestDBContext();
            _db.Customers.Add(cust);
            _db.SaveChanges();
        }
    }
}