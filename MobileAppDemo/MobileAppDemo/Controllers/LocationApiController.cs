using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileAppDemo.Models;
using System.Diagnostics;

namespace MobileAppDemo.Controllers
{
    public class LocationApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<Location> GetLocationList()
        {
            TestDBContext _db = new TestDBContext();

            var query = from loc in _db.Locations
                        select loc;
            return query.ToList();
        }

        public static void InsertLocation(Location loc)
        {
            TestDBContext _db = new TestDBContext();
            _db.Locations.Add(loc);
            _db.SaveChanges();
        }

        // DELETE api/locationapi/5
        public void Delete(int id)
        {
            TestDBContext _db = new TestDBContext();

            try
            {
                Location loc = _db.Locations.Where((c) => c.ID == id).FirstOrDefault();
                Debug.WriteLine("deleting loc: " + loc.ID);
                _db.Locations.Remove(loc);
                _db.SaveChanges();
            }
            catch
            {
                Debug.WriteLine("failed on delete");
            }
        }
    }
}
