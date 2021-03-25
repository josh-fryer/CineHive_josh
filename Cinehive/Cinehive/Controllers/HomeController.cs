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

namespace Cinehive.Controllers
{
    public class HomeController : Controller
    {
        private IProfileService profileService;
        private readonly CineHiveContext context = new CineHiveContext();

        public HomeController()
        {
            profileService = new ProfileService();
        }

        
        public ActionResult Index(int? page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var Posts = context.Posts.Select(c => c); 
                Posts = context.Posts.OrderByDescending(c => c.DatePosted);
                string userid = User.Identity.GetUserId();


                int pageSize = 5;
                int pageNumber = (page ?? 1);
                var NewPosts = Posts.ToPagedList(pageNumber, pageSize);
                PostFeedViewModel postFeedViewModel = new PostFeedViewModel()
                {
                    UserProfile = profileService.GetUserProfile(0),
                    PostList = NewPosts
                    
                };
                return View(postFeedViewModel);
            }

            return RedirectToAction("Welcome");
        }
        public ActionResult Trending(int? page = 1)
        {
            var TrendingPosts = context.Posts.Where(c => c.Trending == true).ToList();
            string userid = User.Identity.GetUserId();

            int pageSize = 7;
            int pageNumber = (page ?? 1);
            var NewPosts = TrendingPosts.ToPagedList(pageNumber, pageSize);
            PostFeedViewModel postFeedViewModel = new PostFeedViewModel()
            {
                UserProfile = profileService.GetUserProfile(0),
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