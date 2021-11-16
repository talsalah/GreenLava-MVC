using GreenLava.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenLava.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var model = new CategoryListItem[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        //Post Method 
        public ActionResult Create(CategoryCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}