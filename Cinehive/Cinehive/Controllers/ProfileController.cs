using HiveData.Models;
using HiveServices.IService;
using HiveServices.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HiveData.Repository;
using System.Threading.Tasks;
using HiveData.ViewModels;
using System.Collections.Generic;

namespace Cinehive.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileService profileService;
        private readonly CineHiveContext context = new CineHiveContext();

        public ProfileController()
        {
            profileService = new ProfileService();
        }

        [Authorize]
        public ActionResult Index(int? id)
        {
            var userid = User.Identity.GetUserId();
            profileService.GetUserProfile(id);

            if (profileService.GetUserProfile(id) == null)
            {
                return HttpNotFound();
            }

            var userpost = context.UserProfiles.Where(c => c.UserId == userid).FirstOrDefault();


            ProfilePostsViewModel profilePostsViewModel = new ProfilePostsViewModel
            {
                userProfile = profileService.GetUserProfile(id),
                Posts = userpost.Posts.ToList(),
            };

            List<string> genreNames = new List<string>();
            // match favegenre genreId with Genres ID to get name
            foreach (var f in userpost.FavouriteGenres.ToList())
            {
               string name = context.Genres.Find(f.GenreId).Name;
               genreNames.Add(name);
            }

            ViewBag.GenreNames = genreNames;

            return View(profilePostsViewModel);

        }

        [Authorize]
        public ActionResult Edit(int? id)
        {            
            //UserProfile userProfile = context.UserProfiles.Find(id);
            UserProfile userProfile = profileService.GetUserProfile(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            //#### Genres to checkbox list: ######           
            var genreList = context.Genres.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            userProfile.Genres = genreList;
            //#########################
            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile userProfile, Image image) // To-do: add to service and data layer
        {
            string userid = User.Identity.GetUserId();
            int id = context.UserProfiles.Where(x => x.UserId == userid).Select(c => c.ProfileId).FirstOrDefault();
            
            if (ModelState.IsValid) // if there are no form errors
            {
                
                if (userProfile.ProfilePicture != null)
                {
                    profileService.UploadService(userProfile, image);
                }

                userProfile.UserId = userid;
                userProfile.ProfileId = id;

                context.Entry(userProfile).State = EntityState.Modified;

                if (userProfile.ProfilePicture == null)
                {
                    context.Entry(userProfile).Property(x => x.ImagePath).IsModified = false;
                }
                if (userProfile.DateOfBirth == null)
                {
                    context.Entry(userProfile).Property(z => z.DateOfBirth).IsModified = false;
                }
                if (userProfile.Gender == null)
                {
                    context.Entry(userProfile).Property(v => v.Gender).IsModified = false;
                }

                // CLEAR fave genres then add back. ensures no duplicates or more than limit.
                // probably a better way to do this.
                profileService.ClearFaveGenres(userid);
                // check which genres are selected:
                foreach (var g in userProfile.Genres)
                {
                    if (g.Selected)
                    {
                        // add selected genre to FaveGenre on userprofile
                        profileService.AddFaveGenre(int.Parse(g.Value), userid);
                    }
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

        //[Authorize]
        //public async Task<ActionResult> Album() //Temporary action
        //{
        //    string userid = User.Identity.GetUserId();
        //    var images = from m in context.Images
        //                 select m;

        //    //images = images.Where(s => s.UserId == userid); #broken with new models

        //    return View(await images.ToListAsync());

        //}
        //[Authorize]
        //public ActionResult MakeProfilePicture(Image image) //Temporary action
        //{
        //    string userid = User.Identity.GetUserId();
        //    var GetProfile = context.UserProfiles.Where(x => x.UserId == userid).Select(c => c.ProfileId).FirstOrDefault();
        //    int id = GetProfile;

        //    UserProfile userProfile = context.UserProfiles.Find(id);

        //    userProfile.ImagePath = image.ImagePath;
            
        //    context.Entry(userProfile).State = EntityState.Modified;
        //    context.SaveChanges();

        //    return RedirectToAction("Index");
        //}
    }
}