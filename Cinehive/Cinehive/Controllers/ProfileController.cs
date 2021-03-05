using Cinehive.Models;
using HiveData.Models;
using HiveServices.IService;
using HiveServices.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HiveData.Repository;

namespace Cinehive.Controllers
{
    public class ProfileController : Controller
    {
        IProfileService profileService;

        private readonly CineHiveContext context = new CineHiveContext();

        public ProfileController()
        {
            profileService = new ProfileService();

        }
        [Authorize]
        public ActionResult Index()
        {

            string userid = User.Identity.GetUserId();

            if (!context.UserProfiles.Any(x => x.UserId == userid))
            {
                return RedirectToAction("Create", "Profile");

            }

            return RedirectToAction("MyProfile", "Profile");
        }
        [Authorize]
        public ActionResult Create()
        {
            string userid = User.Identity.GetUserId();
            if (context.UserProfiles.Any(x => x.UserId == userid))
            {
                return RedirectToAction("MyProfile", "Profile");

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                string userid = User.Identity.GetUserId();

                if (userProfile.ProfilePicture != null)
                {
                    profileService.UploadService(userProfile);
                }
                userProfile.UserId = userid;
                profileService.CreateProfile(userProfile, userid);
                return RedirectToAction("MyProfile", "Profile");
            }

            return View(userProfile);
        }
        [Authorize]
        public ActionResult MyProfile(int? id)
        {
            string userid = User.Identity.GetUserId();
            var GetProfile = context.UserProfiles.Where(x => x.UserId == userid).Select(c => c.ProfileId).FirstOrDefault();
            id = GetProfile;

            profileService.ViewProfile(id);
            if (profileService.ViewProfile(id) == null)
            {
                return HttpNotFound();
            }
            return View(profileService.ViewProfile(id));
        }
        [Authorize]
        public ActionResult Edit(int? id)
        {
            string userid = User.Identity.GetUserId();
            var GetProfile = context.UserProfiles.Where(x => x.UserId == userid).Select(c => c.ProfileId).FirstOrDefault();
            id = GetProfile;

            UserProfile userProfile = context.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Firstname, Lastname, Gender, DateOfBirth, AboutMe, ProfilePicture, ImagePath")] UserProfile userProfile)
        {
            string userid = User.Identity.GetUserId();
            var GetProfile = context.UserProfiles.Where(x => x.UserId == userid).Select(c => c.ProfileId).FirstOrDefault();
            int id = GetProfile;
            if (ModelState.IsValid)
            {

                if (userProfile.ProfilePicture != null)
                {
                    profileService.UploadService(userProfile);
                }

                userProfile.UserId = userid;
                userProfile.ProfileId = id;
                context.Entry(userProfile).State = EntityState.Modified;
                if (userProfile.ProfilePicture == null)
                {
                    context.Entry(userProfile).Property(x => x.ImagePath).IsModified = false;
                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userProfile);
        }
        public ActionResult ViewProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profileService.ViewProfile(id);

            if (profileService.ViewProfile(id) == null)
            {
                return HttpNotFound();
            }
            return View(profileService.ViewProfile(id));

        }

    }
}