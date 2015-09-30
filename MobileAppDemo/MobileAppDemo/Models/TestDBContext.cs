using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MobileAppDemo.Models;

namespace MobileAppDemo.Models
{
    public class TestDBContext : DbContext
    {
        public DbSet<Template> Templates { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}