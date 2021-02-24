using Cinehive.Models;
using HiveData.DAO;
using HiveData.IDAO;
using HiveData.Models.Domain;
using HiveServices.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveServices.Service
{
    public class PostService : IPostService
    {
        private IPostDAO postDAO;

        public PostService()
        {
            postDAO = new PostDAO();
        }

        public void CreatePost(Post post, ApplicationUser userId)
        {
            Post newPost = new Post()
            {
                UserId = userId,
                PostContent = post.PostContent,
                DatePosted = DateTime.Now
            };
            using (var context = new ApplicationDbContext())
            {
                postDAO.CreatePost(newPost, context);
            }
        }
    }
}
