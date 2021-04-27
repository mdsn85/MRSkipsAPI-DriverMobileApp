using MrSkipsAPI.Models;
using MRSkipsAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSkipsAPI.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetDailyTripsbyDriver(int DriverId, string SelectedDay)
        {

            DateTime today = DateTime.ParseExact(SelectedDay, "yyyy-MM-dd", null);
            List<TripSheetDaetails> tripDetails = db.TripSheetDaetails.Where(td => td.DriverId == DriverId && td.TripsDate == today).ToList();
            var trips = tripDetails.Select(t => new
            {
                Name = t.Contracts.Customer.CompanyName,
                Location = t.Contracts.SkipLocation,
                DoNum = t.DoNum.Trim(),
                Size = t.Contracts.Products.Name,
                Mobile = t.Contracts.MobileNo,
                AllocatedSkips = t.NumberOfSkipscollected
            }).ToList();
            // ViewBag.Vehicle = db.Vehicles.Find().PlateNo;
            // ViewBag.Helpers = db.he.Find(DriverId).Name;

            var list = JsonConvert.SerializeObject(new { success = true, Trips = trips },
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

            return Content(list, "application/json");

        }
    }
}
