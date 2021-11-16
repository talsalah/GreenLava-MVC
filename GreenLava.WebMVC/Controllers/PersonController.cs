using GreenLava.Data;
using GreenLava.Models;
using ICSharpCode.Decompiler.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace GreenLava.WebMVC.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        //public IHttpActionResult Get()
        //{
        //    Person personService = CreatePersonService();
        //    var persons = personService.GetPersons();
        //    return Ok(persons);

        //}

         public ActionResult Index()
         {
             var model = new PersonListItem[0];
             return View(model);
         }

        public ActionResult Create()
        {
            return View();
        }


        //Post Method 
 /*       public ActionResult Create(PersonCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
            public ActionResult ListPeople()
        {
            List<PersonListItem> people = new List<PersonListItem>();
            people.Add(new PersonListItem { PersonId = 1, Name = "Tulha Alsalah", Email = "tulha.alsalah@gmail.com", Hobby = "Product and Food Photographer" });
            people.Add(new PersonListItem { PersonId = 2, Name = "Jumana Wehbi", Email = "jwehbi@gmail.com", Hobby = "Recipe Developer" });
            people.Add(new PersonListItem { PersonId = 3, Name = "Hisham", Email = "coobjh@gmail.com", Hobby= "Food Blogger" });

            return View(people);

        }*/



    
    }
}