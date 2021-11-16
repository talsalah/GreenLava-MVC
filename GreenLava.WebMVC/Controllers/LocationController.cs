using GreenLava.Models;
using GreenLava.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenLava.WebMVC.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            var service = CreateLocationService();
            var model = service.GetLocations();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLocationService();

            if (service.CreateLocation(model))
            {
                TempData["SaveResult"] = "Your Restaurant Location was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Your Restaurant Location could not be created.");
            return View(model);


        }
        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {

            var service = CreateLocationService();
            var detail = service.GetLocationById(id);
            var model =
                new LocationEdit
                {
                    LocationID = detail.LocationID,
                    StreetOne = detail.StreetOne,
                    StreetTwo = detail.StreetTwo,
                    City = detail.City,
                    State = detail.State,
                    Zipcode = detail.Zipcode,

                };
            return View(model);


        }
    }
}