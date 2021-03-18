using HiveData.DAO;
using HiveData.IDAO;
using HiveData.Models;
using HiveData.Repository;
using HiveServices.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web;

namespace HiveServices.Service
{
    public class PostService : IPostService
    {
        private IPostDAO postDAO;

        public PostService()
        {
            postDAO = new PostDAO();
        }

        public void CreatePost(Post post)
        {
            using (var context = new CineHiveContext())
            {
                string userId = HttpContext.Current.User.Identity.GetUserId();
                var GetProfile = context.UserProfiles.Where(x => x.UserId == userId).Select(c => c.ProfileId).FirstOrDefault();
                int id = GetProfile;
                Post newPost = new Post()
                {
                    UserId = userId,
                    ProfileId = id,
                    PostContent = post.PostContent,
                    DatePosted = DateTime.Now
                };

                postDAO.CreatePost(newPost, context);
            }
        }

        public void DeletePost(int id)
        {
            using (var context = new CineHiveContext())
            {
                Post post = postDAO.GetPost(id, context);
                postDAO.DeletePost(post, context);
            }
        }

        public Post GetPost(int id)
        {
            using (var context = new CineHiveContext())
            {
                return postDAO.GetPost(id, context);
            }
        }

        public IList<Post> GetCurrUserPosts()
        {
            using (var context = new CineHiveContext())
            {
                return postDAO.GetCurrUserPosts(context);
            }
        }

        public void EditPost(Post post)
        {
            using (var context = new CineHiveContext())
            {
                postDAO.EditPost(post, context);
            }
        }
    }
}
