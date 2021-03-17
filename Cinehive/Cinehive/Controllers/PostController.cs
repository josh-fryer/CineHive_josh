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
        [HttpPost]
        public ActionResult Create(Post post)
        {
                postService.CreatePost(post);

                return RedirectToAction("Index", "Home"); 
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult DeletePost(int id)
        {
            return View(postService.GetPost(id));
        }

        [HttpPost]
        public ActionResult DeletePost(int id, Post post)
        {
            postService.DeletePost(id);
            return RedirectToAction("GetCurrUserPosts");
        }

        // get posts for userId
        public ActionResult GetCurrUserPosts()
        {
            return View(postService.GetCurrUserPosts());
        }

        public ActionResult GiveAward(int id)
        {
            Post post = context.Posts.Find(id);
            string userid = User.Identity.GetUserId().ToString();

            Like like = new Like()
            {
                PostId = id,
                UserId = userid
            };

            context.Likes.Add(like);

            post.Awards++;

            context.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}
