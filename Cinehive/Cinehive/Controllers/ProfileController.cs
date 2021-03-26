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
        private readonly CineHiveContext context;

        public ProfileController()
        {
            profileService = new ProfileService();
            context = new CineHiveContext();
        }

        [Authorize]
        public ActionResult Index(int? id)
        {
            var userid = User.Identity.GetUserId();

            var userpost = context.UserProfiles.Where(c => c.UserId == userid).FirstOrDefault();


            ProfilePostsViewModel profilePostsViewModel = new ProfilePostsViewModel
            {
                userProfile = profileService.GetUserProfile(userid),
                Posts = userpost.Posts.ToList()
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
            var userid = User.Identity.GetUserId();
            UserProfile userProfile = profileService.GetUserProfile(userid);
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
            
            if (ModelState.IsValid) 
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

            if (profileService.ViewProfile(id) == null)
            {
                return HttpNotFound();
            }

            // ----- check if User is friends with this profile ------
            UserProfile profileUser = context.UserProfiles.Find(id);
            string userid = User.Identity.GetUserId();
            UserProfile userProfile = context.UserProfiles.First(x=> x.UserId == userid);
            ViewBag.IsFriend = false;
            ViewBag.SentFriendReq = false;
            ViewBag.ReceivedFriendReq = false;

            foreach (var f in userProfile.Friends)
            {
                if (f.ProfileId == id)
                {
                    ViewBag.IsFriend = true;
                    return View(profileService.ViewProfile(id));
                }
            }           

            // check if user has sent friend request
            foreach (var i in userProfile.SentFriendReq)
            {               
                if (profileUser.ReceivedFriendReq.Contains(i))
                {
                    ViewBag.SentFriendReq = true;
                    break;
                }
            }
            
            // check if user has received friend request from profile
            foreach (var i in userProfile.ReceivedFriendReq)
            {
                if (profileUser.SentFriendReq.Contains(i))
                {
                    ViewBag.ReceivedFriendReq = true;
                    break;
                }
            }
            
            return View(profileService.ViewProfile(id));
        }

       
    }
}