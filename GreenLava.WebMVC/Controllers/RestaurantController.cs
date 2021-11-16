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
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            var service = CreateRestaurantService();
            var model = service.GetRestaurants();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Post Method 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRestaurantService();

            if (service.CreateRestaurant(model))
            {
                TempData["SaveResult"] = "Your Restaurant was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Your Restaurant could not be created.");
            return View(model);


        }

        private RestaurantService CreateRestaurantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestaurantService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRestaurantService();
            var model = svc.GetRestaurantById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {

            var service = CreateRestaurantService();
            var detail = service.GetRestaurantById(id);
            var model =
                new RestaurantEdit
                {
                    RestaurantId = detail.RestaurantId,
                    RestaurantName = detail.RestaurantName,
                    Price = detail.Price,
                    ShortDescription = detail.ShortDescription,
                };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestaurantEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RestaurantId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRestaurantService();

            if (service.UpdateRestaurant(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRestaurantService();
            var model = svc.GetRestaurantById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRestaurantService();
            service.DeleteRestaurant(id);
            TempData["SaveResult"] = "Your Restaurant was deleted";
            return RedirectToAction("Index");

        }

    }
}