using HiveData.Repository;
using Cinehive.Models;
using HiveData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.IDAO
{
    public interface IPostDAO
    {
        void CreatePost(Post post, CineHiveContext context);
        void DeletePost(Post post, CineHiveContext context);
        Post GetPost(int id, CineHiveContext context);
        //IList<Post> GetPosts(string id, CineHiveContext context);

    }
}
