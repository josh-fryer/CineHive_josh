using Cinehive.Models;
using HiveData.Models.Domain;
using HiveServices.IService;
using HiveServices.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Cinehive.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        // GET: Profile
        [Authorize]
        public ActionResult Index()
        {
            
            string userid = User.Identity.GetUserId();

            if (!context.UserProfiles.Any(x => x.UserId == userid))
            {
                return RedirectToAction("Create", "Profile");

            }

            return Content("Success placeholder");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Firstname,Lastname,Gender,Aboutme,DateOfBirth")] UserProfile userProfile)
        {
            
            if (ModelState.IsValid)
            {
                string userid = User.Identity.GetUserId();
                userProfile.UserId = userid;
                context.UserProfiles.Add(userProfile);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userProfile);
        }
        public ActionResult MyProfile(int? id)
        {
            
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = context.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

    }
}