using HiveData.Repository;
using Cinehive.Models;
using HiveData.IDAO;
using HiveData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Data.Entity;

namespace HiveData.DAO
{
    public class PostDAO : IPostDAO
    {
        public void CreatePost(string input, Post post, CineHiveContext context)
        {
            post.PostContent = input;
            post.DatePosted = DateTime.Now;
            post.Popular = false;
            string userId = HttpContext.Current.User.Identity.GetUserId();
            // find userprofile by userId then Add post to their posts collection
            UserProfile profile = context.UserProfiles.First(x => x.UserId == userId);
            //post.Author = profile.Firstname + " " + profile.Lastname;
            post.AuthorPicture = profile.ImagePath;
            post.Shared = false;
            profile.Posts.Add(post);           
        }

        public void DeletePost(Post post, CineHiveContext context)
        {
            var awards = context.Awards.Where(a => a.Post.PostId == post.PostId).ToList();
            context.Awards.RemoveRange(awards);
            context.Posts.Remove(post);
            context.SaveChanges();
        }

        public Post GetPost(int id, CineHiveContext context)
        {
            return context.Posts.Find(id);
        }

        public IList<Post> GetUserPosts(string userId, CineHiveContext context)
        {
            UserProfile user = context.UserProfiles.First(x => x.UserId == userId);
            return user.Posts.ToList(); // return collection of user's posts
        }

        public void EditPost(Post post, CineHiveContext context)
        {
            // make db update existing post with changed/new data
            post.Edited = true;
            context.Entry(post).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void GiveAward(int id, string userId, CineHiveContext context)
        {
            UserProfile profile = context.UserProfiles.First(x => x.UserId == userId);
            Post post = context.Posts.Find(id);
            Award award = new Award();
            
            post.Awards++; 
            award.Post = post;

            int awardcount = context.Awards.Where(c => c.Post.PostId == id).Count();
            //int awardcount = context.Posts.Where(c => c.PostId == id).Select(v => v.Awards).Count();


            if (awardcount >= 3)
            {
                post.Popular = true;
            }

            profile.Awards.Add(award);
        }

        public void RevokeAward(int id, string userId, CineHiveContext context)
        {
            UserProfile profile = context.UserProfiles.First(x => x.UserId == userId);
            Post post = context.Posts.Find(id);
            Award award = profile.Awards.Where(x => x.Post == post).FirstOrDefault();

            post.Awards--;

            profile.Awards.Remove(award);
            context.Awards.Remove(award);
        }

        public Award FindAward(int id, CineHiveContext context)
        {
            return context.Awards.Find(id);
        }

        public void DeleteAssociatedComments(int id, CineHiveContext context)
        {
            var comments = context.Posts.Find(id).PostComments.ToList();
            foreach (var item in comments)
            {
                var awards = context.Awards.Where(a => a.PostComment.CommentId == item.CommentId).ToList();
                context.Awards.RemoveRange(awards);
                context.PostComments.Remove(item);
            } 
        }


    }
}