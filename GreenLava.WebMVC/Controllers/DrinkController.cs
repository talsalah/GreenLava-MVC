using GreenLava.Data;
using GreenLava.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenLava.Services;
using Microsoft.AspNet.Identity;

namespace GreenLava.WebMVC.Controllers
{

    public class DrinkController : Controller
    {
        // GET: Drink
        public ActionResult Index()
        {
            var service = CreateDrinkService();
            var model = service.GetDrinks();

            return View(model);

            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new DrinkService(userId);
            // var model = service.GetNotes();
            //  return View(model);

        }


        public ActionResult Create()
        {
            return View();
        }

        //Post Method 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DrinkCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDrinkService();

                if (service.CreateDrink(model))
                {
                    TempData["SaveResult"] = "Your Drink was created.";
                    return RedirectToAction("Index");
                };
                ModelState.AddModelError("", "Your Drink could not be created.");
                return View(model);
                      
                       
        }

        private DrinkService CreateDrinkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DrinkService(userId);
            return service;
        }


        public ActionResult Details(int id)
        {
            var svc = CreateDrinkService();
            var model = svc.GetDrinkById(id);
                return View(model);
        }


        public ActionResult Edit(int id)
        {
            
            var service = CreateDrinkService();
            var detail = service.GetDrinkById(id);
            var model =
                new DrinkEdit
                {
                    DrinkId = detail.DrinkId,
                    Name = detail.Name,
                    AverageCost = detail.AverageCost,
                     Recipes= detail.Recipes,
                     IsPreferredDrinks= detail.IsPreferredDrinks,
                     ShortDescription=detail.ShortDescription,
                };
            return View(model);
            
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DrinkEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DrinkId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDrinkService();

            if (service.UpdateDrink(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName ("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDrinkService();
            var model = svc.GetDrinkById(id);
            return View(model);
        }



        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateDrinkService();
            service.DeleteDrink(id);
            TempData["SaveResult"] = "Your Drink was deleted";
            return RedirectToAction("Index");
            
        }

        /* public IEnumerable<Drink> Drinks

         {
             get
             {
                 return new List<Drink>
                 {
                     new Drink
                     {
                         Name= "Lemon Ginger",
                         AverageCost= 3.00, ShortDescription= "Pump up your vitamin C levels with this delicious Lemon & Ginger Green Juice recipe. It is mild in flavor, slightly sweet, and so healthy. Vegan and gluten-free.",
                         Recipes="Celery/Cucumber/Lemon/Fresh ginger/ Green apple,  You can adapt the ingredients to whatever you have in your fridge or to your own preferences, but I really love this combination. The apple is optional, and can definitely be left out if you prefer your green juice less sweet. Otherwise, I think you’re really going to like this refreshing ginger lemon juice. Check out the complete recipe with exact measurements in the recipe card at the end of this post",
                         ImageUrl = "https://onedrive.live.com/?cid=B9AA3F0DC119B484&id=B9AA3F0DC119B484%218507&parId=B9AA3F0DC119B484%218503&o=OneUp",
                         IsPreferredDrinks= true,
                       //  Category= _categoryRepository.Categories.First(),

                     },
                       new Drink
                     {
                         Name= "Cucumber",
                         AverageCost= 4.5, ShortDescription= "This refreshing Cucumber Juice recipe only has two ingredients. Serve it straight out the juicer or chilled for a cooling, nourishing green juice.",
                         Recipes="Step One: Wash and prep your veggies Step Two:Feed the cucumbers through the juicing tube of a juicer. Step Three: Serve your cucumber juice immediately.Green juices in general are best right out of the juicer.If you need to store any leftovers, place them in a tightly -sealed container and store in the refrigerator up to 48 hours.",
                         ImageUrl = "https://www.cleaneatingkitchen.com/refreshing-cucumber-juice/",
                         IsPreferredDrinks= false,
                      //   Category= _categoryRepository.Categories.First(),

                     },
                 };
             }
         }*/
    }
}