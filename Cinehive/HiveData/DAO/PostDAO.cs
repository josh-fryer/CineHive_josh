using Cinehive.Models;
using HiveData.IDAO;
using HiveData.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.DAO
{
    public class PostDAO : IPostDAO
    {
        public void CreatePost(Post post, ApplicationDbContext context)
        {
            context.Posts.Add(post);
        }
    }
}
