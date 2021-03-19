using HiveData.Models;
using HiveData.Repository;
using HiveServices.IService;
using HiveServices.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinehive.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;
        private CineHiveContext context = new CineHiveContext();

        public PostController()
        {
            postService = new PostService();
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Post post)
        {
                postService.CreatePost(post);
                return RedirectToAction("Index", "Home"); 
        }

        public ActionResult EditPost(int id)
        {           
            return View(postService.GetPost(id));
        }

        // POST: Posts/Edit/5
        [HttpPost]
        public ActionResult EditPost(int id, Post post)
        {
            postService.EditPost(post);
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult DeletePost(int id)
        {
            postService.DeletePost(id);
            return RedirectToAction("Index", "Home");
        }

        // #### broken with new model changes
        // get posts for logged in user
        //[Authorize]
        //public ActionResult GetCurrUserPosts()
        //{
        //    return View(postService.GetCurrUserPosts());
        //}
        
        //[Authorize]
        //public ActionResult GiveAward(int id)
        //{
        //    Post post = context.Posts.Find(id);
        //    string userid = User.Identity.GetUserId().ToString();

        //    Like like = new Like()
        //    {
        //        PostId = id,
        //        UserId = userid
        //    };

        //    context.Likes.Add(like);
        //    post.Awards++;
        //    context.SaveChanges();
        //    return RedirectToAction("Index","Home");
        //}
    }
}
