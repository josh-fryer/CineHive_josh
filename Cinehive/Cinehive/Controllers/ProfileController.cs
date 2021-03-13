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
        public ActionResult Create(UserProfile userProfile, Image image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string userid = User.Identity.GetUserId();

                    if (userProfile.ProfilePicture != null)
                    {
                        profileService.UploadService(userProfile, image);
                    }
                    userProfile.UserId = userid;
                    profileService.CreateProfile(userProfile, userid);
                    return RedirectToAction("MyProfile", "Profile");
                }

                return View(userProfile);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        public ActionResult MyProfile(int? id)
        {
            profileService.GetUserProfile(id);

            if (profileService.GetUserProfile(id) == null)
            {
                return HttpNotFound();
            }
            return View(profileService.GetUserProfile(id));
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            profileService.GetUserProfile(id);

            UserProfile userProfile = context.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            //#### my test genres to checkbox list: ######           
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
        public ActionResult Edit(UserProfile userProfile, Image image) //todo: add to service and data
        {
            string userid = User.Identity.GetUserId();
            var GetProfile = context.UserProfiles.Where(x => x.UserId == userid).Select(c => c.ProfileId).FirstOrDefault();
            int id = GetProfile;
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

                // CLEAR fave genres then add back. ensures no duplicates or more than limit.
                // probably a better way to do this.
                profileService.ClearFaveGenres(userid);
                // check which genres are selected:
                foreach (var g in userProfile.Genres)
                {
                    if(g.Selected)
                    {                     
                        // add selected genre to FaveGenre table
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

        [Authorize]
        public async Task<ActionResult> Album() //todo: add to service and data
        {
            string userid = User.Identity.GetUserId();
            var images = from m in context.Images
                         select m;

            images = images.Where(s => s.UserId == userid);

            return View(await images.ToListAsync());

        }
        [Authorize]
        public ActionResult MakeProfilePicture(Image image) //todo: add to service and data
        {
            string userid = User.Identity.GetUserId();
            var GetProfile = context.UserProfiles.Where(x => x.UserId == userid).Select(c => c.ProfileId).FirstOrDefault();
            int id = GetProfile;

            UserProfile userProfile = context.UserProfiles.Find(id);

            userProfile.ImagePath = image.ImagePath;
            
            context.Entry(userProfile).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("MyProfile");
        }
    }
}