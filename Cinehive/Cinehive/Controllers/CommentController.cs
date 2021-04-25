using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiveData.Models;
using HiveData.Repository;
using Microsoft.AspNet.Identity;
using HiveServices.Service;
using HiveServices.IService;

namespace Cinehive.Controllers
{
    public class CommentController : Controller
    {
        private CineHiveContext context = new CineHiveContext();

        private ICommentService commentService;

        public CommentController()
        {
            commentService = new CommentService();
        }

        public ActionResult Create(int id)
        {
            TempData["postid"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(PostComment comment, int id)
        {
            id = Convert.ToInt32(TempData["postid"]);
            var userid = User.Identity.GetUserId();
            try
            {
                UserProfile userProfile = context.UserProfiles.First(c => c.UserId == userid);
                Post post = context.Posts.First(c => c.PostId == id);

                comment = new PostComment
                {
                    CommentContent = comment.CommentContent,
                    DateCommented = DateTime.Now,
                    Awards = 0
                    
                };

                userProfile.Comments.Add(comment);
                post.PostComments.Add(comment);
                if (post.PostComments.Count >= 5)
                {
                    post.Popular = true;
                }
                context.SaveChanges();

                return RedirectToAction("ViewPostComments", "Post", new{ id = id });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id, int postid)
        {
            TempData["SecPostid"] = postid;

            return View(commentService.GetComment(id));
        }

        [HttpPost]
        public ActionResult Edit(PostComment postComment, int postID)
        {          
            try
            {
                if (ModelState.IsValid)
                {
                    commentService.EditComment(postComment);

                }
                return RedirectToAction("ViewPostComments", "Post", new { id = postID });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id, int postid)
        {
            commentService.DeleteComment(id);
            return RedirectToAction("ViewPostComments", "Post", new { id = postid });
        }

        public ActionResult CreateDirect(string input, int id)
        {
            var userid = User.Identity.GetUserId();
            try
            {
                UserProfile userProfile = context.UserProfiles.First(c => c.UserId == userid);
                Post post = context.Posts.First(c => c.PostId == id);

                PostComment comment = new PostComment
                {
                    CommentContent = input,
                    DateCommented = DateTime.Now,
                    Awards = 0

                };

                userProfile.Comments.Add(comment);
                post.PostComments.Add(comment);
                if (post.PostComments.Count >= 5)
                {
                    post.Popular = true;
                }
                context.SaveChanges();

                return RedirectToAction("ViewPostComments", "Post", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        public void GiveAward(int id) // called by JS on Post.js
        {
            var userId = User.Identity.GetUserId();
            commentService.GiveAward(id, userId);
        }

        public void RevokeAward(int id)
        {
            var userId = User.Identity.GetUserId();
            commentService.RevokeAward(id, userId);
        }

    }
}