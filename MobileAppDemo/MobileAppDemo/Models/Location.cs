using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MobileAppDemo.Models;

namespace MobileAppDemo.Models
{
    public class Location
    {
        public int ID { get; set; }
        public int LocationID { get; set; }
        public Boolean Collected { get; set; }
        public Boolean Dry { get; set; }
        public Boolean Skipped { get; set; }
        public String Comment { get; set; }
        public String Timestamp { get; set; }
        public float Geostamp_lat { get; set; }
        public float Geostamp_lon { get; set; }

    }
}
