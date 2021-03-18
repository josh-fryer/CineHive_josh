using HiveData.Repository;
using HiveData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveServices.IService
{
    public interface IPostService
    {
        void CreatePost(Post post);
        void DeletePost(int id);
        Post GetPost(int id);
        IList<Post> GetCurrUserPosts();
        void EditPost(Post post);
    }
}
