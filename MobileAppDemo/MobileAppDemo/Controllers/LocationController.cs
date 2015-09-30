using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileAppDemo.Models;
using System.Diagnostics;

namespace MobileAppDemo.Controllers
{
    public class LocationController : Controller
    {
        //
        // GET: /Location/

        public ActionResult Index()
        {
            LocationApiController api = new LocationApiController();
            IEnumerable<Location> Locations = api.GetLocationList();
            
            ViewData["Locations"] =  Locations; //pass by viewdata model

            //ViewData.Model = Locations;

            //List<SelectListItem> LocationItems = new List<SelectListItem>();
           
            //int i = 1;
            //foreach(Location loc in Locations){
            //    LocationItems.Add(new SelectListItem() { Text = loc.LocationID.ToString(), Value = i.ToString() });
            //    i++;
            //    Debug.WriteLine(loc.ID.ToString());
            //}
            //ViewData.Add("LocationItems", LocationItems);

            return View();
        }

        
 
    }
}
