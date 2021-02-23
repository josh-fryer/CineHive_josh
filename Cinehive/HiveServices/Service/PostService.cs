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

        public void CreatePost(Post post, string userId)
        {
            Post newPost = new Post()
            {
                
            };

        }
    }
}
