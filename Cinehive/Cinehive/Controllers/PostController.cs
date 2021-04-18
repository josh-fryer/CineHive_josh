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


        // POST: Posts/Create
        [Authorize]
        public ActionResult Create(string input, Post post)
        {
            postService.CreatePost(input, post);
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
            postService.DeleteAssociatedComments(id);

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
            postService.GiveAward(id);

            return RedirectToAction("Index","Home");
        }
        public ActionResult RevokeAward(int id, Award award)
        {

            var userid = User.Identity.GetUserId();
            UserProfile profile = context.UserProfiles.First(x => x.UserId == userid);
            Post post = context.Posts.Find(id);
            award = profile.Awards.Where(x => x.PostId == id).FirstOrDefault();
            

            post.Awards--;

            profile.Awards.Remove(award);
            context.Awards.Remove(award);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SharePost(int id)
        {
            Post post = postService.GetPost(id);
            

            Post post1 = new Post
            {
                PostContent = post.PostContent,
                DatePosted = DateTime.Now,
                Author = post.Author,
                AuthorPP = post.AuthorPP,
                Shared = true
                
            };

            string userid = User.Identity.GetUserId();
            UserProfile profile = context.UserProfiles.First(x => x.UserId == userid);
            profile.Posts.Add(post1);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
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
