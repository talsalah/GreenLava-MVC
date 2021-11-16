using GreenLava.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenLava.Services;


namespace GreenLava.WebMVC.Controllers
{
    public class NoteController : Controller
    {
        // GET: Note

        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new NoteService(userId);
            //var model = service.GetNotes();
            var service = CreateNoteService();
            var model = service.GetNotes();


            // var model = new NoteListItem[0];
            return View(model);

        }
        //get

        // GET: Note
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateNoteService();
            if (service.CreateNote(model))

            {
                return RedirectToAction("Index");

            };
            // ModelState.AddModelError("","Note could not be created.");

            return View(model);
        }


        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            return service;
        }
    

        
        /*public ActionResult DeletePost(int id)
        {
            var service = Crea;
            return RedirectToAction("Index");

        }
        //public ActionResult Index()
        //{
        //   var model = new NoteListItem[0];
        //    return View(model);

        //}

        // GET: Note
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //Post Method 
      /*  public ActionResult Create(NoteCreate model)
        {
           if (ModelState.IsValid)
          {

           }
           return View(model);

        }*/
    }
}