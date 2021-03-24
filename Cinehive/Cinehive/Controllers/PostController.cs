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
using HiveData.ViewModels;

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
            var comments = context.Posts.Find(id).PostComments.ToList();
            foreach (var item in comments)
            {
                context.PostComments.Remove(item);
            }
            context.SaveChanges();
            
            postService.DeletePost(id);


            return RedirectToAction("Index", "Home");

        }

        
        //get posts for logged in user
        [Authorize]
        public ActionResult GetCurrUserPosts()
        {
            return View(postService.GetCurrUserPosts());
        }

        public ActionResult ViewPostComments(int id)
        {
            var comments = context.Posts.Find(id).PostComments.ToList();
            string OriginalPost = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(x => x.PostId == id).FirstOrDefault())).Select(c => c.UserId).FirstOrDefault();


            PostCommentUserViewModel postCommentUserViewModel = new PostCommentUserViewModel
            {
                UserProfile = context.UserProfiles.Where(c => c.UserId == OriginalPost).FirstOrDefault(),
                CommentList = comments,
                Post = context.Posts.Find(id)
            };

            return View(postCommentUserViewModel);
        }

        public ActionResult GiveAward(int id)
        {
            var userid = User.Identity.GetUserId();
            UserProfile profile = context.UserProfiles.First(x => x.UserId == userid);
            Post post = context.Posts.Find(id);

            Award award = new Award
            {
                PostId = id
            };
            post.Awards++;

            profile.Awards.Add(award);
            context.SaveChanges();


            return RedirectToAction("Index","Home");
        }
    }
}
