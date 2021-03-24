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
        public void CreatePost(Post post, CineHiveContext context)
        {
            post.DatePosted = DateTime.Now;
            string userId = HttpContext.Current.User.Identity.GetUserId();
            // find userprofile by userId then Add post to their posts collection
            UserProfile profile = context.UserProfiles.First(x => x.UserId == userId);
            profile.Posts.Add(post);
            context.SaveChanges();
        }

        public void DeletePost(Post post, CineHiveContext context)
        {

            context.Posts.Remove(post);
            context.SaveChanges();
        }

        public Post GetPost(int id, CineHiveContext context)
        {
            return context.Posts.Find(id);
        }

        public IList<Post> GetCurrUserPosts(CineHiveContext context)
        {
            // gets current user id
            string userid = HttpContext.Current.User.Identity.GetUserId();
            UserProfile user = context.UserProfiles.First(x => x.UserId == userid);
            return user.Posts.ToList(); // return collection of user's posts
        }

        public void EditPost(Post post, CineHiveContext context)
        {
            // make db update existing post with changed/new data
            post.Edited = true;
            context.Entry(post).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
