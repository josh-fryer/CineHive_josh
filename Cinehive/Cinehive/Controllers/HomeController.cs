using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiveData.ViewModels;
using HiveData.Models;
using HiveData.Repository;
using Microsoft.AspNet.Identity;
using PagedList;
using HiveServices.IService;
using HiveServices.Service;
using System.Threading.Tasks;

namespace Cinehive.Controllers
{
    public class HomeController : Controller
    {
        private IProfileService profileService;
        private Helper helper;
        private readonly CineHiveContext context = new CineHiveContext();

        public HomeController()
        {
            profileService = new ProfileService();
            helper = new Helper();
        }
      
        public ActionResult Index(int? page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                // check if user session variables are filled or fill them for returning user
                helper.CheckSession();
                // check if user is in admin role:
                var list = (List<string>)Session["Roles"];
                if(list.Contains("AdminUser"))
                {
                    ViewBag.IsAdmin = true;
                }

                var Posts = context.Posts.Select(c => c); 
                Posts = context.Posts.OrderByDescending(c => c.DatePosted);
                string userid = User.Identity.GetUserId();
                var user = profileService.GetUserProfile(userid);
                Session["fName"] = user.Firstname;
                int pageSize = 8;
                int pageNumber = (page ?? 1);
                var NewPosts = Posts.ToPagedList(pageNumber, pageSize);
                PostFeedViewModel postFeedViewModel = new PostFeedViewModel()
                {
                    UserProfile = user,
                    PostList = NewPosts
                    
                };
                return View(postFeedViewModel);
            }

            return RedirectToAction("Welcome");
        }

        public ActionResult Popular(int? page = 1)
        {
            var PopularPosts = context.Posts.Where(c => c.Popular == true).ToList();
            string userid = User.Identity.GetUserId();

            int pageSize = 7;
            int pageNumber = (page ?? 1);
            var NewPosts = PopularPosts.ToPagedList(pageNumber, pageSize);
            PostFeedViewModel postFeedViewModel = new PostFeedViewModel()
            {
                UserProfile = profileService.GetUserProfile(userid),
                PostList = NewPosts
            };

            return View(postFeedViewModel);
        }

        public ActionResult FriendFeed(int? page = 1)
        {
            var userid = User.Identity.GetUserId();
            var userpost = context.UserProfiles.Where(c => c.UserId == userid).FirstOrDefault();
            var friendpost = userpost.Friends.SelectMany(c => c.Posts).ToList();

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var NewPosts = friendpost.ToPagedList(pageNumber, pageSize);
            PostFeedViewModel postFeedViewModel = new PostFeedViewModel()
            {
                UserProfile = profileService.GetUserProfile(userid),
                PostList = NewPosts

            };

            return View(postFeedViewModel);
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}