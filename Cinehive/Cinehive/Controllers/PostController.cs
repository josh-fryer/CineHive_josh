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

        [Authorize]
        public ActionResult Create(string input, Post post, string location = "home")
        {
            postService.CreatePost(input, post);
            if(location == "profile")
            {
                return RedirectToAction("Index", "Profile");
            }
            return RedirectToAction("Index", "Home"); 
        }

        public ActionResult EditPost(int id)
        {           
            return View(postService.GetPost(id));
        }

        [HttpPost]
        [ValidateInput(false)] // if editing a post with a html film link, let it post
        public ActionResult EditPost(int id, Post post)
        {
            postService.EditPost(post);
            return RedirectToAction("ViewPostComments", "Post", new { id = id });
        }
        
        public ActionResult DeletePost(int id)
        {
            postService.DeleteAssociatedComments(id);
            postService.DeletePost(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewPostComments(int id, string message = "")
        {
            var comments = context.Posts.Find(id).PostComments.ToList();
            string OriginalPost = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(x => x.PostId == id).FirstOrDefault())).Select(c => c.UserId).FirstOrDefault();

            PostCommentUserViewModel postCommentUserViewModel = new PostCommentUserViewModel
            {
                UserProfile = context.UserProfiles.Where(c => c.UserId == OriginalPost).FirstOrDefault(),
                CommentList = comments,
                Post = context.Posts.Find(id)
            };

            if(!String.IsNullOrEmpty(message))
            {
                ViewBag.AlertMessage = message;
            }

            return View(postCommentUserViewModel);
        }

        public void GiveAward(int id) // called by JS on Post.js
        {
            var userId = User.Identity.GetUserId();
            postService.GiveAward(id, userId);
            //return RedirectToAction("Index", "Home");
        }

        public void RevokeAward(int id)
        {
            var userId = User.Identity.GetUserId();
            postService.RevokeAward(id, userId);
        }

        public ActionResult SharePost(int id)
        {
            string userID = User.Identity.GetUserId();
            postService.SharePost(id, userID);
            return RedirectToAction("ViewPostComments", new { id = id, message = "Successfully shared post!"});
        }

        [HttpGet]
        public ActionResult ProfilePostCommentsPartial(int i_d)
        {
            var comments = context.Posts.Find(i_d).PostComments.OrderByDescending(c => c.DateCommented).ToList();
            string OriginalPost = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(x => x.PostId == i_d).FirstOrDefault())).Select(c => c.UserId).FirstOrDefault();


            ProfilePostsViewModel postCommentUserViewModel = new ProfilePostsViewModel
            {
                userProfile = context.UserProfiles.Where(c => c.UserId == OriginalPost).FirstOrDefault(),
                PostComments = comments,
                Post = context.Posts.Find(i_d)
            };

            return PartialView(postCommentUserViewModel);
        }

        public ActionResult IndexPostCommentsPartial(int i_d)
        {
            var comments = context.Posts.Find(i_d).PostComments.OrderByDescending(c => c.DateCommented).ToList();
            string OriginalPost = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(x => x.PostId == i_d).FirstOrDefault())).Select(c => c.UserId).FirstOrDefault();


            PostFeedViewModel postFeedViewModel = new PostFeedViewModel
            {
                Post = context.Posts.Find(i_d),
                CommentList = comments
            };

            return PartialView(postFeedViewModel);
        }
    }
}
